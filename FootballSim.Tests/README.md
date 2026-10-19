# Iteration 9A — automated testing foundation

## Inspection and approach

The inspected solution contained Core, Persistence and WinForms, with no existing
test project. Core and Persistence target `net10.0`; WinForms targets
`net10.0-windows`. Tests target `net10.0` and reference Core and Persistence only.
No production code or public API changes were needed or made.

The actual default league has eight teams, 53 players per roster, eight regular
season weeks (four games per week), and 100 free agents. Factory roster generation
uses internally created `Random` instances, `Random.Shared` and GUID identifiers.
Tests assert structural invariants rather than particular generated names or ratings.

`WeekSimulationService` and `PlayoffService` accept `IGameSimulator`; the tests
provide a fixed-score double and verify delegation and state changes. Weekly injury
randomness is internal and cannot be seeded. Recovery tests use an active player
whose injury remains above zero, and players on a bye for final-week recovery and
the healthy-player boundary, preventing random reinjury from affecting assertions.
Other week tests use empty synthetic rosters to isolate orchestration.

V1 accepts a `Random` and gameplan provider. Tests use seeds for reproducibility and
lower/upper-bound random doubles for exact gameplan and score-clamp assertions.
There are no sleeps, reflection-based injection or production changes for testability.

Each persistence test creates its own GUID-named directory under
`Path.GetTempPath()/FootballSim.Tests` and deletes that directory in `Dispose`.
No default save directory or real user save is accessed. Tests do not share mutable
franchises, so xUnit's normal parallel execution can remain enabled.

## Files

Created:

- `FootballSim.Tests.csproj`: .NET 10 test project, SDK, xUnit, Visual Studio runner,
  coverage collector and both project references.
- `TestData.cs`: small synthetic league/player builders and fixed-score simulator.
- `FranchiseFactoryTests.cs`
- `PlayerOverallCalculatorTests.cs`
- `DepthChartServiceTests.cs`
- `TransactionServiceTests.cs`
- `WeekSimulationServiceTests.cs`
- `PlayoffServiceTests.cs`
- `JsonSaveServiceTests.cs`
- `SimpleGameSimulatorV1Tests.cs`
- This report (`FootballSim.Tests/README.md`).

Existing files modified: `FootballSim.slnx` (test-project integration), root
`README.md` (test commands and report link). Core, Persistence and WinForms source
and project files are unchanged. Nothing was committed or pushed.

Pinned stable packages: [Microsoft.NET.Test.Sdk 18.0.1](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/18.0.1),
[xunit 2.9.3](https://www.nuget.org/packages/xunit/2.9.3),
[xunit.runner.visualstudio 3.1.4](https://www.nuget.org/packages/xunit.runner.visualstudio/3.1.4),
and [coverlet.collector 6.0.4](https://www.nuget.org/packages/coverlet.collector/6.0.4).
Restore, compilation and actual execution confirmed compatibility with this project.

## Coverage and test count

87 executed test cases (theory rows count separately), across eight classes:

| Test class | Cases | Baseline covered |
| --- | ---: | --- |
| FranchiseFactoryTests | 3 | Initial state, expected teams and position counts, roster ownership, unique valid GUIDs, schedule integrity, free agents |
| PlayerOverallCalculatorTests | 19 | All 14 position formulas with mixed attributes, lower/upper clamps, identical inputs and no mutation |
| DepthChartServiceTests | 17 | Grouping, rating/name ordering, starter counts at every position, injured starter exclusion, automatic repair, idempotence, healthy-player shortages |
| TransactionServiceTests | 6 | Signing with/without a chart, releasing, ownership and pools, chart membership, 53rd/54th player boundary, missing/duplicate identifiers and repeated release |
| WeekSimulationServiceTests | 7 | Week/result recording, home/away standings, recovery including bye teams, final-week and empty-schedule playoff transitions, phase guard, season completion |
| PlayoffServiceTests | 5 | Seeding and all tiebreakers, replacing stale seeds, 1-v-4/2-v-3 semifinals, insufficient seeds, both home/away advancement paths, champion and replay prevention |
| JsonSaveServiceTests | 12 | Complete franchise round trip in all phases, summary text, injuries, attributes, charts, gameplans, records, schedule, free agents, playoff results/champion, overwrite/list metadata, deletion, blank names, null franchise, missing/malformed/null files |
| SimpleGameSimulatorV1Tests | 18 | Seeded valid scores/stats, scheduled team/week identity and winner, repeatability, all offense/defense focus modifiers, score clamps/home tie breaker, missing teams |

ScheduledGame and GameResult have no separate game-ID property. Tests verify the
available game identity: week number and both team IDs.

## Validation

Executed on Windows with installed SDK `11.0.100-rc.2.26504.105` targeting .NET 10;
the test host used the installed .NET 10 runtime. The SDK emits its preview notice.

```powershell
dotnet test FootballSim.slnx --no-restore --logger "trx;LogFileName=iteration9a.trx" --collect "XPlat Code Coverage"
dotnet build FootballSim.slnx --configuration Release --no-restore
```

- NuGet restore succeeded.
- VSTest discovered and executed **87 cases: 87 passed, 0 failed, 0 skipped**.
- Full Release solution build succeeded: **0 errors, 1 existing warning**,
  CS8602 at `FootballSim.WinForms/RosterForm.cs:211`.
- No test-project compiler/analyzer warnings remained.
- Coverage collector ran successfully: Core **88.85% lines / 82.85% branches**;
  Persistence **96.07% lines / 87.50% branches**. These are assembly-wide execution
  measures, including indirectly exercised code, not evidence of exhaustive assertions.
- Results are under `FootballSim.Tests/TestResults/iteration9a.trx`; Cobertura XML
  is in the GUID subdirectory of `TestResults`. Existing gitignore rules exclude
  test results and build outputs.
- Test Explorer support is configured through the SDK and Visual Studio adapter;
  discovery was verified through CLI VSTest, not by opening Visual Studio's UI.
- `git diff --check` passed.

Environment issues encountered and resolved for validation:

- Sandboxed CLI startup failed with `System.TypeInitializationException` caused by
  `System.Security.SecurityException: Requested registry access is not allowed`
  in the CLI telemetry device-ID lookup. Validation succeeded outside the sandbox
  with `DOTNET_CLI_TELEMETRY_OPTOUT=1`.
- The full Debug build failed with MSB3027/MSB3021 because the running
  `FootballSim.WinForms` process (PID 21388) locked its Core/Persistence DLLs.
  The full Release build succeeded without stopping the running app.
- The initial test run exposed arithmetic mistakes in new test expectations
  (integer division in score calculations and a boundary random input); those
  test expectations/inputs were corrected. No gameplay fix was required.

## Existing issue found

Source inspection found inconsistent handling of tied input scores:
`GameResult.WinnerTeamId` chooses home on `>=`, while weekly standings and playoff
winner assignment choose away unless home is strictly greater. V1 breaks ties
before returning, so the normal V1 path avoids this inconsistency; another
`IGameSimulator` returning ties can expose it. This was not fixed, and tests do not
declare either inconsistent tie policy to be the intended game rule.

V1 can return a home score of 48 after clamping to 45 and then adding three to
break a tie. The boundary test records that existing behavior without changing it.

## Limits and future work

Not yet directly covered: WinForms interaction and franchise context, standalone
TeamRatingCalculator formulas, depth-chart manual move operations, V0 simulation,
random player quality distributions, exact new-injury frequency/duration, a full
season driven by the real simulator, and broader corrupt-but-valid save schemas
or disk/permission failure paths. This is a regression baseline, not exhaustive
gameplay or UI validation.

Recommended next steps: run these commands in Windows CI; add focused team-rating
and depth-chart movement tests; add real-simulator full-season integration tests
using seeds; decide tie policy before adding tie regression tests. If separately
approved later, injectable randomness for weekly injuries/player generation would
allow deterministic tests of the remaining random paths. Consider pinning a stable
.NET 10 SDK in a future tooling change for reproducible developer and CI builds.

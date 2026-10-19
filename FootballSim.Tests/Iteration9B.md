# Iteration 9B — application lifecycle and shutdown

Validated on Windows on October 18, 2026 (America/Phoenix).

## Root cause

`Program.Main` runs `Application.Run(new MainMenuForm())`. New Game and Load Game
previously hid that original menu and showed a modeless franchise hub. Back to
Menu created another `MainMenuForm` and closed the hub. Closing the replacement
menu did not close the hidden original form that owned the application message
loop. Further navigation accumulated hidden menu instances. Simulating weeks was
not required to trigger the lifecycle defect.

New Game and Load Game selection dialogs already use `using` and `ShowDialog`;
their accepted results supply a newly created franchise or a selected save name.
`FranchiseContext` holds the active franchise but does not own any forms or
threads. Hub roster, free agency and save dialogs also already use `using`.
The hub's old `OnFormClosing` override called `Application.Exit()` for its X
button and skipped `base.OnFormClosing`, while a flag bypassed that path for
Back to Menu.

## Fix and changed files

- `FootballSim.WinForms/MainMenuForm.cs`: both entry paths call the same
  `OpenFranchiseHub` method. The original menu is hidden while a hub is shown
  with `ShowDialog(this)`. A `using` scope disposes the modal hub, including when
  it was hidden by a dialog result. A `finally` block clears the franchise
  context and restores the original menu if it is still usable. Exit calls
  `Close()`, matching the main menu X path.
- `FootballSim.WinForms/FranchiseHubForm.cs`: Back to Menu returns
  `DialogResult.OK` and closes. No replacement menu is created. The navigation
  flag and application-exit override are removed; normal WinForms closing
  behavior runs. A non-OK hub result makes the original menu close, preserving
  the existing hub X behavior of exiting the application.
- `README.md`: link to this report.
- `FootballSim.Tests/Iteration9B.md`: this report and reusable manual checklist.

`Program.cs`, New Game, Load Game, `FranchiseContext`, designer files, project
references, gameplay, simulation and persistence implementations are unchanged.
There is no custom application context, lifecycle service or forced termination.

## Automated regression strategy and results

The existing xUnit project targets `net10.0` and references only Core and
Persistence. Its 87 cases cover franchise creation, simulation, playoffs, roster
services and persistence, including full franchise graph save/load round trips.
No automated tests or project references were changed. The fix is directly in
WinForms dialog ownership and message-loop lifetime; extracting an abstraction
solely to test a substitute would not establish actual shutdown. Navigation and
process exit therefore use the manual checklist below. No UI automation framework
or UI tests were added to the repository.

Commands executed successfully after the fix:

```powershell
dotnet restore
dotnet build FootballSim.slnx
dotnet test FootballSim.slnx
```

- Restore: all projects up to date, successful.
- Debug solution build: successful, 0 errors, 1 existing warning, CS8602 at
  `FootballSim.WinForms/RosterForm.cs:211` (possible null dereference).
- Tests: **87 passed, 0 failed, 0 skipped**, using the .NET 10 test runtime.
- SDK: installed `11.0.100-rc.2.26504.105`, targeting .NET 10. Build/test output
  includes the NETSDK1057 preview SDK notice.
- `git diff --check`: passed.

The initial sandboxed restore failed to start/connect to MSBuild. The requested
commands succeeded outside the sandbox with `DOTNET_CLI_TELEMETRY_OPTOUT=1`.
No code changes were needed to resolve that environment restriction.

## Manual Windows application checklist and actual results

The built Debug executable was launched and its actual buttons and dialogs were
operated using the computer-use skill. These were interactive application checks,
not additional xUnit tests. Read-only `Get-Process -Name FootballSim*` checks ran
outside the sandbox after shutdown, so hidden processes would also be detected.
The executable is named **FootballSim.WinForms.exe** in this build. Task Manager
itself was not opened; process absence was verified through `Get-Process`.

| Case | Procedure | Actual result |
| --- | --- | --- |
| A | Launch, close main menu with X; check process list. | Passed. No matching process remained. |
| B | Launch, New Game, Start, hub, Back to Menu, menu X; check process list. | Passed after three simulated weeks. The original menu window handle `265782` returned; no matching process remained after closing it. |
| C | Launch, Load Game, hub, Back to Menu, menu X; check process list. | Passed, including repeated loading before exit. No matching process remained. |
| D | Launch, New Game, save, Back to Menu, Load Game, verify saved state. | Passed in one session: Arizona, week 1, offense 83, defense 77, initial standings and empty results were restored. Separately, a three-week simulated franchise was saved, the process exited, and a new process loaded week 4 with the same results, standings and injuries. |
| E | Repeatedly enter hubs and return; inspect menu identity and window list, then exit. | Passed in the exercised cycles: two consecutive Load Game hub/return cycles reused menu handle `659112`; the same-session New Game then Load Game flow reused menu handle `724582`. Only the original menu was listed after each return, and final process exit succeeded. Code inspection confirms no additional menu construction and deterministic hub disposal. |
| F | Simulate several weeks, return, exit; check process list. | Passed: weeks 1–3 advanced to week 4; returning and closing the menu left no matching process. |
| G | Launch, click main menu Exit; check process list. | Passed. No matching process remained. |
| H | Use title-bar X on menu and hub; check process list. | Passed for the initial menu, menus returned from both workflows, and a loaded franchise hub. Hub X closed the application, preserving the previous behavior. |

Two new save slots were created and retained for inspection; no previous save was
overwritten or deleted:

- `Iteration9B_Lifecycle_20261018`: Arizona at week 4 after three simulated weeks.
- `Iteration9B_SameSession_20261018`: Arizona at week 1 for the same-session round trip.

For a visual Task Manager recheck, repeat A–H and confirm that no
`FootballSim.WinForms.exe` entry remains on the Details tab after each exit.

## Remaining limits

The lifecycle has no automated UI coverage; future navigation changes should
repeat this checklist. Interactive checks were finite, not a stress test of
hundreds of navigation cycles. They did not cover Windows logoff, operating
system shutdown or injected failures during hub construction. The existing
nullable warning remains outside this issue's scope. No regressions were
observed in the tests or exercised workflows. No commit, push or issue closure
was performed.

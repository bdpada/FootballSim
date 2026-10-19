# FootballSim

Automated regression tests are in `FootballSim.Tests` and target .NET 10.

```powershell
dotnet build FootballSim.slnx --configuration Release
dotnet test FootballSim.slnx
dotnet test FootballSim.slnx --collect "XPlat Code Coverage"
```

Open `FootballSim.slnx` in a Visual Studio version that supports .NET 10, restore
packages and build; the xUnit Visual Studio adapter enables Test Explorer discovery.
Close a running Debug instance before building Debug, or use Release to avoid locked DLLs.

See [the Iteration 9A report](FootballSim.Tests/README.md) for coverage, limitations and validation results.

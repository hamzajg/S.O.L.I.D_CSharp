# AGENTS.md — S.O.L.I.D_CSharp

Guidance for AI agents (and humans) working in this repository.

## Project

The five SOLID principles demonstrated in C#, each twice: a `Violate/`
folder with the code that breaks the principle and a sibling folder with
the refactored version. Follows the structure of Dmitri Nesteruk's
*Design Patterns in C#* course. Teaching/reference repo.
Stack: C# `net10.0`, xUnit tests (27), console demo via `Program.cs`.

## Commands

Verified 2026-11-13 against CI (`.github/workflows/ci.yml`) and README.

| Task | Command |
|---|---|
| Build | `dotnet build S.O.L.I.D_CSharp.sln --configuration Release` |
| Test | `dotnet test S.O.L.I.D_CSharp.sln --configuration Release --no-build` (27 tests) |
| Run demo | `dotnet run --project S.O.L.I.D_CSharp` |

Requires: .NET 10 SDK (CI `10.0.x`). Solution: `S.O.L.I.D_CSharp.sln`.

## Architecture

```
S.O.L.I.D_CSharp/            (the demo app)
  SRP/  Journal.cs + Persistence.cs   | Violate/Journal.cs
  OCP/  IFilter/ISpecification/BetterFilter/AndSpecification/Product…
                                     | Violate/ProductFilter.cs
  LSP/  Rectangle.cs + Square.cs      | Violate/Rectangle.cs + Violate/Square.cs
  ISP/  IPrinter/IScanner/MultiFunctionMachine/MultiFunctionPrinter…
                                     | Violate/IMachine.cs + Violate/OldFashionedPrinter.cs
  DIP/  IRelationshipBrowser/Research/Relationships/Person
                                     | Violate/Relationships.cs + Violate/Research.cs
  Program.cs               runs SRP/OCP/LSP/DIP demos (ISP not invoked)
S.O.L.I.D_CSharp.Tests/     one test class per principle (Srp/Ocp/Lsp/Isp/Dip)
```

The `Violate/` folders are **intentional bad code** — they exist to be
compared, not fixed. `LspTests` even pins the violation so it can't be
mistaken for correct.

## Conventions

- **Both versions stay**: every principle keeps `Violate/` + good code
  side by side. Never "fix" or delete the Violate folders — they're the
  lesson.
- Tests state the *rule* each example teaches, not the implementation —
  write new tests the same way.
- `Program.cs` demos SRP/OCP/LSP/DIP only; ISP types compile but aren't
  invoked — that's documented, not a bug.
- SRP demo writes `Journal.txt` next to the exe and opens it via
  `UseShellExecute` — headless runs just skip the visible part.
- KISS: plain classes, no DI/framework; the structure IS the content.

## Landmines

- **Default branch is `master`, not `main`.**
- `Violate/` code deliberately breaks rules — reviewers/agents must not
  "clean it up"; it's referenced by tests and README tables.
- Namespace/folder names contain dots (`S.O.L.I.D_CSharp`) — quote paths
  in shell commands.
- README says ".NET 8 SDK" in places; csproj/CI are `net10.0` — trust those.

## Agent rules

- Branch from `master`; name branches `feat/*`, `fix/*`, `chore/*`, `docs/*`.
- Docs-only changes still go through a PR; never commit to `master` directly.
- Verify before claiming: `dotnet build` + `dotnet test` and report the
  real result.
- Keep changes minimal and consistent with surrounding code. No drive-by
  refactors — and never "fix" the `Violate/` examples.
- Update AGENTS.md / docs/ARCHITECTURE.md when adding a principle example
  or changing the Violate/good split.

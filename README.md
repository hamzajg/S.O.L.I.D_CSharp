# S.O.L.I.D_CSharp

The five SOLID principles demonstrated in C#, each one twice: a `Violate/`
folder with the code that breaks the principle, and a sibling folder with the
refactored version. The examples follow the structure of Dmitri Nesteruk's
*Design Patterns in C#* course.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Build and run

```bash
dotnet build S.O.L.I.D_CSharp.sln
dotnet run --project S.O.L.I.D_CSharp
```

The `run` command prints the result of each example. The SRP section also
writes `Journal.txt` next to the executable and opens it with the operating
system's default application (`UseShellExecute`), so on a headless machine that
last step is the only part that may not do anything visible.

## The principles

| Principle | Good example | Bad example | What changes |
|---|---|---|---|
| **S**ingle Responsibility | [`SRP/Journal.cs`](S.O.L.I.D_CSharp/SRP/Journal.cs), [`SRP/Persistence.cs`](S.O.L.I.D_CSharp/SRP/Persistence.cs) | [`SRP/Violate/Journal.cs`](S.O.L.I.D_CSharp/SRP/Violate/Journal.cs) | `Journal` only keeps entries; saving to a file moves to `Persistence`. |
| **O**pen/Closed | [`OCP/BetterFilter.cs`](S.O.L.I.D_CSharp/OCP/BetterFilter.cs), [`OCP/ISpecification.cs`](S.O.L.I.D_CSharp/OCP/ISpecification.cs) | [`OCP/Violate/ProductFilter.cs`](S.O.L.I.D_CSharp/OCP/Violate/ProductFilter.cs) | New filters are new `ISpecification<T>` classes; `BetterFilter` never changes. `AndSpecification` combines specifications. |
| **L**iskov Substitution | [`LSP/Rectangle.cs`](S.O.L.I.D_CSharp/LSP/Rectangle.cs), [`LSP/Square.cs`](S.O.L.I.D_CSharp/LSP/Square.cs) | [`LSP/Violate/Rectangle.cs`](S.O.L.I.D_CSharp/LSP/Violate/Rectangle.cs), [`LSP/Violate/Square.cs`](S.O.L.I.D_CSharp/LSP/Violate/Square.cs) | The bad version hides the setters with `new`, so assigning through a `Rectangle` reference leaves a `Square` with mismatched sides. The good version makes them `virtual`/`override`, so the square invariant survives substitution. (The hierarchy is still a classic LSP trap: code that expects to set width and height independently will be surprised.) |
| **I**nterface Segregation | [`ISP/IPrinter.cs`](S.O.L.I.D_CSharp/ISP/IPrinter.cs), [`ISP/IScanner.cs`](S.O.L.I.D_CSharp/ISP/IScanner.cs), [`ISP/MultiFunctionMachine.cs`](S.O.L.I.D_CSharp/ISP/MultiFunctionMachine.cs) | [`ISP/Violate/IMachine.cs`](S.O.L.I.D_CSharp/ISP/Violate/IMachine.cs), [`ISP/Violate/OldFashionedPrinter.cs`](S.O.L.I.D_CSharp/ISP/Violate/OldFashionedPrinter.cs) | One fat `IMachine` forces an old printer to implement `Scan`/`Fax`; small interfaces let each device implement only what it supports. `MultiFunctionMachine` composes an `IPrinter` and an `IScanner`. |
| **D**ependency Inversion | [`DIP/IRelationshipBrowser.cs`](S.O.L.I.D_CSharp/DIP/IRelationshipBrowser.cs), [`DIP/Research.cs`](S.O.L.I.D_CSharp/DIP/Research.cs) | [`DIP/Violate/Research.cs`](S.O.L.I.D_CSharp/DIP/Violate/Research.cs) | `Research` depends on the `IRelationshipBrowser` abstraction instead of a concrete `Relationships` class. |

`Program.cs` runs the SRP, OCP, LSP, and DIP examples. The ISP types are
standalone illustrations: they compile as part of the project but are not
invoked from `Main`.

## Tests

```bash
dotnet test S.O.L.I.D_CSharp.sln
```

27 xUnit tests, one behaviour each, grouped by principle. They state the rules
the examples are about rather than restating the code:

| File | Tests |
|---|---|
| [`SrpTests`](S.O.L.I.D_CSharp.Tests/SrpTests.cs) | Entry numbering, entry order, removal, and that `Persistence` writes, refuses to overwrite without `overwrite: true`, and loads back what it saved |
| [`OcpTests`](S.O.L.I.D_CSharp.Tests/OcpTests.cs) | Each specification filters on its own, `AndSpecification` needs both sides, and a new rule is a new specification |
| [`LspTests`](S.O.L.I.D_CSharp.Tests/LspTests.cs) | A rectangle keeps its two sides; a `Square` assigned through a `Rectangle` does not — the violation, pinned so it cannot be mistaken for correct |
| [`IspTests`](S.O.L.I.D_CSharp.Tests/IspTests.cs) | `MultiFunctionMachine` reaches only the injected `IPrinter` / `IScanner` it needs |
| [`DipTests`](S.O.L.I.D_CSharp.Tests/DipTests.cs) | `Relationships` answers the query, and `Research` accepts any `IRelationshipBrowser` — including a fake that never touches the concrete store |

## Layout

```
S.O.L.I.D_CSharp/
  SRP/   OCP/   LSP/   ISP/   DIP/
    Violate/   # the version that breaks the principle
    ...        # the refactored version
  Program.cs   # runs the examples
S.O.L.I.D_CSharp.Tests/   xunit tests, one file per principle
S.O.L.I.D_CSharp.sln
```

## Continuous integration

[`.github/workflows/ci.yml`](.github/workflows/ci.yml) builds the solution in
Release configuration and runs the tests on every push and pull request to
`master`.

## License

See [LICENSE](LICENSE).

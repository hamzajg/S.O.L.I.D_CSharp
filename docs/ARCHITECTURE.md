# Architecture — S.O.L.I.D_CSharp

Current-state map. Descriptive, not aspirational; see `docs/adr/` for why.

## Shape

```
S.O.L.I.D_CSharp.sln
├── S.O.L.I.D_CSharp/         console app — examples + Program.cs demos
│   ├── SRP/  good: Journal + Persistence   Violate/: Journal does both
│   ├── OCP/  good: IFilter + ISpecification + BetterFilter + AndSpecification
│   │         Violate/: ProductFilter with growing if/else
│   ├── LSP/  good: virtual/override Rectangle+Square
│   │         Violate/: `new`-hidden setters break substitution
│   ├── ISP/  good: IPrinter/IScanner + MultiFunctionMachine composition
│   │         Violate/: fat IMachine + OldFashionedPrinter
│   └── DIP/  good: Research depends on IRelationshipBrowser
│             Violate/: Research depends on concrete Relationships
└── S.O.L.I.D_CSharp.Tests/   xUnit — SrpTests, OcpTests, LspTests, IspTests, DipTests
```

## Design

- **Violation-first pedagogy.** Each principle folder contains the broken
  version (`Violate/`) and the corrected version side by side; the
  contrast is the content.
- **Tests encode the rule.** Each test class states what the principle
  demands (e.g. LspTests pins that a `Square` through a `Rectangle`
  reference misbehaves — documenting the trap, not endorsing it).
- **No infrastructure.** Plain classes, file persistence only in the SRP
  example, console output for demos. Nothing to configure.

## Runtime behaviour

`Program.cs` runs SRP → OCP → LSP → DIP demos sequentially. ISP is
compile-only illustration. The SRP demo persists `Journal.txt` beside the
executable and shell-opens it (no-op on headless CI).

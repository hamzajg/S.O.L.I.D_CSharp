# ADR 0001 — Initial architecture

Date: 2026-11-13 (baseline recorded retroactively)
Status: accepted (describes what is built)

## Context

A teaching repo for the five SOLID principles in C#, structured after
Dmitri Nesteruk's course: each principle shown broken, then fixed.

## Decisions

1. **Violation + correction side by side.** Every principle has a
   `Violate/` folder and a good-code sibling. Rationale: the contrast
   teaches better than prose; both versions stay permanently.
2. **xUnit tests state the rules.** 27 tests, one behaviour each, grouped
   per principle — including tests that pin the *violation's* bad
   behaviour (LSP) so it can't be mistaken for correct. Rationale: tests
   are the executable spec of what each principle means.
3. **Plain classes, zero infrastructure.** No DI, no frameworks, file I/O
   only where the example needs it (SRP journal). Rationale: the principles
   must be visible without framework noise — KISS.
4. **Console demo via Program.cs.** SRP/OCP/LSP/DIP run in `Main`; ISP is
   compile-only. Rationale: runnable illustration without a UI.
5. **net10.0 target.** Retargeted during the fleet SDK sweep; CI pins
   `10.0.x`. (README's ".NET 8" references are stale.)

## Consequences

- `Violate/` code is *supposed* to violate — any "cleanup" PR that fixes
  it destroys the lesson. Guarded by convention + tests.
- New principles/examples must preserve the Violate/good pairing.
- The repo teaches principles in isolation; it is not a style guide for
  production codebases.

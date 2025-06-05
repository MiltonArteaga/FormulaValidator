# Formula Validator

## Objective

Validate whether a formula composed of the characters `()[]{}` is well-formed.

## Project Structure

- **`FormulaValidator`**: Contains the core validation logic.
- **`FormulaValidator.Tests`**: MSTest project that verifies the logic using input files.

## Approach

- A **stack** is used to ensure the correct order of opening and closing brackets.
- The **`IBracketValidator`** interface is used to allow easy extension or replacement of the implementation.

## Test Execution

The tests read two input files:

- `Well formed formulas.txt`
- `Bad formed formulas.txt`

> Each formula must be separated by commas (`,`), and may span multiple lines.

## Principles and Design Patterns Applied

- **SOLID**: Interface usage and separation of responsibilities.
- **Strategy Pattern**: Can be extended with multiple validator implementations.
- **Clean Code**: Clear naming, small methods, and automated testing.

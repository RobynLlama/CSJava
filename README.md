# CSJava

CSJava is a learning project about embedding the [Jint](https://github.com/sebastienros/jint) JavaScript engine in C# with TypeScript for scripting. It demonstrates running compiled TypeScript code inside a .NET app using Jint.

## Getting Started

### Install dependencies

Run the following to install Node.js dependencies (including TypeScript):

```bash
npm install
```

### Build

Compile the TypeScript source files to JavaScript:

```bash
npm run build
```

This runs the TypeScript compiler (`tsc`) and outputs JS files for Jint to use and also compiles the C# portion of the project.

### Execute

Run the C# application that loads and executes the compiled JavaScript:

```bash
npm run exe
```

## VSCode Integration

A VSCode task is configured as the **default build task** (`Ctrl+Shift+B`). Running this task will just run the same build script as `npm run build` just without having to type it yourself.

## Notes

- TypeScript files live in `src/scripts` and compile to `JS/` for execution in the engine
- `src/scripts` is the root of typescript resolution so all imports should be relative to it.
- Jint cannot handle imports that don't end in `.js` so configure `TypeScript.Preferences.ImportModuleSpecifierEnding` from `auto` to `.js/.ts` if using VS:Code.
- The C# project hosts the Jint engine and runs the compiled scripts starting from `src/main.js`

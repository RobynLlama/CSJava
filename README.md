# CSJava

CSJava is a learning project about embedding the [Jint](https://github.com/sebastienros/jint) JavaScript engine in C# with TypeScript for scripting. It demonstrates running compiled TypeScript code inside a .NET app using Jint.

## Getting Started

### Install dependencies

Run the following to install Node.js dependencies (including TypeScript) and install all required tooling for the build action:

```bash
dotnet tool restore
npm install
```

### Build

Compile the TypeScript source files to JavaScript:

```bash
dotnet build
```

The build file for CSJava includes a step that uses `esbuild` to create all the required javascript files for the demo

### Execute

Run the C# application that loads and executes the compiled JavaScript:

```bash
dotnet run --project=src/CSJava/CSJava.csproj
```

This will invoke the project's build target as needed so you rarely need to build manually

## VSCode Integration

A VSCode task is configured as the **default build task** (`Ctrl+Shift+B`). Running this task will just run the same build script as `dotnet build` just without having to type it yourself.

## Notes

- TypeScript files live in `src/<script name>/main.ts` and compile to `JS/<script name>.js` for execution in the engine
- `src/` is the root of typescript resolution so all imports should be relative to it.
- The C# project hosts the Jint engine and runs the compiled scripts from the `JS` folder

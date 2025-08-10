# CSJava

CSJava is a learning project about embedding the [Jint](https://github.com/sebastienros/jint) JavaScript engine in C# with TypeScript for scripting. It demonstrates running compiled TypeScript code inside a .NET app using Jint.

## Getting Started

### Install dependencies

This project requires [Node.js](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm) and `npm` (Node Package Manager) to be installed on your system.

Run the following in the root of the cloned repository to install the project's dependencies and all required tooling for the build action:

```bash
dotnet tool restore
npm install
```

> **Note:** If you encounter issues installing dependencies (e.g., `esbuild` fails to install due to npm version conflicts), you may need to switch your Node.js version using [nvm](https://github.com/nvm-sh/nvm). For example:
>
> ```bash
> nvm use 20
> npm install
> ```
>
> This ensures compatibility with the required npm version for `esbuild`.

### Build

Compiles the whole project including transpiling the TypeScript source files to JavaScript:

```bash
dotnet build
```

The build file for CSJava includes a step that uses `esbuild` to create all the required JavaScript files for the demo.

### Execute

Run the C# application that loads and executes the compiled JavaScript:

```bash
dotnet run --project=src/CSJava/CSJava.csproj
```

This will invoke the project's build target as needed so you rarely need to build manually.

## VSCode Integration

A VSCode task called "Build CSJava" is configured as the **default build task** (`Ctrl+Shift+B`). Running this task will just run the same build script as `dotnet build` just without having to type it yourself.

You may also use the command pallette to run the provided "Run CSJava" task that will skip needing to type `dotnet run --project ..." every time

## Notes

- TypeScript files live in `src/<script name>/main.ts` and compile to `JS/<script name>.js` for execution in the engine.
- `src/` is the root of TypeScript resolution so all imports should be relative to it.
- The C# project hosts the Jint engine and runs the compiled scripts from the `JS` folder.

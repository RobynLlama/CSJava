#nullable enable
DirectoryInfo scriptDir = new("./src");
DirectoryInfo outputDir = new("./JS");

static string GetRelativeDir(DirectoryInfo baseDir, DirectoryInfo currentDir) =>
  currentDir.FullName.Replace(baseDir.FullName, string.Empty);

List<FileInfo> buildFiles = [];

Console.WriteLine($"Building from {scriptDir.FullName}");

//only go one layer deep
foreach (var dir in scriptDir.GetDirectories())
{
  //check each file for a main.ts
  foreach (var file in dir.GetFiles())
  {
    FileInfo? main = null;

    if (file.Name.Equals("main.ts", StringComparison.OrdinalIgnoreCase))
    {
      main = file;
    }

    if (main is null)
      continue;

    var input = main.FullName;
    var relativeDir = GetRelativeDir(scriptDir, dir).Trim(Path.PathSeparator).Trim(Path.AltDirectorySeparatorChar);
    var outputName = Path.GetFileName(Path.GetDirectoryName(main.FullName)) ?? "unknown";
    var output = Path.Combine(outputDir.FullName, outputName + ".js");
    var buildString = $"npx esbuild {input} --bundle --outfile={output}";

    /*Console.WriteLine($"""
    Details:
      In:{input}
      Rel:{relativeDir}
      OutNa:{outputName}
      Out:{output}
      Build:{buildString}
    """);*/

    Console.WriteLine($"Building {dir.Name}/{file.Name} to {output}");

    var process = new Process();
    process.StartInfo.FileName = "npx";
    process.StartInfo.Arguments = buildString;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;

    process.Start();

    string outputResult = process.StandardOutput.ReadToEnd();
    string errorResult = process.StandardError.ReadToEnd();

    process.WaitForExit();

    Console.WriteLine(outputResult);

    if (!string.IsNullOrEmpty(errorResult))
    {
      Console.Error.WriteLine(errorResult);
    }
  }
}

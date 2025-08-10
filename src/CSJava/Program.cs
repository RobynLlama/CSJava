using Jint;

namespace CSJava;

class Program
{
  static void Main()
  {
    var engine = new Engine(options =>
    {
      options.EnableModules(Path.GetFullPath(@"./JS"));
    })
    .SetValue("Wrapper", new ContextWrapper());

    var script = File.ReadAllText("./JS/main.js");

    engine.Execute(script);
  }
}

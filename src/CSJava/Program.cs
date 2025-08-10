using Jint;

namespace CSJava;

class Program
{
  static void Main()
  {
    var context = new ContextWrapper();

    var engine = new Engine(options =>
    {
      options.EnableModules(Path.GetFullPath(@"./JS"));
    })
    .SetValue("Wrapper", context);

    var engine2 = new Engine(options =>
    {
      options.EnableModules(Path.GetFullPath(@"./JS"));
    })
    .SetValue("Wrapper", context);

    var script1 = File.ReadAllText("./JS/script1.js");
    var script2 = File.ReadAllText("./JS/script2.js");

    engine.Execute(script1, "script1.js");
    engine2.Execute(script2, "script2.js");
  }
}

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

    engine.Modules.Import("./main.js");
  }
}

namespace CSJava;

public class ContextWrapper
{
  public void Log(object item) => Console.WriteLine(item);
  public Network network = new();
}

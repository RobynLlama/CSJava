export function greetings()
{
  Wrapper.log("hello from another file");
  Wrapper.network.writeToNetworkPort(100, "Hello from greetings!");
}

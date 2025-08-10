function NetworkListener(message: string)
{
  Wrapper.log(`Script 1 heard this: ${message}`);
}

Wrapper.network.openNetworkPort(100, NetworkListener);
Wrapper.log("Script 1 has opened port 100");

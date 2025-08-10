import { greetings } from "./module.js";

function butts(message: string)
{
  Wrapper.log(`Butts was called ${message}`);
}

Wrapper.log("Greetings from main");
Wrapper.network.openNetworkPort(100, butts);
greetings();

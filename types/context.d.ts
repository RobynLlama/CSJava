interface Network
{
  openNetworkPort(port: number, callback: (message: string) => void): boolean;
  writeToNetworkPort(port: number, message: string): boolean;
}

interface ContextWrapper
{
  log(message: any): void;
  network: Network;
}

declare var Wrapper: ContextWrapper;

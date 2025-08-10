using Jint;
using Jint.Native.Function;

namespace CSJava;

public class Network
{
  internal readonly Dictionary<int, ScriptFunction> _networkMembers = [];
  public bool OpenNetworkPort(int portNum, ScriptFunction callback)
  {
    if (_networkMembers.ContainsKey(portNum))
      return false;

    _networkMembers[portNum] = callback;
    return true;
  }

  public bool WriteToNetworkPort(int portNum, string message)
  {
    if (!_networkMembers.TryGetValue(portNum, out var callback))
      return false;

    callback.Call(message);
    return true;
  }
}

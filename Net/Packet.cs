using System.Text.Json;

namespace OpenWarfare.Net
{
    public abstract class Packet
    {
        readonly int ProtocolVer = 1;
        byte PlayerID { get; set; }
        readonly Int16 PNAME; // Packet name
        JsonElement? data { get; set; } // Some packets are bodyless
        string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        Packet? Compose(string str)
        {
            var Deserialized = JsonSerializer.Deserialize<Packet>(str);
            if (Deserialized != null)
            {
                return Deserialized;
            }
            
        }
    }
}
namespace Mst.Net;

public static class IpAddress
{
    static IpAddress() { }

    public static string Fix(string ipV4Address)
    {
        if (string.IsNullOrWhiteSpace(ipV4Address))
            return null;

        ipV4Address = ipV4Address.Replace(":", ".").Replace(" ", string.Empty);

        if (ipV4Address.Length > 15)
            return null;

        string[] parts = ipV4Address.Split('.');
        if (parts.Length != 4)
            return null;

        for (int index = 0; index < parts.Length; index++)
        {
            // اطمینان از اینکه همه اجزاء عددی هستند  
            if (!int.TryParse(parts[index], out int partInt) || partInt < 0 || partInt > 255)
                return null;

            parts[index] = partInt.ToString();
        }

        return string.Join(".", parts);
    }

    public static string Format(string ipV4Address, char padLeftCharacter = '0')
    {
        string value = Fix(ipV4Address);
        if (value == null)
            return null;

        string[] parts = value.Split('.');
        for (int index = 0; index < parts.Length; index++)
        {
            // 192.168.1.1 ====>  192.168.001.001
            parts[index] = parts[index].PadLeft(3, padLeftCharacter);
        }

        return string.Join(".", parts);
    }

    public static uint? ToNumber(string ipV4Address)
    {
        string value = Fix(ipV4Address);

        if (value == null)
            return null;

        try
        {
            var ipAddress = System.Net.IPAddress.Parse(value);
            var bytes = ipAddress.GetAddressBytes().Reverse().ToArray();
            var res = BitConverter.ToUInt32(bytes, 0);
            return res;
        }
        catch
        {
            return null;
        }
    }

    public static string ToString(uint ipV4Address)
    {
        byte[] bytes = BitConverter.GetBytes(ipV4Address);

        // Little Endian : 78 56 34 12  
        // Big Endian : 12 34 56 78  

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        try
        {
            var res = new System.Net.IPAddress(bytes).ToString();
            return res;
        }
        catch
        {
            return null;
        }
    }
}
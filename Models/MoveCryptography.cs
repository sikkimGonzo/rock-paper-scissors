namespace Models;

public class MoveCryptography
{
    public static byte[] GetKeySHA256(int bytes)
    {
        byte[] key;
        using(var generator = RandomNumberGenerator.Create())
        {
            key = new byte[bytes];
            generator.GetBytes(key);
        }
        return key;
    }

    public static byte[] GetHMAC(byte[] key, string data)
    {
        byte[] hmac;
        using(var hash = new HMACSHA256(key))
        {
            hmac = hash.ComputeHash(Encoding.UTF8.GetBytes(data));
        }
        return hmac;
    }
}
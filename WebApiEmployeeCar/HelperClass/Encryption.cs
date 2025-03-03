using System.Security.Cryptography;
using System.Text;

namespace WebApiEmployeeCar.Repositories
{
    public class Encryption
    {
        public static string Encrypt(string input)
        {
            var x = new MD5CryptoServiceProvider();
            var bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);

            var s = new StringBuilder();
            foreach (var b in bs) s.Append(b.ToString("x2").ToLower());

            return s.ToString();
        }
    }
}
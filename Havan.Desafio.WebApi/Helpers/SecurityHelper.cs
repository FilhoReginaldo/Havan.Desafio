using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Havan.Desafio.WebApi.Helpers
{
    public class SecurityHelper
    {
        public static int getUserID(List<Claim> claims)
        {
            int UserID = 0;
            
            if (claims.FirstOrDefault(c => c.Type == ClaimTypes.Name) != null)
                UserID = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);
           
            return UserID;
        }

        public static string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
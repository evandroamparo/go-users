using System;
using System.Security.Cryptography;
using System.Text;

namespace GoUsers.Model
{
  public class CriptoService
  {
    public string GetHash(string senha)
    {
      var sha1 = new SHA1CryptoServiceProvider();
      byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(senha)); 
      return Convert.ToBase64String(hashData);
    }
  }
}

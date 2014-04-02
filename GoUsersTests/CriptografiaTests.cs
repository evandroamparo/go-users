using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoUsers.Model;

namespace GoUsers.Tests
{
  [TestClass]
  public class CriptografiaTests
  {
    [TestMethod]
    public void SenhaDeveEstarCodificadaComSHA1Base64()
    {
      var senha = "badger";
      var senhaCriptografada = "ThmbShxAtJepX80c2JY1FzOEmUk=";
      var criptoService = new CriptoService();
      Assert.AreEqual(senhaCriptografada, criptoService.GetHash(senha));
    }
  }
}

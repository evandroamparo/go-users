using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoUsers.Model;

namespace GoUsers.Tests
{
  [TestClass]
  public class UsuarioTests
  {
    private Usuario usuario;
    private string senhaCriptografada;

    [TestInitialize]
    public void Setup()
    {
      usuario = new Usuario("admin", "badger", true);
      senhaCriptografada = "ThmbShxAtJepX80c2JY1FzOEmUk=";
    }

    [TestMethod]
    public void NovoUsuarioDeveTerDadosCorretos()
    {
      Assert.AreEqual("admin", usuario.Login);
      Assert.AreEqual(true, usuario.Admin);
      Assert.AreEqual(senhaCriptografada, usuario.SenhaCriptografada);
    }

    [TestMethod]
    public void UsuarioAlteradoDeveTerSenhaCriptograda()
    {
      usuario.Senha = "123456";
      var novaSenhaCriptografada = "fEqNCco3Yq9h5ZUglD3CZJT4lBs=";
      Assert.AreEqual(novaSenhaCriptografada, usuario.SenhaCriptografada);
      
    }

    [TestMethod]
    public void UsuarioDeveSerPersistidoNoFormatoCorreto()
    { 
      var formato = string.Format("{0}:{1}", "admin", senhaCriptografada);
      Assert.AreEqual(formato, usuario.ToString());
    }
  }
}

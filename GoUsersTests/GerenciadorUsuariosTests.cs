using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoUsers.Model;

namespace GoUsers.Tests
{
  [TestClass]
  public class GerenciadorUsuariosTests
  {
    [TestMethod]
    public void UsuarioAdicionadoDeveConstarNaLista()
    {
      var usuario = new Usuario("admin", "senha", true);
      GerenciadorUsuarios.AdicionarUsuario(usuario);
      CollectionAssert.Contains(GerenciadorUsuarios.Usuarios, usuario);
      Assert.AreEqual(1, GerenciadorUsuarios.Usuarios.Count);
    }
  }
}

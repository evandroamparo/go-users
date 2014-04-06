using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoUsers.Model;
using System.IO;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace GoUsers.Tests
{
  [TestClass]
  public class GerenciadorUsuariosTests
  {
    private Usuario usuario;
    private GerenciadorUsuarios gerenciadorUsuarios;
    private string arquivoTeste;

    [TestInitialize]
    public void Setup()
    {
      usuario = new Usuario("admin", "senha", true);
      arquivoTeste = "usuarios.txt";
      if (File.Exists(arquivoTeste))
      {
        File.Delete(arquivoTeste);
      }
      gerenciadorUsuarios = new GerenciadorUsuarios(arquivoTeste);
    }

    [TestMethod]
    [ExpectedException(typeof(UsuarioDuplicadoException))]
    public void LoginNaoPodeSerDuplicado()
    {
      gerenciadorUsuarios.AdicionarUsuario(usuario);
      var usuarioDuplicado = new Usuario("ADMIN", "teste");
      gerenciadorUsuarios.AdicionarUsuario(usuarioDuplicado);
    }

    [TestMethod]
    public void UsuarioAdicionadoDeveConstarNaLista()
    {
      gerenciadorUsuarios.AdicionarUsuario(usuario);
      CollectionAssert.Contains(gerenciadorUsuarios.Usuarios, usuario);
    }

    [TestMethod]
    public void UsuarioExcluidoNaoDeveConstarNaLista()
    {
      gerenciadorUsuarios.AdicionarUsuario(usuario);
      gerenciadorUsuarios.ExcluirUsuario(usuario);
      CollectionAssert.DoesNotContain(gerenciadorUsuarios.Usuarios, usuario);
    }

    [TestMethod]
    public void ArquivoInexistenteDeveInicializarListaVazia()
    {
      gerenciadorUsuarios = new GerenciadorUsuarios("nome de arquivo inexistente");
      Assert.AreEqual(0, gerenciadorUsuarios.Usuarios.Count);
    }

    [TestMethod]
    [UseReporter(typeof(DiffReporter), typeof(FrameworkAssertReporter))]
    public void ArquivoExistenteDeveInicializarListaPreenchida()
    {
      gerenciadorUsuarios = new GerenciadorUsuarios("exemplos/usuarios.txt");
      Approvals.Verify(gerenciadorUsuarios);
    }

    [TestMethod]
    [UseReporter(typeof(DiffReporter))]
    public void NovosUsuariosDevemSerPersistidosNoArquivo()
    {
      var novoUsuario = new Usuario("NovoUsuario", "123456");
      gerenciadorUsuarios.AdicionarUsuario(novoUsuario);
      gerenciadorUsuarios = new GerenciadorUsuarios(arquivoTeste);
      Approvals.Verify(gerenciadorUsuarios);
    }

    [TestMethod]
    public void UsuariosExcluidosDevemSerExcluidosDoArquivo()
    {
      gerenciadorUsuarios.AdicionarUsuario(usuario);
      gerenciadorUsuarios.ExcluirUsuario(usuario);
      gerenciadorUsuarios = new GerenciadorUsuarios(arquivoTeste);
      Usuario usuarioRecuperado = gerenciadorUsuarios.RecuperarUsuario("admin");
      Assert.IsNull(usuarioRecuperado);
    }
  }
}

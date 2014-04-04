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
    private string arquivo;

    [TestInitialize]
    public void Setup()
    {
      usuario = new Usuario("admin", "senha", true);
      arquivo = "usuarios.txt";
      gerenciadorUsuarios = new GerenciadorUsuarios(arquivo);
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
    public void UsuariosDevemSerPersistidosNoArquivo()
    {
      gerenciadorUsuarios.AdicionarUsuario(usuario);
      //gerenciadorUsuarios.Salvar();
    }
  }
}

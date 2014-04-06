using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoUsers.Model
{
  public class GerenciadorUsuarios
  {
    private List<Usuario> usuarios;
    private string arquivo;

    public GerenciadorUsuarios(string arquivo)
    {
      usuarios = new List<Usuario>();
      this.arquivo = arquivo;
      if (File.Exists(arquivo))
      {
        var conteudo = File.ReadAllLines(arquivo);
        foreach (var linha in conteudo)
        {
          var partes = linha.Split(':');
          var usuario = new Usuario(partes[0], "");
          usuario.SenhaCriptografada = partes[1];
          usuarios.Add(usuario);
        }
      }
    }

    public void AdicionarUsuario(Usuario usuario)
    {
      if (RecuperarUsuario(usuario.Login) != null)
      {
        throw new UsuarioDuplicadoException();
      }
      usuarios.Add(usuario);
    }

    public ReadOnlyCollection<Usuario> Usuarios
    {
      get
      {
        return usuarios.AsReadOnly();
      }
    }

    public void ExcluirUsuario(Usuario usuario)
    {
      usuarios.Remove(usuario);
    }

    public override string ToString()
    {
      var builder = new StringBuilder();
      foreach (var usuario in usuarios)
      {
        builder.AppendLine(usuario.ToString());
      }
      return builder.ToString();
    }

    public void Salvar()
    {
      File.WriteAllText(arquivo, ToString());
    }

    public Usuario RecuperarUsuario(string login)
    {
      return usuarios.FirstOrDefault(u => u.Login == login);
    }
  }
}

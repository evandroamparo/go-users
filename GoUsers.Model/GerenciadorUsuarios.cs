using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoUsers.Model
{
  public class GerenciadorUsuarios
  {
    private static List<Usuario> usuarios = new List<Usuario>();
    public static void AdicionarUsuario(Usuario usuario)
    {
      usuarios.Add(usuario);
    }

    public static ReadOnlyCollection<Usuario> Usuarios { get; set; }
  }
}

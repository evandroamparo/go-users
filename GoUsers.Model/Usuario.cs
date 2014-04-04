using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoUsers.Model
{
  public class Usuario
  {
    public Usuario(string login, string senha, bool admin = false)
    {
      this.Login = login;
      this.Senha = senha;
      this.Admin = admin;
    }

    public string Login { get; set; }
    public string Senha
    {
      set
      {
        SenhaCriptografada = new CriptoService().GetHash(value);
      }
    }
    public bool Admin { get; set; }
    public string SenhaCriptografada { get; set; }

    public override string ToString()
    {
      return string.Format("{0}:{1}", Login, SenhaCriptografada);
    }
  }
}

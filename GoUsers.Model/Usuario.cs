using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoUsers.Model
{
  public class Usuario
  {
    private string login;
    private string senha;
    private bool admin;
    public Usuario(string login, string senha, bool admin = false)
    {
      this.login = login;
      this.senha = senha;
      this.admin = admin;
    }

    public string Login 
    { 
      get
      {
        return login;
      }
    }

    public bool Admin
    {
      get
      {
        return admin;
      }
    }

    public string SenhaCriptografada
    {
      get
      {
        return senha;
      }
    }
  }
}

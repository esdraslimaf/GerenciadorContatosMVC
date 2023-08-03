using SistemaContatos.Data;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContactContext _db;

        public UsuarioRepository(ContactContext db)
        {
            _db = db;
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
            return usuario;
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            Usuario usuarioDB = _db.Usuarios.FirstOrDefault(c => c.Id == id);
            if (usuarioDB == null) throw new Exception("Problema com o usuário escolhido. Tente novamente!");
            return usuarioDB;
        }

        public Usuario BuscarUsuarioPorLogin(string login)
        {
            //Jogar os dois para caixa alta para não ter diferenças de letra maiúsculas com minúsculas, etc.
            return _db.Usuarios.FirstOrDefault(c => c.Login.ToUpper() == login.ToUpper()); // Obs: Temos que fazer uma validação, pois podem existir logins iguais.
        }

        public List<Usuario> BuscarUsuarios()
        {
            return _db.Usuarios.ToList();
        }

        public void EditarUsuario(Usuario usuario)
        {
            Usuario usuarioDb = BuscarUsuarioPorId(usuario.Id);
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.Email = usuario.Email;          
            usuarioDb.DataAtualizacao = DateTime.Now;
            _db.Usuarios.Update(usuarioDb);
            _db.SaveChanges();
        }

        public bool ExcluirUsuario(int id)
        {
            _db.Usuarios.Remove(BuscarUsuarioPorId(id));
            _db.SaveChanges();
            return true;
        }
    }
}

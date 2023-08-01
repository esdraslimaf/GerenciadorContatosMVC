using SistemaContatos.Models;

namespace SistemaContatos.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario AddUsuario(Usuario usuario);
        List<Usuario> BuscarUsuarios();
        Usuario BuscarUsuarioPorId(int id);
        void EditarUsuario(Usuario usuario);
        bool ExcluirUsuario(int id);
    }
}

using SistemaContatos.Models;

namespace SistemaContatos.Repository.Interfaces
{
    public interface IContatoRepository
    {
        Contato AddContato(Contato contato);
        List<Contato> BuscarContatos(int usuarioId);
        Contato BuscarContatoPorId(int id);
        void EditarContato(Contato contato);
        bool ExcluirContato(int id);
    }
}

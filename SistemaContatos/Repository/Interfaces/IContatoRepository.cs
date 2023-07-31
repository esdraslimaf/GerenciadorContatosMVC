using SistemaContatos.Models;

namespace SistemaContatos.Repository.Interfaces
{
    public interface IContatoRepository
    {
        Contato AddContato(Contato Contato);
        List<Contato> BuscarContatos();
        Contato BuscarContatoPorId(int id);
        void EditarContato(Contato contato);
        bool ExcluirContato(int id);
    }
}

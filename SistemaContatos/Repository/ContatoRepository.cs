using SistemaContatos.Data;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Repository
{
    public class ContatoRepository:IContatoRepository
    {
        private readonly ContactContext _db;

        public ContatoRepository(ContactContext db)
        {
            _db = db;
        }

        public Contato AddContato(Contato Contato)
        {
            _db.Contatos.Add(Contato);
            _db.SaveChanges();
            return Contato;
        }

        public Contato BuscarContatoPorId(int id)
        {
            Contato ContatoDB = _db.Contatos.FirstOrDefault(c => c.Id == id);
            if (ContatoDB == null) throw new Exception("Problema com o usuário escolhido. Tente novamente!");
            return ContatoDB;
        }

        public List<Contato> BuscarContatos(int usuarioId)
        {
            return _db.Contatos.Where(c => c.UsuarioId == usuarioId).ToList();
        }

        public void EditarContato(Contato contato)
        {
            Contato ContatoDb = BuscarContatoPorId(contato.Id);
            ContatoDb.Nome = contato.Nome;
            ContatoDb.Email = contato.Email;
            ContatoDb.Telefone = contato.Telefone;
            _db.Contatos.Update(ContatoDb);
            _db.SaveChanges();
        }

        public bool ExcluirContato(int id)
        {
            _db.Contatos.Remove(BuscarContatoPorId(id));
            _db.SaveChanges();
            return true;
        }
    }
}

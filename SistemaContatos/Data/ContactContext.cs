using Microsoft.EntityFrameworkCore;
using SistemaContatos.Models;

namespace SistemaContatos.Data
{
    public class ContactContext:DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }

    }
}

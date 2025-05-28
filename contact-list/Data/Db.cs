using Microsoft.EntityFrameworkCore;
using ContactsList.Models;

namespace ContactsList.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
        public DbSet<ContactsModel> Contacts { get; set; }

    }
}

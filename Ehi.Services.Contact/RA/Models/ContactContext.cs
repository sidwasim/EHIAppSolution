using System.Data.Entity;

namespace Ehi.Services.Contact.RA.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("ContactDBConn1")
        {

        }

        public DbSet<Contact> Contact { get; set; }

    }
}

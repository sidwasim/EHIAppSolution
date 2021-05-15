using System;
using System.Collections.Generic;
using System.Text;
namespace Repository.ContactDetails.RA.Models
{
    public class ContactContext : DbContext 
    {
        public ContactContext() : base()
        {

        }

        public DbSet<Contact> Students { get; set; }
    }
}

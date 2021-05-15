using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
namespace Repository.ContactDetails.RA.Models
{
    public class ContactContext : DbContext 
    {
        public ContactContext() : base("ContactDBConn1")
        {

        }

        public DbSet<Contact> Contact { get; set; }
    }
}

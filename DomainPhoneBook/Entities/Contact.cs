using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainPhoneBook.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CompanyName { get; private set; }
        public string Description { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime CreateAt { get; private set; }

        public Contact()
        {

        }

        public Contact(string FirstName, string LastName, string CompanyName, string Description, string PhoneNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CompanyName = CompanyName;
            this.Description = Description;
            this.PhoneNumber = PhoneNumber;
            CreateAt = DateTime.Now;
        }

        public void Update(string FirstName, string LastName, string CompanyName, string Description, string PhoneNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CompanyName = CompanyName;
            this.Description = Description;
            this.PhoneNumber = PhoneNumber;
        }

    }
}

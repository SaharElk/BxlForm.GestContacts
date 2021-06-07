using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.GestContacts.Models.Client.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }

        public Contact(string lastName, string firstName, string email, int categoryId)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            CategoryId = categoryId;
        }

        internal Contact(int id, string lastName, string firstName, string email, int categoryId) : this(lastName, firstName, email, categoryId)
        {
            Id = id;
        }
    }
}

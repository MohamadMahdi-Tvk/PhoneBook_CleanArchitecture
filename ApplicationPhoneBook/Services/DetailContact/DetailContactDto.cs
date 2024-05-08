﻿namespace ApplicationPhoneBook.Services.DetailContact
{
    public class DetailContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
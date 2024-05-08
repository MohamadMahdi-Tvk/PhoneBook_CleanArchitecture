using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Dto;
using DomainPhoneBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.AddNewContact
{
    public class AddNewContactService : IAddNewContactService
    {
        private readonly IDataBaseContext dataBaseContext;
        public AddNewContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(AddContactDto addContactDto)
        {
            if (string.IsNullOrEmpty(addContactDto.PhoneNumber))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "شماره موبایل اجباری می باشد"
                };
            }

            Contact contact = new Contact(addContactDto.FirstName, addContactDto.LastName,
                addContactDto.CompanyName, addContactDto.Description,
                addContactDto.PhoneNumber);

            dataBaseContext.Contacts.Add(contact);
            dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = $"مخاطب {addContactDto.FirstName} {addContactDto.LastName} با موفقیت در دیتابیس ذخیره شد"
            };
        }
    }
}

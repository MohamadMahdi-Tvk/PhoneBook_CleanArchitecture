using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.DetailContact
{
    public class DetailContactService : IDetailContactService
    {
        private readonly IDataBaseContext dataBaseContext;
        public DetailContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public ResultDto<DetailContactDto> Execute(int contactId)
        {
            var contact = dataBaseContext.Contacts.Find(contactId);
            if (contact == null)
            {
                return new ResultDto<DetailContactDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "مخاطب مورد نظر یافت نشد"
                };
            }

            var data = new DetailContactDto
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Description = contact.Description,
                PhoneNumber = contact.PhoneNumber,
                CompanyName = contact.CompanyName,
                CreateAt = contact.CreateAt
            };

            return new ResultDto<DetailContactDto>
            {
                Data = data,
                IsSuccess = true
            };
        }
    }
}

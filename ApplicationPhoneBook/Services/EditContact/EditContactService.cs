using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Dto;

namespace ApplicationPhoneBook.Services.EditContact
{
    public class EditContactService : IEditContactService
    {
        private readonly IDataBaseContext dataBaseContext;
        public EditContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(EditContactDto editContactDto)
        {

            var contact = dataBaseContext.Contacts.Find(editContactDto.Id);

            if (contact == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "مخاطب مورد نظر یافت نشد"
                };
            }

            contact.Update(editContactDto.FirstName, editContactDto.LastName, editContactDto.CompanyName, editContactDto.Description, editContactDto.PhoneNumber);
            dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "مخاطب با موفقیت ویرایش شد"
            };
        }
    }
}

using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Dto;

namespace ApplicationPhoneBook.Services.DeleteContact
{
    public class DeleteContactService : IDeleteContactService
    {
        private readonly IDataBaseContext dataBaseContext;

        public DeleteContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public ResultDto Execute(int contactId)
        {
            var contact = dataBaseContext.Contacts.Find(contactId);
            if (contact == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "مخاطب مورد نظر یافت نشد"
                };
            }

            dataBaseContext.Contacts.Remove(contact);
            dataBaseContext.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "مخاطب مورد نظر با موفقیت حذف گردید"
            };
            
        }
    }
}

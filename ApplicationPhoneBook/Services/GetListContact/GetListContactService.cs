using ApplicationPhoneBook.DataBase;

namespace ApplicationPhoneBook.Services.GetListContact
{
    public class GetListContactService : IGetListContactService
    {
        private readonly IDataBaseContext dataBaseContext;
        public GetListContactService(IDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public List<ContactListDto> Execute(string searchKey = null)
        {
            var contactQuery = dataBaseContext.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(searchKey))
            {
                contactQuery = contactQuery.Where(c => c.FirstName.Contains(searchKey) || c.LastName.Contains(searchKey)
                || c.PhoneNumber.Contains(searchKey) || c.CompanyName.Contains(searchKey)
                );
            }

            var contactList = contactQuery.Select(c => new ContactListDto
            {
                Id = c.Id,
                FullName = $"{c.FirstName} {c.LastName}",
                PhoneNumber = c.PhoneNumber
            }).ToList();

            return contactList;
        }
    }
}

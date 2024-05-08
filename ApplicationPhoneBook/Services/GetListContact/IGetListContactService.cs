using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.GetListContact
{
    public interface IGetListContactService
    {
        List<ContactListDto> Execute(string searchKey = null);
    }
}

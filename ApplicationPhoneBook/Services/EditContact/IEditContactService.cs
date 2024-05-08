using ApplicationPhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.EditContact
{
    public interface IEditContactService
    {
        public ResultDto Execute(EditContactDto editContactDto);
    }
}

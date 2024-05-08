using ApplicationPhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.DetailContact
{
    public interface IDetailContactService
    {
        ResultDto<DetailContactDto> Execute(int contactId);
    }
}

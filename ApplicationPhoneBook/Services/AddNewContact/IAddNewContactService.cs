﻿using ApplicationPhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPhoneBook.Services.AddNewContact
{
    public interface IAddNewContactService
    {
        public ResultDto Execute(AddContactDto addContactDto);
    }
}

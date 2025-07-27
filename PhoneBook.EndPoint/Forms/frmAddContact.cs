using ApplicationPhoneBook.Services.AddNewContact;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_WinForm.Forms
{
    public partial class frmAddContact : Form
    {
        private readonly IAddNewContactService addNewContactService;
        public frmAddContact(IAddNewContactService addNewContactService)
        {
            InitializeComponent();
            this.addNewContactService = addNewContactService;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            var result = addNewContactService.Execute(new AddContactDto
            {
                FirstName = txtName.Text,
                LastName = txtFamily.Text,
                PhoneNumber = txtPhoneNumber.Text,
                CompanyName = txtCompany.Text,
                Description = txtDescription.Text
            });

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

using ApplicationPhoneBook.Services.DetailContact;
using ApplicationPhoneBook.Services.EditContact;
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
    public partial class frmEdit : Form
    {
        private readonly IEditContactService editContactService;
        private readonly IDetailContactService detailContactService;
        private readonly int contactId;
        public frmEdit(int contactId, IDetailContactService detailContactService, IEditContactService editContactService)
        {
            InitializeComponent();
            this.contactId = contactId;
            this.detailContactService = detailContactService;
            this.editContactService = editContactService;

        }

        private void frmEdit_Load(object sender, EventArgs e)
        {

            var contact = detailContactService.Execute(contactId);

            if (contact.IsSuccess == false)
            {
                MessageBox.Show(contact.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                txtName.Text = contact.Data.FirstName;
                txtFamily.Text = contact.Data.LastName;
                txtPhoneNumber.Text = contact.Data.PhoneNumber;
                txtDescription.Text = contact.Data.Description;
                txtCompany.Text = contact.Data.CompanyName;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var result = editContactService.Execute(new EditContactDto
            {
                Id = contactId,
                FirstName = txtName.Text,
                LastName = txtFamily.Text,
                CompanyName = txtCompany.Text,
                Description = txtDescription.Text,
                PhoneNumber = txtPhoneNumber.Text
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

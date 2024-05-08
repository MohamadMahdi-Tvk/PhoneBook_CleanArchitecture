using ApplicationPhoneBook.Services.DetailContact;
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
    public partial class frmDetails : Form
    {
        private readonly IDetailContactService detailContactService;
        private readonly int contactId;

        public frmDetails(int contactId,IDetailContactService detailContactService)
        {
            InitializeComponent();
            this.detailContactService = detailContactService;
            this.contactId = contactId;

        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            var contact = detailContactService.Execute(contactId);
            if (contact.IsSuccess)
            {
                lblId.Text = contact.Data.Id.ToString();
                lblName.Text = contact.Data.FirstName;
                lblFamily.Text = contact.Data.LastName;
                lblPhoneNumber.Text = contact.Data.PhoneNumber;
                lblDescription.Text = contact.Data.Description;
                lblCreateDate.Text = contact.Data.CreateAt.ToString();
                lblCompany.Text = contact.Data.CompanyName;
            }
            else
            {
                MessageBox.Show(contact.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using ApplicationPhoneBook.Services.AddNewContact;
using ApplicationPhoneBook.Services.DeleteContact;
using ApplicationPhoneBook.Services.DetailContact;
using ApplicationPhoneBook.Services.EditContact;
using ApplicationPhoneBook.Services.GetListContact;
using PhoneBook.EndPoint;
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
    public partial class frmMain : Form
    {
        private readonly IGetListContactService getListContactService;
        private readonly IDeleteContactService deleteContactService;

        public frmMain(IGetListContactService getListContactService, IDeleteContactService deleteContactService)
        {
            InitializeComponent();
            this.getListContactService = getListContactService;
            this.deleteContactService = deleteContactService;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var contactList = getListContactService.Execute();

            SettingGridView(contactList);
            this.Cursor = Cursors.Default;

        }

        private void SettingGridView(List<ContactListDto> contactList)
        {
            dgvContactList.DataSource = contactList;
            dgvContactList.Columns[0].HeaderText = "شناسه";
            dgvContactList.Columns[1].HeaderText = "نام";
            dgvContactList.Columns[2].HeaderText = "شماره تلفن";

            dgvContactList.Columns[1].Width = 200;
            dgvContactList.Columns[2].Width = 200;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var contactList = getListContactService.Execute(txtSearch.Text);

            SettingGridView(contactList);

            this.Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(dgvContactList.CurrentRow.Cells[0].Value.ToString());

            var result = deleteContactService.Execute(id);
            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain_Load(null, null);
            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowDetail()
        {
            var id = int.Parse(dgvContactList.CurrentRow.Cells[0].Value.ToString());
            var servicDetail = (IDetailContactService)Program.ServiceProvider.GetService(typeof(IDetailContactService));
            frmDetails frmDetails = new frmDetails(id, servicDetail);
            frmDetails.ShowDialog();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void dgvContactList_DoubleClick(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            var serviceAdd = (IAddNewContactService)Program.ServiceProvider.GetService(typeof(IAddNewContactService));
            frmAddContact frmAddContact = new frmAddContact(serviceAdd);
            frmAddContact.ShowDialog();

            frmMain_Load(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var contactId = int.Parse(dgvContactList.CurrentRow.Cells[0].Value.ToString());

            var serviceEdit = (IEditContactService)Program.ServiceProvider.GetService(typeof(IEditContactService));
            var serviceDetail = (IDetailContactService)Program.ServiceProvider.GetService(typeof(IDetailContactService));
            frmEdit frmEdit = new frmEdit(contactId, serviceDetail, serviceEdit);
            frmEdit.ShowDialog();

            frmMain_Load(null, null);
        }
    }
}

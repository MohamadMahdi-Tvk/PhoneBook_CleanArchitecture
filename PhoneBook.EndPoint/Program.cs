using ApplicationPhoneBook.DataBase;
using ApplicationPhoneBook.Services.AddNewContact;
using ApplicationPhoneBook.Services.DeleteContact;
using ApplicationPhoneBook.Services.DetailContact;
using ApplicationPhoneBook.Services.EditContact;
using ApplicationPhoneBook.Services.GetListContact;
using Microsoft.Extensions.DependencyInjection;
using PersistencePhoneBook.Context;
using UI_WinForm.Forms;

namespace PhoneBook.EndPoint
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IAddNewContactService, AddNewContactService>();
            services.AddScoped<IGetListContactService, GetListContactService>();
            services.AddTransient<IDeleteContactService, DeleteContactService>();
            services.AddScoped<IDetailContactService, DetailContactService>();
            services.AddScoped<IEditContactService, EditContactService>();

            services.AddDbContext<DataBaseContext>();

            ServiceProvider = services.BuildServiceProvider();
        }


        [STAThread]
        static void Main()
        {
            ConfigureServices();
            ApplicationConfiguration.Initialize();


            var serviceGetList =(IGetListContactService)ServiceProvider.GetService(typeof(IGetListContactService));
            var serviceDelete =(IDeleteContactService)ServiceProvider.GetService(typeof(IDeleteContactService));
            Application.Run(new frmMain(serviceGetList,serviceDelete));
        }
    }
}
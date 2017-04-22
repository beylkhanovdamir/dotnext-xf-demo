using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Todo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Todo
{
	public partial class App 
	{
		static TodoItemDatabase database;

		public App()
		{
			InitializeComponent();

			MobileCenter.Start("ios=37ef0777-8c25-459e-95e9-19a9e5ae5220;" +
				   "android=e04e4274-9cd7-44fb-a984-70558d46eb82",
				   typeof(Analytics), typeof(Crashes));
		}

		protected override void OnStart()
		{
			var nav = new NavigationPage(new TodoListPage()
			{
				BindingContext = new TodoListPageViewModel()
			});

			MainPage = nav;

		}
		public static TodoItemDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}
	}
}
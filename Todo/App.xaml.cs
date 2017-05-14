using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
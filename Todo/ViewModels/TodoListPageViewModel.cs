using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.Annotations;
using Xamarin.Forms;

namespace Todo.ViewModels
{
	public class TodoListPageViewModel : INotifyPropertyChanged
	{
		private TodoItem _selecteditem;

		public TodoItem SelectedItem
		{
			get
			{
				return _selecteditem;
			}
			set
			{
				_selecteditem = value;
				OnPropertyChanged(nameof(SelectedItem));
			}
		}

		public ICommand LoadItemsCommand { get; set; }

		private ObservableCollection<TodoItem> _todoItems;

		public ObservableCollection<TodoItem> TodoItems
		{
			get
			{
				return _todoItems;
			}
			set
			{
				_todoItems = value;
				OnPropertyChanged(nameof(TodoItems));
			}
		}

		private bool _loading;

		public bool Loading
		{
			get
			{
				return _loading;
			}
			set
			{
				_loading = value;
				OnPropertyChanged(nameof(Loading));
			}
		}

		public ICommand AddNewItemCommand { get; set; }

		public ICommand ItemSelectedCommand { get; set; }

		public TodoListPageViewModel()
		{
			ItemSelectedCommand = new Command(async () => await OpenSelectedItem(), CanItemSelection);
			AddNewItemCommand = new Command(async () => await AddNewItem(), CanAddItem);
			LoadItemsCommand = new Command(async () => await LoadItems());
		}

		private async Task LoadItems()
		{
			Loading = true;

			TodoItems = new ObservableCollection<TodoItem>(await App.Database.GetItemsAsync());

			Loading = false;
		}

		private bool CanAddItem()
		{
			return true;
		}

		private bool CanItemSelection()
		{
			return true;
		}

		private async Task AddNewItem()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new TodoItemPage()
			{
				BindingContext = new TodoItemPageViewModel() { PageTitle = "Add new task", Item = new TodoItem() }
			});
		}

		private async Task OpenSelectedItem()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new TodoItemPage()
			{
				BindingContext = new TodoItemPageViewModel() { PageTitle = SelectedItem.Name, Item = SelectedItem }
			});
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.Annotations;
using Xamarin.Forms;

namespace Todo.ViewModels
{
	public class TodoItemPageViewModel : INotifyPropertyChanged
	{
		public ICommand DeleteCommand { get; set; }

		public ICommand SaveItemCommand { get; set; }

		public ICommand CancelItemEditingCommand { get; set; }

		public ICommand AddItemBySpeakCommand { get; set; }

		public TodoItem Item { get;set; }

		public TodoItemPageViewModel()
		{
			DeleteCommand = new Command(async () => await DeleteItem());
			SaveItemCommand = new Command(async () => await SaveItem(), CanSave);
			AddItemBySpeakCommand = new Command(AddItemBySpeak);
			CancelItemEditingCommand = new Command(async () => await Cancel());
			MessagingCenter.Subscribe<TodoItem>(this, nameof(TodoItem), obj =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					((Command)SaveItemCommand).ChangeCanExecute();
				});
			});
		}

		private bool CanSave()
		{
			return !string.IsNullOrEmpty(Item.Name);
		}

		private async Task Cancel()
		{
			await Application.Current.MainPage.Navigation.PopAsync();

		}

		private void AddItemBySpeak()
		{
			DependencyService.Get<ITextToSpeech>().Speak(Item.Name + " " + Item.Notes);
		}

		private async Task SaveItem()
		{
			await App.Database.SaveItemAsync(Item);
			await Application.Current.MainPage.Navigation.PopAsync();
		}


		private async Task DeleteItem()
		{
			await App.Database.DeleteItemAsync(Item);
			await Application.Current.MainPage.Navigation.PopAsync();

		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

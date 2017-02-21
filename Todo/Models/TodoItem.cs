using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using Todo.Annotations;
using Xamarin.Forms;

namespace Todo
{
	public class TodoItem: INotifyPropertyChanged
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		private string _name;
		public string Name {
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		private string _notes;
		public string Notes
		{
			get { return _notes; }
			set
			{
				_notes = value;
				OnPropertyChanged(nameof(Notes));
			}
		}

		private bool _done;
		public bool Done
		{
			get { return _done; }
			set
			{
				_done = value;
				OnPropertyChanged(nameof(Done));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			MessagingCenter.Send(this, nameof(TodoItem));
		}
	}
}


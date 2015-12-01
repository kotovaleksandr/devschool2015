using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DevSchool.MainApplication.Annotations;
using DevSchool.MainApplication.Model;
using DevSchool.Model;

namespace DevSchool.MainApplication.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private string _hello;
		private string _text;
		private User _selectedUser;
		private string _name;

		public string Hello
		{
			get { return _hello; }
			set
			{
				_hello = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<User> Users => new ObservableCollection<User>
		{
			new User
			{
				Email = "2111@2322.com"
			},
			new User
			{
				Email = "33331@333.com"
			}
		};

		public string Name
		{
			get { return _name; }
			set
			{
				if (value == _name)
					return;
				_name = value;
				OnPropertyChanged();
			}
		}

		public string SelectedUserEmail
		{
			get
			{
				if (SelectedUser != null)
					return SelectedUser.Email;
				return "null";
			}
		}
		public User SelectedUser
		{
			get
			{
				return _selectedUser;
			}
			set
			{
				_selectedUser = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(SelectedUserEmail));
			}
		}

		public string Text
		{
			get { return _text; }
			set
			{
				_text = value;
				Hello = value;
			}
		}

		public ICommand ChangeLable
		{
			get
			{
				return new DelegateCommand(() =>
				{
					var getUserTask = new UsersRepositoryClient().GetUser(Guid.Empty);
					getUserTask.Wait();

					Text = getUserTask.Result.Email;
				});
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class DelegateCommand : ICommand
	{
		private readonly Action _action;

		public DelegateCommand(Action action)
		{
			_action = action;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_action();
		}

		public event EventHandler CanExecuteChanged;
	}
}

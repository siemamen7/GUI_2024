using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WpfApp001.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WpfApp001.ViewModel
{
    public class MailFrameViewModel : INotifyPropertyChanged
    {
        private readonly szpitalContext _context;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _newMessage;
        public string NewMessage
        {
            get { return _newMessage; }
            set
            {
                _newMessage = value;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

        private MailContact _selectedContact;
        public MailContact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
                OnPropertyChanged(nameof(Messages)); // Refresh the messages list when the selected contact changes
            }
        }

        public ObservableCollection<MailContact> Contacts { get; set; }
        public ObservableCollection<MailMessage> Messages => new ObservableCollection<MailMessage>(SelectedContact?.Messages);

        public ICommand SendMessageCommand { get; }
        public ICommand SelectContactCommand { get; }

        public MailFrameViewModel()
        {
            _context = new szpitalContext();
            _context.Database.EnsureCreated();

            // Load contacts and messages from the database
            Contacts = new ObservableCollection<MailContact>(_context.MailContacts.Include(c => c.Messages).ToList());

            // If no contacts exist, add sample data
            if (!Contacts.Any())
            {
                Contacts.Add(new MailContact { Name = "Osoba 1" });
                Contacts.Add(new MailContact { Name = "Osoba 2" });
                Contacts.Add(new MailContact { Name = "Osoba 3" });

                // Add sample messages to each contact
                Contacts[0].Messages.Add(new MailMessage { Sender = "Osoba 1", Content = "Cześć, jak się masz?" });
                Contacts[1].Messages.Add(new MailMessage { Sender = "Osoba 2", Content = "Wszystko w porządku!" });

                // Save changes to the database
                _context.MailContacts.AddRange(Contacts);
                _context.SaveChanges();
            }

            // Set the first contact as selected by default
            SelectedContact = Contacts.FirstOrDefault();

            // Initialize commands
            SendMessageCommand = new RelayCommand(SendMessage);
            SelectContactCommand = new RelayCommand<MailContact>(SelectContact);
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(NewMessage) && SelectedContact != null)
            {
                var message = new MailMessage { Sender = "Ja", Content = NewMessage, MailContactId = SelectedContact.MailContactId };
                _context.MailMessages.Add(message);
                _context.SaveChanges();

                SelectedContact.Messages.Add(message);
                NewMessage = string.Empty; // Clear the message input
            }
        }

        private void SelectContact(MailContact contact)
        {
            SelectedContact = contact;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BooksRoutesEditor.api;
using BooksRoutesEditor.api.Models;
using BooksRoutesEditor.Annotations;

namespace BooksRoutesEditor
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private BooksRoutesApiService _apiService;
        private List<Book> _books;


        public MainViewModel()
        {
            _apiService = new BooksRoutesApiService();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public List<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged("Books");
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task Init()
        {
            Books= await _apiService.GetBooks();
        }
    }
}

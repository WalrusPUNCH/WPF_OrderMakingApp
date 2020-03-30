using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Presentation_Layer.ViewModels
{
    public class OKDialogViewModel : INotifyPropertyChanged
    {
        private string title = "default title";
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        private string message = "default message";
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }
        public OKDialogViewModel(string title, string message)
        {
            Title = title;
            Message = message;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

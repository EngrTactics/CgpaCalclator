using PropertyChanged;
using System.ComponentModel;

namespace Fasetto.word
{
    [ImplementPropertyChanged]
    /// <summary>
    /// A view model that fires property Changed event as needed.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (Sender, e) => {};

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }


}

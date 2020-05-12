using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace TvSeries
{
    public class CarouselPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<SerieTvModel> _serieTv;
        private string _pageTitle;
        public CarouselPageViewModel()
        {
            _pageTitle = "CarouselViewChallege";
            _serieTv = new ObservableCollection<SerieTvModel>();
            _serieTv.Add(new SerieTvModel { ImagePath = "https://walter.trakt.tv/images/shows/000/001/390/posters/thumb/93df9cd612.jpg.webp" });
            _serieTv.Add(new SerieTvModel { Title = "Sarus Crane"});
            _serieTv.Add(new SerieTvModel { Title = "Himalayan Monal" });
            _serieTv.Add(new SerieTvModel { Title = "Indian Peafowl" });
            _serieTv.Add(new SerieTvModel { Title = "Mrs. Gould’s Sunbird"});
            _serieTv.Add(new SerieTvModel { Title = "Oriental Dwarf Kingfisher" });
            _serieTv.Add(new SerieTvModel { Title = "Red Headed Trogon" });

        }

        public ObservableCollection<SerieTvModel> SerieTv
        {
            get
            {
                return _serieTv;
            }
            set
            {
                if (_serieTv != value)
                {
                    _serieTv = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("SerieTv"));
                }
            }
        }
        public string Title
        {
            get
            {
                return _pageTitle;
            }
            set
            {
                if (_pageTitle != value)
                {
                    _pageTitle = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Title"));
                }
            }
        }
        private void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}


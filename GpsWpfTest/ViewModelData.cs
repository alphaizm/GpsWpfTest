using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;
using GpsWpfTest.Models;

namespace GpsWpfTest.ViewModels
{
    public class ViewModelData : INotifyPropertyChanged
    {
        private ModelData _model_data;

        public ViewModelData()
        {
            _model_data = new ModelData()
            {
                _lst_location = new List<Location>()
                {
                    new Location(36.397668, 136.518854, 0)
                }
            };
        }

        public Location MapLocation
        {
            get
            {
                return _model_data._lst_location[_model_data._lst_location.Count - 1];
            }

            set
            {
                _model_data._lst_location.Add(value);
                NotifyPropertyChanged("MapLacation");
                NotifyPropertyChanged("DBG_MAP_CENTER");
            }
        }

        public string DBG_MAP_CENTER
        {
            get
            {
                StringBuilder str_ret = new StringBuilder();
                Location location = new Location(_model_data._lst_location[_model_data._lst_location.Count - 1]);

                str_ret.Append("【ViewModel】");
                str_ret.Append(location.Latitude.ToString());
                str_ret.Append(",");
                str_ret.Append(location.Longitude.ToString());

                return str_ret.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string notify_data_)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(notify_data_));
            }
        }
    }
}

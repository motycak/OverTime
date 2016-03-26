using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime
{
    public class Calculate : INotifyPropertyChanged
    {

        public Calculate()
        {
            this.StartWork = string.Format("00:00");
            this.Lunch = string.Format("00:00");
            this.ActualTime = string.Format("00:00");
            this.OverTime = string.Format("00:00");
        }



        


        public void SetActualTime()
        {
            this.ActualTime = (string)DateTime.Now.ToLocalTime().ToString("HH:mm");
        }


        #region Property


        private string _startWork;
        public string StartWork
        {
            get { return _startWork; }
            set
            {
                _startWork = value;
                this.OnPropertyChanged("StartWork");
            }
        }

        private string _lunch;
        public string Lunch
        {
            get { return _lunch; }
            set
            {
                _lunch = value;
                this.OnPropertyChanged("Lunch");
            }
        }

        private string _actualTime;
        public string ActualTime
        {
            get { return _actualTime; }
            set
            {
                _actualTime = value;
                this.OnPropertyChanged("ActualTime");
            }
        }

        private string _overTime;
        public string OverTime
        {
            get { return _overTime; }
            set
            {
                _overTime = value;
                this.OnPropertyChanged("OverTime");
            }
        }


        #endregion



        #region OnPropertyChange


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }


        #endregion


    }
}

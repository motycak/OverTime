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
        private const string DEFAULT_TIME = "00:00";
        private const string DEFAULT_HOURS = "00";

        public Calculate()
        {
            this.SetDefaultValues();
        }



        public void SetActualTime()
        {
            this.ActualTime = (string)DateTime.Now.ToLocalTime().ToString("HH:mm");
        }



        public void Clear()
        {
            this.SetDefaultValues();
        }



        public void CalculateOvertime()
        {
            try
            {
                DateTime startTime = this.GetTime(this.StartWork, "Zle zadaná hodnota čas príchodu.");
                long lunchTime = this.GetCountHours(this.Lunch, "Zle zadaná hodnota dĺžka obedu.");
                DateTime actualTime = this.GetTime(this.ActualTime, "Zle zadaná hodnota aktuálny čas.");

                long eightHours = 8 * 60 * 60000 + lunchTime;
                var workTime = actualTime - startTime;
                var workTimeMilliseconds = Math.Abs(Convert.ToInt64(workTime.TotalMilliseconds));

                if (workTimeMilliseconds > eightHours)
                {
                    TimeSpan t = TimeSpan.FromMilliseconds(workTimeMilliseconds - eightHours);
                    this.Message = string.Format("Nadčas: {0}:{1}", t.Hours, t.Minutes);
                }
                else
                {
                    TimeSpan t = TimeSpan.FromMilliseconds(eightHours - workTimeMilliseconds);
                    this.Message = string.Format("Do nadčasu ti chýba: {0}:{1}", t.Hours, t.Minutes);
                }

            }
            catch {
            }
            
        }



        private void SetDefaultValues()
        {
            this.StartWork = DEFAULT_TIME;
            this.Lunch = DEFAULT_HOURS;
            this.SetActualTime();
            this.OverTime = DEFAULT_TIME;
        }



        private DateTime GetTime(string time, string errorMessage)
        {
            try
            {
                return Convert.ToDateTime(time);
            }
            catch {
                this.Message = errorMessage;
                throw new Exception();
            }
        }



        private long GetCountHours(string time, string errorMessage)
        {
            try
            {
                return Convert.ToInt64(time) * 60000;
            }
            catch
            {
                this.Message = errorMessage;
                throw new Exception();
            }
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


        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                this.OnPropertyChanged("Message");
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

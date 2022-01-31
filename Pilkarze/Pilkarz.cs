using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pilkarze
{
    public class Pilkarz : INotifyPropertyChanged
    {

        private int _Id;

        public int Id
        {
            get { return this._Id; }
            set
            {
                if (this._Id != value)
                {
                    this._Id = value;
                    this.NotifyPropertyChanged("Id");
                }
            }
        }

        private string _Imie;

        public string Imie
        {
            get { return this._Imie; }
            set
            {
                if (this._Imie != value)
                {
                    this._Imie = value;
                    this.NotifyPropertyChanged("Imie");
                }
            }
        }

        private string _Nazwisko { get; set; }

        public string Nazwisko
        {
            get { return this._Nazwisko; }
            set
            {
                if (this._Nazwisko != value)
                {
                    this._Nazwisko = value;
                    this.NotifyPropertyChanged("Nazwisko");
                }
            }
        }

        private string _Wiek;

        public string Wiek
        {
            get { return this._Wiek; }
            set
            {
                if (this._Wiek != value)
                {
                    this._Wiek = value;
                    this.NotifyPropertyChanged("Wiek");
                }
            }
        }


        private string _Pozycja;

        public string Pozycja
        {
            get { return this._Pozycja; } 
            set
            {
                if (this._Pozycja != value)
                {
                    this._Pozycja = value;
                    this.NotifyPropertyChanged("Pozycja");
                }
            }
        }


        private string _Cena;

        public string Cena
        {
            get { return this._Cena; }
            set
            {
                if (this._Cena != value)
                {
                    this._Cena = value;
                    this.NotifyPropertyChanged("Cena");
                }
            }
        }


        private string _Klub;

        public string Klub
        {
            get { return this._Klub; }
            set
            {
                if (this._Klub != value)
                {
                    this._Klub = value;
                    this.NotifyPropertyChanged("Klub");
                }
            }
        }


        private string _Reprezentacja;

        public string Reprezentacja
        {
            get { return this._Reprezentacja; }
            set
            {
                if (this._Reprezentacja != value)
                {
                    this._Reprezentacja = value;
                    this.NotifyPropertyChanged("Reprezentacja");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

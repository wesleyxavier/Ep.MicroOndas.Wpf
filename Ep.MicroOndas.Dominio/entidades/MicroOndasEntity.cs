using System.ComponentModel;

namespace Ep.MicroOndas.Dominio.entidades
{
    public class MicroOndasEntity : INotifyPropertyChanged
    {
        private int[] _intervaloPotencia = new int[2] { 1, 10 };
        private int[] _intervaloTempoSegundos = new int[2] { 1, 120 };

        private string tempo;
        private string potencia;
        private string status;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public int[] GetIntervaloPotencia => _intervaloPotencia;
        public int[] GetIntervaloTempoSegundos => _intervaloTempoSegundos;

        public MicroOndasEntity() { }

        public static MicroOndasEntity InstanciaInicio => new MicroOndasEntity();

        public static MicroOndasEntity InstanciaInicioRapido =>
         new MicroOndasEntity()
         {
             Tempo = "30",
             Potencia = "8"
         };

        public string Tempo
        {
            get => tempo; set
            {
                tempo = value;
                OnPropertyChanged("Tempo");
            }
        }

        public string Potencia
        {
            get => potencia; set
            {
                potencia = value;
                OnPropertyChanged("Potencia");
            }
        }
        public string Status
        {
            get => status; set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public MicroOndasEntity SetTempo(string tempo)
        {
            Tempo = tempo;
            return this;
        }

        public MicroOndasEntity SetPotencia(string potencia)
        {
            Potencia = potencia;
            return this;
        }

        public MicroOndasEntity SetStatus(string status)
        {
            Status = status;
            return this;
        }
    }
}

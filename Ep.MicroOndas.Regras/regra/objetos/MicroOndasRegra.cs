using Ep.MicroOndas.Dominio.entidades;
using Ep.MicroOndas.Regras.regra.interfaces;
using Ep.MicroOndas.Regras.state;
using System;
using System.Timers;

namespace Ep.MicroOndas.Regras.regra.objetos
{
    public class MicroOndasRegra : IMicroOndasRegra
    {
        private const string POTENCIA_PADRAO = "10";

        private string _adicionalTempo = string.Empty;

        private int _contador = 0;

        private Timer _timer;
        private AbstractMicroOndaState _estado;
        private MicroOndasEntity _microOndas;
        private bool TempoExecucaoFinalizado => _contador >= int.Parse(_microOndas.Tempo);
        public MicroOndasRegra()
        {
            
        }
        public MicroOndasEntity GetMicroOndas => _microOndas;
        public void EstabelecerEstado(AbstractMicroOndaState estado)
        {
            _estado = estado;
            _microOndas.SetStatus(_estado.Status);
            Console.WriteLine(_estado.Status);
        }

        /// <summary>
        /// Irá para validar os parametros
        /// Irá Configurar
        /// </summary>
        /// <param name="tempo"></param>
        /// <param name="potencia"></param>
        public void Iniciar()
        {
            _timer = new Timer();
            #region Validar
            TempoValidar(_microOndas?.Tempo, _microOndas?.GetIntervaloTempoSegundos);
            PotenciaValidar(_microOndas?.Potencia, _microOndas?.GetIntervaloPotencia);
            #endregion

            ConfigurarPotenciaPadrao();
            ConfigurarAtualizacao();
        }
        public void ConfigureMicroOndas(MicroOndasEntity microOndas)
        {
            _microOndas = microOndas;
        }
        public void StatusInicial()
        {
            _estado = MicroOndaStateDesligado.Instancia();
            _estado.Desligar(this);
        }
        public void Ligar()
        {
            _estado.Ligar(this);
            _timer.Start();
        }
        public void Desligar()
        {
            _estado.Desligar(this);
            _timer.Stop();
            _timer.Dispose();
        }
        public static void TempoValidar(string tempo, int[] intervalo)
        {
            if (string.IsNullOrEmpty(tempo) || !int.TryParse(tempo, out int inttempo))
            {
                throw new ArgumentException("Necessário Configurar o tempo");
            }
            else
            {
                const int inicio = 0;
                const int fim = 1;
                if (int.Parse(tempo) < intervalo[inicio] || int.Parse(tempo) > intervalo[fim])
                {
                    throw new ArgumentException("Tempo fora de intervalo válido");
                }
            }
        }
        public static void PotenciaValidar(string potencia, int[] intervalo)
        {
            if (int.TryParse(potencia, out int intpontencia))
            {
                const int inicio = 0;
                const int fim = 1;
                if (intpontencia < intervalo[inicio] || intpontencia > intervalo[fim])
                {
                    throw new ArgumentException("Potencia fora de intervalo válido");
                }
            }
        }
        private void ConfigurarPotenciaPadrao()
        {
            var potencia = !string.IsNullOrEmpty(_microOndas?.Potencia)
                ? _microOndas?.Potencia
                : POTENCIA_PADRAO;

            _microOndas.SetPotencia(potencia);
        }
        private void ConfigurarAtualizacao()
        {
            _timer.Interval = 1000;
            _timer.Elapsed += EventoTimer;
        }
        private void AtualizarAdicional()
        {
            var potencia = int.Parse(_microOndas.Potencia);
            for (var i = 0; i < potencia; i++) _adicionalTempo += ".";
        }
        private void EventoTimer(object item, ElapsedEventArgs evento)
        {
            _contador++;
            AtualizarAdicional();
            Console.WriteLine($"Tempo: {_microOndas.Tempo}{_adicionalTempo}");
            ValidarFinalizar();
        }

        private void ValidarFinalizar()
        {
            if (TempoExecucaoFinalizado)
            {
                _estado.Aquecida(this);
                Reset();
                Desligar();
            }
        }

        private void Reset()
        {
            _adicionalTempo = string.Empty;
            _contador = 0;
            _microOndas.SetTempo(null);
            _microOndas.SetPotencia(null);
        }
    }
}

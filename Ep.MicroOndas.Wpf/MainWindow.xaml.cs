using Ep.MicroOndas.Dominio.entidades;
using Ep.MicroOndas.Servicos.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ep.MicroOndas.Wpf
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MicroOndasEntity viewMicroOndasEntity;

        private readonly IMicroOndasServico _microOndasService;
        public MainWindow()
        {
            Close();
        }

        public MainWindow(IMicroOndasServico microOndasService)
        {
            InitializeComponent();

            _microOndasService = microOndasService;
            viewMicroOndasEntity = _microOndasService.ConfiguracaoInicialMicroOndas();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            this.DataContext = viewMicroOndasEntity;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _microOndasService.Inicio(viewMicroOndasEntity);
            this.DataContext = viewMicroOndasEntity;
        }
        private void ButtonRapido_Click(object sender, RoutedEventArgs e)
        {
            viewMicroOndasEntity = MicroOndasEntity.InstanciaInicioRapido;
            _microOndasService.Inicio(viewMicroOndasEntity);
            this.DataContext = viewMicroOndasEntity;
        }
    }
}

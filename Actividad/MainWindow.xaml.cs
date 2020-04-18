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
using Actividad.Models;

namespace Actividad
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClsDatos obj = new ClsDatos();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            System.Console.Write("It's work");
        }

        private void cboAnioPedido_Loaded(object sender, RoutedEventArgs e)
        {
            List<Pedido> pedidos = obj.ListarPedidoFecha();
            //cbo show
            List<string> dataAnio = new List<string>();
            foreach (var pedido in pedidos)
            {
                dataAnio.Add(pedido.Anio);
            }
            cboAnioPedido.ItemsSource = dataAnio;
        }

        private void cboAnioPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            List<Pedido> pedidos = obj.ListarPedidoFecha(text);
            // cbo show
            List<string> dataMes = new List<string>();
            foreach (var pedido in pedidos)
            {
                dataMes.Add(pedido.Mes);
            }
            cboMesPedido.ItemsSource = dataMes;

        }

        private void cboMesPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string anio = cboAnioPedido.Text;
            string mes = cboMesPedido.Text;

            List<Empleado> empleados = obj.ListarEmpleados(mes, anio);
            // cbo show
            List<string> dataEmpleado = new List<string>();
            foreach (var empleado in empleados)
            {
                dataEmpleado.Add(empleado.Apellidos + " " + empleado.Nombre);
            }
            cboEmpleado.ItemsSource = dataEmpleado;

        }

        private void cboEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnMostrarLista(object sender, RoutedEventArgs e)
        {

        }
    }
}

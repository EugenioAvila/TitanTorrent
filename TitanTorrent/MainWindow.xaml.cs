using System.Linq;
namespace TitanTorrent
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        #region variables globales
        System.Collections.Generic.List<Herramientas.ClasesCustom.CustomPlataformas> _plataformas;
        System.Collections.Generic.List<Herramientas.ClasesCustom.CustomCategorias> _categorias;
        #endregion
        public MainWindow()
        {
            #region inicializa plataformas
            _plataformas = new System.Collections.Generic.List<Herramientas.ClasesCustom.CustomPlataformas>();
            _plataformas.Add(new Herramientas.ClasesCustom.CustomPlataformas() { DESCRIPCION = "CONCEN", ID = 1 });
            #endregion

            #region inicializa categorias
            _categorias = new System.Collections.Generic.List<Herramientas.ClasesCustom.CustomCategorias>();
            _categorias.Add(new Herramientas.ClasesCustom.CustomCategorias() { DESCRIPCION = "TODO", ID = 1, ID_PLATAFORMA = 1 });
            #endregion

            InitializeComponent();

            cmbPlataformas.DisplayMemberPath = "DESCRIPCION";
            cmbPlataformas.ItemsSource = _plataformas;
        }

        public static void InicializaCombos()
        {
            try
            {

            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        private void cmbPlataformas_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                var _seleccion = ((sender as System.Windows.Controls.ComboBox).SelectedItem as Herramientas.ClasesCustom.CustomPlataformas);
                if (_seleccion != null)
                {
                    cmbCategorias.DisplayMemberPath = "DESCRIPCION";
                    cmbCategorias.ItemsSource = (from x in _categorias where x.ID_PLATAFORMA == _seleccion.ID select x);
                    cmbCategorias.SelectedIndex = 0;
                }
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var _plataformaElegida = (cmbPlataformas.SelectedItem as Herramientas.ClasesCustom.CustomPlataformas);
                var _categoriaElegida  = (cmbCategorias.SelectedItem as Herramientas.ClasesCustom.CustomCategorias);
                if (_plataformaElegida is null || _categoriaElegida is null)
                {
                    System.Windows.MessageBox.Show("Seleccione plataforma y categoria");
                    return;
                }
            }
            catch (System.Exception exc)
            {
                throw;
            }
        }
    }
}
using System.Linq;
using System.Net;
using System.Net.Http;

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
            _plataformas = new System.Collections.Generic.List<Herramientas.ClasesCustom.CustomPlataformas>
            {
                new Herramientas.ClasesCustom.CustomPlataformas() { DESCRIPCION = "CONCEN", ID = 1 }
            };
            #endregion

            #region inicializa categorias
            _categorias = new System.Collections.Generic.List<Herramientas.ClasesCustom.CustomCategorias>
            {
                new Herramientas.ClasesCustom.CustomCategorias() { DESCRIPCION = "TODO", ID = 1, ID_PLATAFORMA = 1 }
            };
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
                if (((sender as System.Windows.Controls.ComboBox).SelectedItem as Herramientas.ClasesCustom.CustomPlataformas) != null)
                {
                    cmbCategorias.DisplayMemberPath = "DESCRIPCION";
                    cmbCategorias.ItemsSource = (from x in _categorias where x.ID_PLATAFORMA == ((sender as System.Windows.Controls.ComboBox).SelectedItem as Herramientas.ClasesCustom.CustomPlataformas).ID select x);
                    cmbCategorias.SelectedIndex = 0;
                }
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }

        private async void Buscar(Herramientas.ClasesCustom.CustomPlataformas _plataforma, Herramientas.ClasesCustom.CustomCategorias _categoria)
        {
            try
            {
                var _cliente = new HttpClient();
                byte[] _respuesta = new byte[] { };
                string source = string.Empty;
                HtmlAgilityPack.HtmlDocument _doc = null;
                System.Collections.Generic.List<Herramientas.ClasesCustom.CustomContenido> _contenido = new System.Collections.Generic.List<Herramientas.ClasesCustom.CustomContenido>();
                System.Collections.Generic.List<string> _urls = new System.Collections.Generic.List<string>();

                switch (_plataforma.ID)
                {
                    case 1:
                        _respuesta = await _cliente.GetByteArrayAsync("https://concen.org/torrents");
                        source = System.Text.Encoding.GetEncoding("utf-8").GetString(_respuesta, 0, _respuesta.Length - 1);
                        source = WebUtility.HtmlDecode(source);
                        _doc = new HtmlAgilityPack.HtmlDocument();
                        _doc.LoadHtml(source);

                        break;
                    default:
                        break;
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
                if ((cmbPlataformas.SelectedItem as Herramientas.ClasesCustom.CustomPlataformas) is null || (cmbCategorias.SelectedItem as Herramientas.ClasesCustom.CustomCategorias) is null)
                {
                    System.Windows.MessageBox.Show("Seleccione plataforma y categoria");
                    return;
                }

                Buscar((cmbPlataformas.SelectedItem as Herramientas.ClasesCustom.CustomPlataformas), (cmbCategorias.SelectedItem as Herramientas.ClasesCustom.CustomCategorias));
            }
            catch (System.Exception exc)
            {
                throw exc;
            }
        }
    }
}
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Etiquetador
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _availableLanguages = { "cs", "en", "es" };
        private int _currentLanguageIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeToCzech(object sender, RoutedEventArgs e)
        {
            LocalizationManager.Instance.LoadLanguage("cs");
        }

        private void ChangeToEnglish(object sender, RoutedEventArgs e)
        {
            LocalizationManager.Instance.LoadLanguage("en");
        }

        private void ChangeToSpanish(object sender, RoutedEventArgs e)
        {
            LocalizationManager.Instance.LoadLanguage("es");
        }

        private void btnToogleLanguage_Click(object sender, RoutedEventArgs e)
        {
            _currentLanguageIndex = (_currentLanguageIndex + 1) % _availableLanguages.Length;
            LocalizationManager.Instance.LoadLanguage(_availableLanguages[_currentLanguageIndex]);
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
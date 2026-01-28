using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Etiquetador
{
    class LocalizationManager : INotifyPropertyChanged

    {
        private static LocalizationManager _instance;
        private Dictionary<string, string> _translations;
        private string _currentLanguage;

        public static LocalizationManager Instance => _instance ??= new LocalizationManager();

        public event PropertyChangedEventHandler PropertyChanged;

        private LocalizationManager()
        {
            LoadLanguage("cs"); // Výchozí jazyk
        }

        public string this[string key]
        {
            get
            {
                if (_translations != null && _translations.ContainsKey(key))
                    return _translations[key];
                return $"[{key}]"; // Pokud klíč neexistuje
            }
        }

        public void LoadLanguage(string languageCode)
        {
            _currentLanguage = languageCode;
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages", $"{languageCode}.json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                OnPropertyChanged(string.Empty); // Notifikuje všechny bindingy
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    

}
}

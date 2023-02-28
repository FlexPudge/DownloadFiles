using DownloadFiles.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace DownloadFiles
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private string _urlAddress;
        public string UrlAddress
        {
            get { return _urlAddress; }
            set { _urlAddress = value; OnPropertyChanged(nameof(UrlAddress)); }
        }
        public string HTML { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UrlAddress != null)
            {
                GetHTML();
            } 
        }
        private void GetHTML()
        {
            HTML = new GetRequest(UrlAddress).Response;
        }
    }
}

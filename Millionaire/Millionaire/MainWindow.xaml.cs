using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Millionaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Questions? questions;
        private readonly string dataPath = "../../../data/questions.json";

        public MainWindow()
        {
            InitializeComponent();
            string json = File.ReadAllText(this.dataPath);
            this.questions = JsonSerializer.Deserialize<Questions>(json);
        }
    }
}

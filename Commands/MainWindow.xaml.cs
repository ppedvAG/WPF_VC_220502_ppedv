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

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenCmd = new CustomCommand
                (
                    p => new MainWindow().Show(),
                    p => true
                );

            this.DataContext = this;
        }

        private void DeleteCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (e.OriginalSource as TextBox).Text = "";
        }

        private void DeleteCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty((e.OriginalSource as TextBox).Text);
        }

        public CloseCommand CloseCmd { get; set; } = new CloseCommand();

        public CustomCommand OpenCmd { get; set; }

        public static RoutedUICommand MyCmd { get; set; } = new RoutedUICommand("Mein Command", "My Command", typeof(MainWindow));
    }
}

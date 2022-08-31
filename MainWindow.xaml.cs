using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();

            users.Add(new User() { Name = "Wojciech Cholewiński" });
            users.Add(new User() { Name = "Jan Nowak" });
            users.Add(new User() { Name = "Kuba Klawiter" });
            users.Add(new User() { Name = "Mateusz Kowalski" });

            lbUsers.ItemsSource = users;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtbx.Text != string.Empty)
            {
                if (txtbx.Text == "Wpisz imię")
                {
                    return;
                }

                users.Add(new User() { Name = txtbx.Text });
                txtbx.Clear();
            }else
            txtbx.Text = "Wpisz imię";
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx.Text != string.Empty)
            {
                if (txtbx.Text == "Wpisz imię")
                {
                    return;
                }

                if (lbUsers.SelectedItem != null)
                    (lbUsers.SelectedItem as User).Name = txtbx.Text;
                txtbx.Clear();
            }else
            txtbx.Text = "Wpisz imię";
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
                users.Remove(lbUsers.SelectedItem as User);
        }

    }

    public class User : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

}


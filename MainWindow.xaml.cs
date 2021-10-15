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
using MahApps.Metro.Controls;
using System.Data.SQLite;
using uchet.Connection;
using System.Data;

namespace uchet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow

    {
        public SQLiteConnection myConn;
        public SQLiteCommand myComm;
        public SQLiteDataReader myReader;

        public MainWindow()
        {
            InitializeComponent();

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmpl addEmpl = new AddEmpl();
            addEmpl.Owner = this;
            addEmpl.ShowDialog();


        }

        private void BtnTrack_Click(object sender, RoutedEventArgs e)
        {
            Tracker tracker = new Tracker();
            tracker.Owner = this;
            tracker.Show();
        }
        public void refresh()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM Employee");
                    command.ExecuteNonQuery();

                    var dataTable = new DataTable("Employee");
                    var sqlAdapter = new SQLiteDataAdapter(command);
                    sqlAdapter.Fill(dataTable);

                    DGAllEmp.ItemsSource = dataTable.DefaultView;
                    sqlAdapter.Update(dataTable);

                    sqlite_datareader = command.ExecuteReader();

                    while (sqlite_datareader.Read())
                    {
                        FN = sqlite_datareader["FirstName"];
                        SN = sqlite_datareader["S"].ToString();
                        CharacterId = sqlite_datareader["CharacterId "];
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

            }
        }
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data.SQLite;
using uchet.Connection;

namespace uchet
{
    /// <summary>
    /// Логика взаимодействия для AddEmpl.xaml
    /// </summary>
    public partial class AddEmpl : MetroWindow
    {
        
        public AddEmpl()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConnection.myConn))
            {
                connection.Open();
                string query = $@"";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                
            }
        }
    }
}


using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace _05_DisconnectedMode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn = null;
        private SqlDataAdapter da = null;
        private DataSet set = null;
        public MainWindow()
        {
            InitializeComponent();
            var connection = ConfigurationManager.ConnectionStrings["SportShopDbConnection"].ConnectionString;
            conn = new SqlConnection(connection);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = @"select * from Products";
                da = new SqlDataAdapter(sql, conn);
                new SqlCommandBuilder(da);

                set = new DataSet();

                da.Fill(set,"Products");

                dataGrid.ItemsSource = set.Tables["Products"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                da.Update(set, "Products");
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = @"select * from Clients";
                da = new SqlDataAdapter(sql, conn);
                new SqlCommandBuilder(da);

                set = new DataSet();

                da.Fill(set, "Clients");

                dataGrid.ItemsSource = set.Tables["Clients"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = @"select * from Employees";
                da = new SqlDataAdapter(sql, conn);
                new SqlCommandBuilder(da);

                set = new DataSet();

                da.Fill(set, "Employees");

                dataGrid.ItemsSource = set.Tables["Employees"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = @"select * from Salles";
                da = new SqlDataAdapter(sql, conn);
                new SqlCommandBuilder(da);

                set = new DataSet();

                da.Fill(set, "Salles");

                dataGrid.ItemsSource = set.Tables["Salles"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                da.Update(set, "Clients");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                da.Update(set, "Employees");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                da.Update(set, "Salles");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
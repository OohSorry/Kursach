using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmacy
{
    public partial class NewItem : Form
    {
        public NewItem()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //очистить поля
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //добавить в бд
            string namePharmacy = textBox1.Text;
            string nameDrug = textBox2.Text;
            string nameCategory = textBox3.Text;
            string Recipe = textBox4.Text;
            string Quantity = textBox5.Text;
            string Price = textBox6.Text;
            string City = textBox7.Text;
            string Street = textBox8.Text;
            string manCountry = textBox9.Text;
            string nameManufacturer = textBox10.Text;

            DbPharmacy pharmacy = new DbPharmacy();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            pharmacy.OpenConnection();


            MySqlCommand cmd = new MySqlCommand("INSERT INTO `AllData` (namePharmacy,nameDrug,nameCategory,Recipe,Quantity,Price,City,Street,manCountry,nameManufacturer) " +
                "VALUES (@namePharmacy, @nameDrug, @nameCategory, @Recipe, @Quantity, @Price, @City, @Street, @manCountry, @nameManufacturer)", pharmacy.GetConnection());

            cmd.Parameters.Add("@namePharmacy", MySqlDbType.String).Value = textBox1.Text;
            cmd.Parameters.Add("@nameDrug", MySqlDbType.String).Value = textBox2.Text;
            cmd.Parameters.Add("@nameCategory", MySqlDbType.String).Value = textBox3.Text;
            cmd.Parameters.Add("@Recipe", MySqlDbType.Int32).Value = textBox4.Text;
            cmd.Parameters.Add("@Quantity", MySqlDbType.Int32).Value = textBox5.Text;
            cmd.Parameters.Add("@Price", MySqlDbType.Int32).Value = textBox6.Text;
            cmd.Parameters.Add("@City", MySqlDbType.String).Value = textBox7.Text;
            cmd.Parameters.Add("@Street", MySqlDbType.String).Value = textBox8.Text;
            cmd.Parameters.Add("@manCountry", MySqlDbType.String).Value = textBox9.Text;
            cmd.Parameters.Add("@nameManufacturer", MySqlDbType.String).Value = textBox10.Text;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            MessageBox.Show("База данных была дополнена.");

            pharmacy.CloseConnection();

        }
    }
}

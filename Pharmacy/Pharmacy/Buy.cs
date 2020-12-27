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
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DbPharmacy pharmacy = new DbPharmacy();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            pharmacy.OpenConnection();
            string upd = "UPDATE `AllData` SET Quantity = Quantity - " + int.Parse(textBox2.Text) + " WHERE nameDrug = '" + textBox1.Text + "'";


            try
            {
                MySqlCommand cmd = new MySqlCommand(upd, pharmacy.GetConnection());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Спасибо за покупку.");
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pharmacy.CloseConnection();

        }
    }
}

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
    public partial class PharmMenu : Form
    {
        public PharmMenu()
        {
            InitializeComponent();
        }


        private void PharmMenu_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator2_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //загрузить данные в главную таблицу
            DbPharmacy pharmacy = new DbPharmacy();

            dataGridView1.Rows.Clear();

            pharmacy.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT* FROM `AllData`", pharmacy.GetConnection());
            MySqlDataReader mdr = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (mdr.Read())
            {

                data.Add(new string[10]);

                data[data.Count - 1][0] = mdr[0].ToString();
                data[data.Count - 1][1] = mdr[1].ToString();
                data[data.Count - 1][2] = mdr[2].ToString();
                data[data.Count - 1][3] = mdr[3].ToString();
                data[data.Count - 1][4] = mdr[4].ToString();
                data[data.Count - 1][5] = mdr[5].ToString();
                data[data.Count - 1][6] = mdr[6].ToString();
                data[data.Count - 1][7] = mdr[7].ToString();
                data[data.Count - 1][8] = mdr[8].ToString();
                data[data.Count - 1][9] = mdr[9].ToString();

            }
            mdr.Close();

            pharmacy.CloseConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //поиск по лекарству
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            NewItem newForm = new NewItem();
            newForm.Show();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            Buy newForm = new Buy();
            newForm.Show();

        }
    }
}
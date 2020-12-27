using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Pharmacy
{
    class DbPharmacy
    {

        // Подключение к веб базе данных
        MySqlConnection Connection = new MySqlConnection("server=xxz.nz;port=3306;username=Emurina;password=auwrr0xff;database=pharmacy");

        public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();
        }

        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }

        public MySqlConnection GetConnection()
        { return Connection; }

    }
}

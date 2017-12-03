using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BustosApartment_SAD_
{

    class Class1
    {
    
        MySqlConnection conn;
    

        public void insert(String a) {
            conn = new MySqlConnection("Server=localhost;Database=ba_db;uid=root; pwd =root; ");
            conn.Open();
            MySqlCommand comm = new MySqlCommand(a, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

    }
}

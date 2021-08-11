using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BUS
{
    public class KetNoi
    {
        private SqlConnection cnn;
        public KetNoi()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=TA_CUONG\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True";
            cnn.Open();
        }
        public void DongKetNoi()
        {
            if(cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
        public DataTable GetTable(string sql)
        {
            DataTable dt=new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql, cnn);
            sda.Fill(dt);
            DongKetNoi();
            return dt;
        }
        public void ExecuteQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            DongKetNoi();
        }
        public SqlDataReader GetData(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql,cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI
{
    public partial class ChuyenNganh : Form
    {
        string maCN;
        public ChuyenNganh()
        {
            InitializeComponent();
        }

        private void ChuyenNganh_Load(object sender, EventArgs e)
        {
            LoadListChuyenNganh();
            SetTableChuyenNganh();
            LoadMaCN();
        }
        private void LoadListChuyenNganh()
        {
            dgv_chuyenNganh.DataSource = new KetNoi().GetTable("SELECT * FROM ChuyenNganh");
        }
        private void SetTableChuyenNganh()
        {
            string[] nameCol = { "Mã Chuyên Ngành", "Tên Chuyên Ngành"};
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_chuyenNganh.Columns[i].HeaderText = nameCol[i];
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            LoadMaCN();
            ChuyenNganh_DTO cn_dto = new ChuyenNganh_DTO();
            cn_dto.MaCN = txt_maCN.Text;
            cn_dto.TenCN = txt_tenCN.Text;
            ChuyenNganh_BUS cn_bus = new ChuyenNganh_BUS();
            try
            {
                cn_bus.Them(cn_dto);
                LoadListChuyenNganh();
                LoadMaCN();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (maCN != null)
            {
                ChuyenNganh_DTO cn_dto = new ChuyenNganh_DTO();
                cn_dto.MaCN = txt_maCN.Text;
                cn_dto.TenCN = txt_tenCN.Text;
                ChuyenNganh_BUS cn_bus = new ChuyenNganh_BUS();
                DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Chuyên Ngành", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sua == DialogResult.No)
                    return;
                try
                {
                    cn_bus.Sua(cn_dto);
                    LoadListChuyenNganh();
                    maCN = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Hãy chọn một bản ghi!");
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (maCN != null)
            {
                ChuyenNganh_DTO cn_dto = new ChuyenNganh_DTO();
                cn_dto.MaCN = txt_maCN.Text;
                ChuyenNganh_BUS cn_bus = new ChuyenNganh_BUS();
                DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Chuyên Ngành", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xoa == DialogResult.No)
                    return;
                try
                {
                    cn_bus.Xoa(cn_dto);
                    LoadListChuyenNganh();
                    maCN = null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Hãy chọn một bản ghi!");
        }

        private void LoadMaCN()
        {
            string maCN = KiemTraMaDauTien("SELECT *From ChuyenNganh WHERE maCN='CN000'") ? MaTuDong("SELECT TOP 1 maCN FROM ChuyenNganh ORDER BY maCN DESC", "CN") : "CN000";
            txt_maCN.Text = maCN;
        }

        #region Get mã tự động
        // Get mã tự động
        public string MaTuDong(string sqlSelect, string loaiMa)
        {
            string maNV, phanSo;
            int number = 0;
            maNV = new KetNoi().GetTable(sqlSelect).Rows[0][0].ToString();
            phanSo = maNV.Substring(loaiMa.Length, 3).ToString(); ;
            number = int.Parse(phanSo);
            number++;
            if (number < 10)
                return loaiMa + "00" + number.ToString();
            else if (number >= 10 && number < 100)
                return loaiMa.ToString() + "0" + number.ToString();
            return loaiMa + number.ToString();
        }
        public bool KiemTraMaDauTien(string sqlSelect)
        {
            DataTable dt = new KetNoi().GetTable(sqlSelect);
            if (dt.Rows.Count == 1)
                return true;
            return false;
        }
        #endregion

        private void dgv_chuyenNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = e.RowIndex;
            if (currentRow >= dgv_chuyenNganh.RowCount - 1)
            {
                maCN = null;
                return;
            }
            try
            {
                txt_maCN.Text = dgv_chuyenNganh.Rows[currentRow].Cells[0].Value.ToString();
                txt_tenCN.Text = dgv_chuyenNganh.Rows[currentRow].Cells[1].Value.ToString();
                maCN = txt_maCN.Text;
            }
            catch (Exception ex)
            {
                maCN = null;
            }
        }

        private void btn_capNhat_Click(object sender, EventArgs e)
        {
            LoadListChuyenNganh();
            LoadMaCN();
            txt_tenCN.Text = "";
        }
    }
}

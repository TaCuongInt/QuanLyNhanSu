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
    public partial class TrinhDo : Form
    {
        string maTD;
        public TrinhDo()
        {
            InitializeComponent();
        }

        private void TrinhDo_Load(object sender, EventArgs e)
        {
            LoadListTrinhDo();
            SetTableTrinhDo();
            LoadMaTD();
        }
        private void LoadListTrinhDo()
        {
            dgv_trinhDo.DataSource = new KetNoi().GetTable("SELECT * FROM TrinhDo");
        }
        private void SetTableTrinhDo()
        {
            string[] nameCol = { "Mã Trình Độ", "Tên Trình Độ" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_trinhDo.Columns[i].HeaderText = nameCol[i];
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            LoadMaTD();
            TrinhDo_DTO td_dto = new TrinhDo_DTO();
            td_dto.MaTD = txt_maTD.Text;
            td_dto.TenTD = txt_tenTD.Text;
            TrinhDo_BUS td_bus = new TrinhDo_BUS();
            try
            {
                td_bus.Them(td_dto);
                LoadListTrinhDo();
                LoadMaTD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (maTD != null)
            {
                TrinhDo_DTO td_dto = new TrinhDo_DTO();
                td_dto.MaTD = txt_maTD.Text;
                td_dto.TenTD = txt_tenTD.Text;
                TrinhDo_BUS td_bus = new TrinhDo_BUS();
                DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Trình Độ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sua == DialogResult.No)
                    return;
                try
                {
                    td_bus.Sua(td_dto);
                    LoadListTrinhDo();
                    maTD = null;
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
            if (maTD != null)
            {
                TrinhDo_DTO td_dto = new TrinhDo_DTO();
                td_dto.MaTD = txt_maTD.Text;
                TrinhDo_BUS td_bus = new TrinhDo_BUS();
                DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Trình Độ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xoa == DialogResult.No)
                    return;
                try
                {
                    td_bus.Xoa(td_dto);
                    LoadListTrinhDo();
                    maTD = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Hãy chọn một bản ghi!");
        }

        private void LoadMaTD()
        {
            string maTD = KiemTraMaDauTien("SELECT *From TrinhDo WHERE maTD='TD000'") ? MaTuDong("SELECT TOP 1 maTD FROM TrinhDo ORDER BY maTD DESC", "TD") : "TD000";
            txt_maTD.Text = maTD;
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

        private void dgv_trinhDo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = e.RowIndex;
            if (currentRow >= dgv_trinhDo.RowCount - 1)
            {
                maTD = null;
                return;
            }
            try
            {
                txt_maTD.Text = dgv_trinhDo.Rows[currentRow].Cells[0].Value.ToString();
                txt_tenTD.Text = dgv_trinhDo.Rows[currentRow].Cells[1].Value.ToString();
                maTD = txt_maTD.Text;
            }
            catch (Exception ex)
            {
                maTD = null;
            }
        }

        private void btn_capNhat_Click(object sender, EventArgs e)
        {
            LoadListTrinhDo();
            LoadMaTD();
            txt_tenTD.Text = "";
        }
    }
}

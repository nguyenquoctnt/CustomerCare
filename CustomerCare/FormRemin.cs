using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerCare
{
    public partial class FormRemin : Form
    {
        private List<InfoCustomer> _allCustomer;
        private string _pathJson = string.Empty;
        delegate void updateGridDelegate();
        public FormRemin()
        {
            InitializeComponent();
#if DEBUG
            _pathJson = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Data\\";
#else
            _pathJson = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Data\\";
#endif
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now.AddDays(7);
        }

        private void FormRemin_Load(object sender, EventArgs e)
        {
            _allCustomer = new List<InfoCustomer>();
            populateGroupList();
        }

        private void populateGroupList()
        {
            DateTime currentDate = DateTime.Now;
            //dataGridView.DataSource = null;

            string json = File.ReadAllText(_pathJson + "DataBase.json");
            _allCustomer = JsonConvert.DeserializeObject<List<InfoCustomer>>(json);
            //List<InfoCustomer> listCustomer = new List<InfoCustomer>(_allCustomer.Where(a => a.date >= currentDate && a.date <= currentDate.AddDays(7)).OrderBy(a => a.date).ToList());

            dataGridView.DataSource = FilterData();
            dataGridView.Invalidate();
            dataGridView.Columns["date"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();

            SetHyperLinkOnGrid();
        }

        private void SetHyperLinkOnGrid()
        {
            if (dataGridView.Columns.Contains("link"))
            {
                dataGridView.Columns["link"].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            }
        }
        private DataGridViewCellStyle GetHyperLinkStyleForGridCell()
        {
            // Set the Font and Uderline into the Content of the grid cell .  
            {
                DataGridViewCellStyle l_objDGVCS = new DataGridViewCellStyle();
                System.Drawing.Font l_objFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
                l_objDGVCS.Font = l_objFont;
                l_objDGVCS.ForeColor = Color.Blue;
                return l_objDGVCS;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].DataPropertyName.Contains("link"))
            {
                if (!String.IsNullOrWhiteSpace(dataGridView.CurrentCell.EditedFormattedValue.ToString()))
                {
                    if (dataGridView.CurrentCell.EditedFormattedValue.ToString().Contains("http"))
                    {
                        System.Diagnostics.Process.Start(dataGridView.CurrentCell.EditedFormattedValue.ToString());
                    }
                }
            }
            else if (dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].DataPropertyName.Contains("remind"))
            {
                DataGridViewCheckBoxCell checkBox = (dataGridView.CurrentCell as DataGridViewCheckBoxCell);
                checkBox.Value = ((bool)checkBox.Value == true ? false : true);
            }
            else if (dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].DataPropertyName.Contains("ordered"))
            {
                DataGridViewCheckBoxCell checkBox = (dataGridView.CurrentCell as DataGridViewCheckBoxCell);
                checkBox.Value = ((bool)checkBox.Value == true ? false : true);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<InfoCustomer> dataOnGird = (List<InfoCustomer>)dataGridView.DataSource;
            foreach (var item in dataOnGird)
            {
                _allCustomer.Where(a => a.id == item.id).Select(a => { a.remind = item.remind; a.ordered = item.ordered; return a; }).ToList();
            }
            File.WriteAllText(_pathJson + "DataBase.json", JsonConvert.SerializeObject(_allCustomer));

            MessageBox.Show("Cập nhật dữ liệu thành công !", "Ok", MessageBoxButtons.OK);
            dataGridView.Update();
            dataGridView.Refresh();
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DateTime getDate = (DateTime)dataGridView.Rows[e.RowIndex].Cells["date"].Value;
            int day = (getDate - DateTime.Now).Days;
            if (day <= 3 && (bool)dataGridView.Rows[e.RowIndex].Cells["remind"].Value == false)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            //;
            //if (Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["date"].Text) < Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Text))
            //{
            //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
            //}
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[dataGridView.CurrentCell.ColumnIndex].DataPropertyName.Contains("id"))
            {
                InfoCustomer data = new InfoCustomer
                {
                    id = (string)dataGridView.Rows[e.RowIndex].Cells["id"].Value,
                    name = (string)dataGridView.Rows[e.RowIndex].Cells["name"].Value,
                    phone = (string)dataGridView.Rows[e.RowIndex].Cells["phone"].Value,
                    date = (DateTime)dataGridView.Rows[e.RowIndex].Cells["date"].Value,
                    link = (string)dataGridView.Rows[e.RowIndex].Cells["link"].Value,
                    ordered = (bool)dataGridView.Rows[e.RowIndex].Cells["ordered"].Value
                };
                FormAdd updateData = new FormAdd(data,_allCustomer,this);
                updateData.Show();
            }
        }

        private List<InfoCustomer> FilterData()
        {
            List<InfoCustomer> listCustomer = new List<InfoCustomer>(_allCustomer.Where(a => a.date >= dtpFromDate.Value && a.date <= dtpToDate.Value).OrderBy(a => a.date).ToList());
            return listCustomer;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = FilterData();
            dataGridView.Invalidate();
        }
        public void RefreshGrid()
        {
            populateGroupList();
        }
    }
}

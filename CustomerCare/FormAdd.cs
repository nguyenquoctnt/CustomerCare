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
    public partial class FormAdd : Form
    {
        private string _pathJson = string.Empty;
        private string _textBtn = string.Empty;
        private List<InfoCustomer> _allCustomer;
        private const string _textBtn_Add = "Thêm Mới Và Đóng";
        private const string _textBtn_Close = "Cập Nhật Và Đóng";
        private FormRemin _formRemin; //readonly is optional (For safety purposes)
        public FormAdd()
        {
            InitializeComponent();
            _textBtn = _textBtn_Add;
#if DEBUG
            _pathJson = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Data\\";
#else
            _pathJson = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Data\\";
#endif
            btnAddAndClose.Text = _textBtn;
        }

        public FormAdd(InfoCustomer loadForm, List<InfoCustomer> customers, FormRemin formRemin)
        {
            InitializeComponent();
            _textBtn = _textBtn_Close;
#if DEBUG
            _pathJson = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Data\\";
#else
            _pathJson = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Data\\";
#endif
            txtId.Text = loadForm.id;
            txtName.Text = loadForm.name;
            txtPhone.Text = loadForm.phone;
            dtpTime.Value = loadForm.date;
            txtFace.Text = loadForm.link;
            ckOrdered.Checked = loadForm.ordered;

            btnAdd.Visible = false;
            btnAddAndClose.Text = _textBtn;
            _allCustomer = customers;
            _formRemin = formRemin;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddNewCustomer())
                {
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string ValidationData(InfoCustomer inputData)
        {
            string strMes = string.Empty;
            try
            {
                int myInt;
                int.TryParse(inputData.phone, out myInt);
                if (myInt == 0)
                {
                    strMes = "Vui lòng nhập số điện thoại là numeric !";
                    return strMes;
                }
                if (inputData.date.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    strMes = "Ngày đi không được trùng với ngày hiện tại !";
                    return strMes;
                }
            }
            catch (Exception ex)
            {
                strMes = ex.Message;
            }
            return strMes;
        }
        private bool AddNewCustomer()
        {
            bool iResult = false;
            InfoCustomer addNewCustomer = new InfoCustomer
            {
                id = DateTime.Now.ToString("yyyyMMddHHmmss"),
                name = txtName.Text,
                phone = txtPhone.Text,
                date = dtpTime.Value,
                link = txtFace.Text,
                ordered = ckOrdered.Checked
            };
            string getMes = ValidationData(addNewCustomer);
            if (getMes != string.Empty)
            {
                MessageBox.Show(getMes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return iResult;
            }
            string newJson = string.Empty;

            using (StreamReader r = new StreamReader(_pathJson + "DataBase.json"))
            {
                string json = r.ReadToEnd();
                List<InfoCustomer> persons = JsonConvert.DeserializeObject<List<InfoCustomer>>(json);
                persons.Add(addNewCustomer);
                newJson = JsonConvert.SerializeObject(persons);
            }

            File.WriteAllText(_pathJson + "DataBase.json", newJson);
            MessageBox.Show("Thêm mới thành công!", "Ok", MessageBoxButtons.OK);
            return true;
        }
        private void ResetForm()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            dtpTime.Value = DateTime.Now;
            txtFace.Text = "";
        }
        private void btnAddAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (_textBtn != _textBtn_Close)
                {
                    if (AddNewCustomer())
                    {
                        this.Close();
                    }
                }
                else
                {
                    _allCustomer.Where(a => a.id == txtId.Text).Select(a =>
                    {
                        a.name = txtName.Text;
                        a.phone = txtPhone.Text;
                        a.date = dtpTime.Value;
                        a.link = txtFace.Text;
                        a.ordered = ckOrdered.Checked
                        ; return a;
                    }).ToList();

                    File.WriteAllText(_pathJson + "DataBase.json", JsonConvert.SerializeObject(_allCustomer));

                    MessageBox.Show("Cập nhật dữ liệu thành công !", "Ok", MessageBoxButtons.OK);
                    _formRemin.RefreshGrid();
                    this.Close();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

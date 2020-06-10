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
        public FormAdd()
        {
            InitializeComponent();
#if DEBUG
            _pathJson = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Data\\";
#else
            _pathJson = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Data\\";
#endif
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
                if(inputData.date.ToShortDateString() == DateTime.UtcNow.ToShortDateString())
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
                id = DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
                name = txtName.Text,
                phone = txtPhone.Text,
                date = dtpTime.Value,
                link = txtFace.Text,
                ordered = ckOrdered.Checked
            };
            string getMes = ValidationData(addNewCustomer);
            if (getMes != string.Empty)
            {
                MessageBox.Show(getMes, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            dtpTime.Value = DateTime.UtcNow;
            txtFace.Text = "";
        }
        private void btnAddAndClose_Click(object sender, EventArgs e)
        {
            try
            {
               if(AddNewCustomer())
                {
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

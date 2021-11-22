using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XMLForm
{
    public partial class Form1 : Form
    {
        // Declare global variables
        XmlSerializer xmlSerializer;
        List<EmployeeDetails> employeeDetails;

        public Form1()
        {
            InitializeComponent();
            // Initialize the global variables
            employeeDetails = new List<EmployeeDetails>();
            xmlSerializer = new XmlSerializer(typeof(List<EmployeeDetails>));
        }

        private void SubmitBTN_Click(object sender, EventArgs e)
        {
            FileStream XMLFile = new FileStream("D:/Personal Projects/C#/XMLForm/EmployeeDetails.xml", FileMode.Create, FileAccess.Write);
            EmployeeDetails employeeDetail = new EmployeeDetails();
            // Cast to Integer
            employeeDetail.ID = Int32.Parse(EmpIdTB.Text);
            employeeDetail.Name = EmpNameTB.Text;
            employeeDetail.Department = DeptTB.Text;
            employeeDetail.Designation = DesigTB.Text;
            // Cast to Integer
            employeeDetail.Salary = Int32.Parse(SalaryTB.Text);
            // Cast to DateTime
            employeeDetail.JoinedDate = DateTime.Parse(JoinedDateTB.Text);
            // Cast to Integer
            employeeDetail.ContactNumber = Double.Parse(ContactNumTB.Text);
            employeeDetail.Address = AddressTB.Text;
            employeeDetail.MaritalStatus = MaritalStatTB.Text;
            // Cast to Integer
            employeeDetail.Age = Int32.Parse(AgeTB.Text);

            employeeDetails.Add(employeeDetail);

            xmlSerializer.Serialize(XMLFile, employeeDetails);
            XMLFile.Close();

        }

        private void ReadBTN_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("D:/Personal Projects/C#/XMLForm/EmployeeDetails.xml", FileMode.Open, FileAccess.Read);
            employeeDetails = (List<EmployeeDetails>)xmlSerializer.Deserialize(fileStream);

            dataGridView1.DataSource = employeeDetails;
            fileStream.Close();
        }
    }
}

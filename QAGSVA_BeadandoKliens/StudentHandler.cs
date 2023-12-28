using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace QAGSVA_BeadandoKliens
{
    public partial class StudentHandler : Form
    {
        RestClient restClient;
        Main mainForm;
        RequestType requestType;
        List<string> studentStrings = new List<string>();

        public StudentHandler(RestClient restClient, Main mainForm, RequestType requestType)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.restClient = restClient;
            this.mainForm = mainForm;
            this.requestType = requestType;
            GetAllAloneStudents();
            studentBox.DataSource = studentStrings;
        }

        void GetAllAloneStudents()
        {
            RestRequest request = new RestRequest();
            try
            {
                RestResponse response = restClient.Get(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(response.StatusDescription);
                }
                else
                {
                    StudentResponse res = restClient.Deserialize<StudentResponse>(response).Data;
                    foreach (var student in res.Students)
                    {
                        studentStrings.Add(student.student);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        void SetAloneStudentInstructor()
        {
            RestRequest request = new RestRequest();
            request.AddBody(new
            {
                instructor = CurrentUser.username,
                student = studentBox.Text
            });
            try
            {
                RestResponse response = restClient.Put(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(response.StatusDescription);
                }
                else
                {
                    StudentResponse res = restClient.Deserialize<StudentResponse>(response).Data;
                    if (res.error == 0)
                    {
                        MessageBox.Show(res.message);
                        mainForm.ManageButtons(true);
                        mainForm.RefreshStudentData("");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(res.message);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void studentHandlerButton_Click(object sender, EventArgs e)
        {
            if (mainForm.CheckConnection())
            {
                switch (requestType)
                {
                    case RequestType.PUT:
                        SetAloneStudentInstructor();
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void StudentHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.ManageButtons(true);
        }
    }
}

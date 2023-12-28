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
    public partial class TestHandler : Form
    {
        RestClient updateStatusClient = new RestClient("http://localhost/beadando/QAGSVA/teststatusupdate.php");

        RestClient restClient;
        Main mainForm;
        RequestType requestType;

        public TestHandler(RestClient restClient, Main mainForm, RequestType requestType)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.restClient = restClient;
            this.mainForm = mainForm;
            this.requestType = requestType;
            SetFormElements();
        }

        void SetFormElements()
        {
            switch (requestType)
            {
                case RequestType.POST:
                    idLabel.Visible = false;
                    idBox.Visible = false;
                    statusLabel.Visible = false;
                    statusBox.Visible = false;

                    testHandlerButton.Text = "Vizsga felvétele";
                    this.Text = "POST";
                    break;
                case RequestType.PUT:
                    usernameLabel.Visible = false;
                    userBox.Visible = false;
                    dateLabel.Visible = false;
                    datePicker.Visible = false;
                    statusLabel.Visible = false;
                    statusBox.Visible = false;

                    testHandlerButton.Text = "Vizsgabiztosként megjelenés";
                    this.Text = "PUT";
                    break;
                case RequestType.PUT2:
                    usernameLabel.Visible = false;
                    userBox.Visible = false;
                    dateLabel.Visible = false;
                    datePicker.Visible = false;

                    testHandlerButton.Text = "Vizsga értékelése";
                    this.Text = "PUT2";
                    break;
                default:
                    break;
            }
        }

        void AddTest()
        {
            RestRequest request = new RestRequest();
            request.AddBody(new
            {
                instructor = CurrentUser.username,
                student_name = userBox.Text,
                date = datePicker.Value.ToString("yyyy-MM-dd")
            });
            try
            {
                RestResponse response = restClient.Post(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(response.StatusDescription);
                }
                else
                {
                    Response res = restClient.Deserialize<Response>(response).Data;
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
        void SetTestInvigilator()
        {
            RestRequest request = new RestRequest();
            request.AddBody(new
            {
                invigilator = CurrentUser.username,
                id = idBox.Text
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
                    Response res = restClient.Deserialize<Response>(response).Data;
                    if (res.error == 0)
                    {
                        MessageBox.Show(res.message);
                        mainForm.ManageButtons(true);
                        mainForm.RefreshTestData();
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
        void UpdateTestStatus()
        {
            RestRequest request = new RestRequest();
            request.AddBody(new
            {
                invigilator = CurrentUser.username,
                id = idBox.Text,
                status = statusBox.Text
            });
            try
            {
                RestResponse response = updateStatusClient.Put(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(response.StatusDescription);
                }
                else
                {
                    Response res = restClient.Deserialize<Response>(response).Data;
                    if (res.error == 0)
                    {
                        MessageBox.Show(res.message);
                        mainForm.ManageButtons(true);
                        mainForm.RefreshTestData();
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
        private void TestHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.ManageButtons(true);
        }

        private void testHandlerButton_Click(object sender, EventArgs e)
        {
            if (mainForm.CheckConnection())
            {
                switch (requestType)
                {
                    case RequestType.POST:
                        AddTest();
                        break;
                    case RequestType.PUT:
                        SetTestInvigilator();
                        break;
                    case RequestType.PUT2:
                        UpdateTestStatus();
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}

using RestSharp;
using System;
using System.Windows.Forms;

namespace QAGSVA_BeadandoKliens
{
    public partial class Register : Form
    {
        RestClient studentSetup = new RestClient("http://localhost/beadando/QAGSVA/studentinstructor.php");
        RestClient TESTCONNECTION = new RestClient("http://localhost/beadando/QAGSVA/connection.php");

        RestClient restClient;
        Login loginForm;
        RequestType requestType;
        public Register(RestClient restClient, Login loginForm, RequestType requestType)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.restClient = restClient;
            this.loginForm = loginForm;
            this.requestType = requestType;
        }

        void RegisterUser()
        {
            if (passwordBox.Text != passwordABox.Text)
            {
                MessageBox.Show("A két jelszó nem egyezik!");
                passwordBox.Clear();
                passwordABox.Clear();
                return;
            }
            RestRequest request = new RestRequest();
            request.AddParameter("username", usernameBox.Text);
            request.AddParameter("password", passwordBox.Text);
            request.AddParameter("name", nameBox.Text);
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
                        //AddStudent(usernameBox.Text);
                        loginForm.ManageButtons(true);
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
        bool CheckConnection()
        {
            RestRequest request = new RestRequest();
            try
            {
                RestResponse response = TESTCONNECTION.Get(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Az adatbázis nem elérhető!");
                    return false;
                }
                else
                {
                    Response res = TESTCONNECTION.Deserialize<Response>(response).Data;
                    if (res != null)
                    {
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Az adatbázis nem elérhető!");
                        return false;
                    }
                }

            }
            catch (Exception exc)
            {
                return false;
            }
        }

        //void AddStudent(string studentName)
        //{
        //    RestRequest request = new RestRequest();
        //    request.AddParameter("studentname", studentName);
        //    try
        //    {
        //        RestResponse response = restClient.Post(request);
        //        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        //        {
        //            MessageBox.Show(response.StatusDescription);
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show(exc.Message);
        //    }
        //}
        private void registerButton_Click(object sender, EventArgs e)
        {
            if (CheckConnection())
            {
                switch (requestType)
                {
                    case RequestType.REGISTER:
                        RegisterUser();
                        break;
                    default:
                        break;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            loginForm.ManageButtons(true);
            this.Close();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.ManageButtons(true);
        }
    }
}

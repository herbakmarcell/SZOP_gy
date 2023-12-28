using RestSharp;
using System;
using System.Windows.Forms;

namespace QAGSVA_BeadandoKliens
{
    public partial class Login : Form
    {
        RestClient registerClient = new RestClient("http://localhost/beadando/QAGSVA/register.php");
        RestClient roleClient = new RestClient("http://localhost/beadando/QAGSVA/rolerequest.php");
        RestClient nameClient = new RestClient("http://localhost/beadando/QAGSVA/namerequest.php");

        RestClient restClient;
        Main mainForm;
        RequestType requestType;

        public Login(RestClient restClient, Main mainForm, RequestType requestType)
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
                case RequestType.LOGIN:
                    loginHandlerButton.Text = "Bejelentkezés";
                    registerHandlerButton.Text = "Regisztráció";
                    break;
                default:
                    break;
            }
        }

        public void ManageButtons(bool enable)
        {
            loginHandlerButton.Enabled = enable;
            registerHandlerButton.Enabled = enable;
        }

        void LoginUser()
        {
            RestRequest request = new RestRequest();
            request.AddParameter("username", usernameBox.Text);
            request.AddParameter("password", passwordBox.Text);
            try
            {
                RestResponse response = restClient.Get(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(response.StatusDescription);
                }
                else
                {
                    Response res = restClient.Deserialize<Response>(response).Data;
                    if (res.error == 0)
                    {
                        CurrentUser.username = usernameBox.Text;
                        CurrentUser.password = passwordBox.Text;
                        SetUserRole(usernameBox.Text, passwordBox.Text);
                        SetName(CurrentUser.username);
                        MessageBox.Show(res.message);
                        
                        mainForm.RefreshLabels();
                        mainForm.ManageButtons(true);
                        if (CurrentUser.role == Role.STUDENT)
                        {
                            mainForm.RefreshStudentData(CurrentUser.username);
                        }
                        else if(CurrentUser.role == Role.INSTRUCTOR)
                        {
                            mainForm.RefreshStudentData("");
                        }
                        else if (CurrentUser.role == Role.INVIGILATOR)
                        {
                            mainForm.RefreshTestData();
                        }
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

        void SetName(string username)
        {
            RestRequest request = new RestRequest();
            request.AddParameter("username", CurrentUser.username);
            try
            {
                RestResponse nameResponse = nameClient.Get(request);

                if (nameResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(nameResponse.StatusDescription);
                }
                else
                {
                    string res = nameResponse.Content;
                    CurrentUser.name = res;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void SetUserRole(string username, string password)
        {
            RestRequest request = new RestRequest();
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("currentuser", CurrentUser.username);
            request.AddParameter("currentpassword", CurrentUser.password);
            try
            {
                RestResponse roleResponse = roleClient.Get(request);

                if (roleResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(roleResponse.StatusDescription);
                }
                else
                {
                    string res = roleResponse.Content;
                    switch (res)
                    {
                        case "STUDENT":
                            CurrentUser.role = Role.STUDENT;
                            break;
                        case "INSTRUCTOR":
                            CurrentUser.role = Role.INSTRUCTOR;
                            break;
                        case "INVIGILATOR":
                            CurrentUser.role = Role.INVIGILATOR;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void loginHandlerButton_Click(object sender, EventArgs e)
        {
            if (mainForm.CheckConnection())
            {
                switch (requestType)
                {
                    case RequestType.LOGIN:
                        LoginUser();
                        break;
                    default:
                        break;
                }
            }
        }
        private void registerHandlerButton_Click(object sender, EventArgs e)
        {
            new Register(registerClient, this, RequestType.REGISTER).Show();
            ManageButtons(false);
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentUser.username == null)
            {
                mainForm.Close();
            }
        }
    }
}

using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QAGSVA_BeadandoKliens
{
    public partial class LessonHandler : Form
    {
        RestClient restClient;
        Main mainForm;
        RequestType requestType;

        public LessonHandler(RestClient restClient, Main mainForm, RequestType requestType)
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
                case RequestType.GET:
                    this.Text = "GET";
                    idLabel.Visible = false;
                    idBox.Visible = false;
                    dateLabel.Visible = false;
                    datePicker.Visible = false;
                    distanceLabel.Visible = false;
                    distanceBox.Visible = false;
                    timeLabel.Visible = false;
                    timeBox.Visible = false;
                    descLabel.Visible = false;
                    descBox.Visible = false;
                    lessonHandlerButton.Text = "Tanuló óráinak lekérdezése";
                    break;
                case RequestType.POST:
                    this.Text = "POST";
                    idLabel.Visible = false;
                    idBox.Visible = false;
                    lessonHandlerButton.Text = "Tanuló óra hozzáadása";
                    break;
                case RequestType.PUT:
                    this.Text = "PUT";
                    lessonHandlerButton.Text = "Tanuló óra szerkesztése";
                    break;
                case RequestType.DELETE:
                    this.Text = "DELETE";
                    dateLabel.Visible = false;
                    datePicker.Visible = false;
                    distanceLabel.Visible = false;
                    distanceBox.Visible = false;
                    timeLabel.Visible = false;
                    timeBox.Visible = false;
                    descLabel.Visible = false;
                    descBox.Visible = false;
                    lessonHandlerButton.Text = "Tanuló órájának törlése";
                    break;
                default:
                    break;
            }
        }

        void AddLesson()
        {
            RestRequest request = new RestRequest();
            request.AddParameter("instructor",CurrentUser.username);
            request.AddParameter("username", userBox.Text);
            request.AddParameter("distance", distanceBox.Text);
            request.AddParameter("hours", timeBox.Text);
            request.AddParameter("description", descBox.Text);
            request.AddParameter("date", datePicker.Value.ToString("yyyy-MM-dd"));
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
        void UpdateLesson()
        {
            string username = userBox.Text;
            RestRequest request = new RestRequest();
            request.AddBody(new
            {
                instructor = CurrentUser.username,
                id = idBox.Text,
                student_name = userBox.Text,
                distance = distanceBox.Text,
                hours = timeBox.Text,
                description = descBox.Text,
                date = datePicker.Value.ToString("yyyy-MM-dd")
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
        void DeleteLesson()
        {
            RestRequest request = new RestRequest();
            request.AddBody(new
            {
                instructor = CurrentUser.username,
                id = idBox.Text,
                studentname = userBox.Text
            });
            try
            {
                RestResponse response = restClient.Delete(request);
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
        private void LessonHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.ManageButtons(true);
        }

        private void lessonHandlerButton_Click(object sender, EventArgs e)
        {
            if (mainForm.CheckConnection())
            {
                switch (requestType)
                {
                    case RequestType.GET:
                        mainForm.RefreshStudentData(userBox.Text);
                        this.Close();
                        break;
                    case RequestType.POST:
                        AddLesson();
                        break;
                    case RequestType.PUT:
                        UpdateLesson();
                        break;
                    case RequestType.DELETE:
                        DeleteLesson();
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}

using RestSharp;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QAGSVA_BeadandoKliens
{
    public partial class Main : Form
    {
        RestClient TESTCONNECTION = new RestClient("http://localhost/beadando/QAGSVA/connection.php");

        RestClient studentClient = new RestClient("http://localhost/beadando/QAGSVA/student.php");
        RestClient loginClient = new RestClient("http://localhost/beadando/QAGSVA/login.php");
        RestClient totalHoursClient = new RestClient("http://localhost/beadando/QAGSVA/studenthours.php");
        RestClient totalDistanceClient = new RestClient("http://localhost/beadando/QAGSVA/studentdistance.php");
        RestClient personalInstructor = new RestClient("http://localhost/beadando/QAGSVA/studentinstructor.php");
        RestClient testClient = new RestClient("http://localhost/beadando/QAGSVA/test.php");
        RestClient getStudentClient = new RestClient("http://localhost/beadando/QAGSVA/studentselection.php");

        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            RefreshLabels();
            IsLoggedIn();
            InitializePracticeGridView();
        }

        public bool CheckConnection()
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

                    } else
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
        bool IsLoggedIn()
        {
            if (CurrentUser.username == null)
            {
                ManageButtons(false);
                new Login(loginClient, this, RequestType.LOGIN).Show();
                return false;
            }
            return true;
        }

        void InitializePracticeGridView()
        {
            if (CurrentUser.role == Role.STUDENT)
            {
                practiceGridView.Columns.Clear();
                practiceGridView.Columns.Add("id", "ID");
                practiceGridView.Columns.Add("distance", "Távolság");
                practiceGridView.Columns.Add("hours", "Óra");
                practiceGridView.Columns.Add("description", "Leírás");
                practiceGridView.Columns.Add("date", "Dátum");
                practiceGridView.Visible = true;
            }
            else if (CurrentUser.role == Role.INSTRUCTOR)
            {
                practiceGridView.Columns.Clear();
                practiceGridView.Columns.Add("id", "ID");
                practiceGridView.Columns.Add("student_name", "Tanuló");
                practiceGridView.Columns.Add("distance", "Távolság");
                practiceGridView.Columns.Add("hours", "Óra");
                practiceGridView.Columns.Add("description", "Leírás");
                practiceGridView.Columns.Add("date", "Dátum");
                practiceGridView.Visible = true;
            }
            else if (CurrentUser.role == Role.INVIGILATOR)
            {
                practiceGridView.Columns.Clear();
                practiceGridView.Columns.Add("id", "ID");
                practiceGridView.Columns.Add("student", "Tanuló");
                practiceGridView.Columns.Add("instructor", "Oktató");
                practiceGridView.Columns.Add("invigilator", "Vizsgabiztos");
                practiceGridView.Columns.Add("status", "Státusz");
                practiceGridView.Columns.Add("date", "Dátum");
                practiceGridView.Visible = true;
            }
            
            
        }

        public void RefreshStudentData(string username)
        {
            InitializePracticeGridView();
            RestRequest request = new RestRequest();
            request.AddParameter("username", username);
            try
            {
                RestResponse response = studentClient.Get(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(response.StatusDescription);
                }
                else
                {
                    if (CurrentUser.role == Role.STUDENT)
                    {
                        DriveResponse res = studentClient.Deserialize<DriveResponse>(response).Data;
                        practiceGridView.Rows.Clear();
                        foreach (var lesson in res.Lessons)
                        {
                            practiceGridView.Rows.Add(lesson.ID, lesson.distance, lesson.hours, lesson.description, lesson.date.ToString("yyyy-MM-dd"));
                        }
                    }
                    else if (CurrentUser.role == Role.INSTRUCTOR)
                    {
                        DriveResponse res = studentClient.Deserialize<DriveResponse>(response).Data;
                        practiceGridView.Rows.Clear();
                        foreach (var lesson in res.Lessons)
                        {
                            practiceGridView.Rows.Add(lesson.ID, lesson.student_name, lesson.distance, lesson.hours, lesson.description, lesson.date.ToString("yyyy-MM-dd"));
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void RefreshTestData()
        {
            InitializePracticeGridView();
            RestRequest request = new RestRequest();
            request.AddParameter("username", CurrentUser.username);
            try
            {
                RestResponse response =testClient.Get(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(response.StatusDescription);
                }
                else
                {
                    TestResponse res = testClient.Deserialize<TestResponse>(response).Data;
                    practiceGridView.Rows.Clear();
                    foreach (var test in res.Tests)
                    {
                        practiceGridView.Rows.Add(test.ID, test.student, test.instructor, test.invigilator, test.status, test.date.ToString("yyyy-MM-dd"));
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        void ManageLabels(bool enable)
        {
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 9)
            {
                greetingsLabel.Text = "Jó reggelt ";
            }
            else if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 18)
            {
                greetingsLabel.Text = "Jó napot ";
            }
            else
            {
                greetingsLabel.Text = "Jó estét ";
            }
            greetingsLabel.Text += CurrentUser.name + "!";
            greetingsLabel.Visible = enable;

            if (CurrentUser.role == Role.STUDENT)
            {
                drivenHourLabel.Text = "Levezetetett órák száma: " + GetAllHours() + " óra";
                drivenHourLabel.Visible = enable;
                drivenKmLabel.Text = "Levezetetett kilométerek száma: " + GetAllDistance() + " km";
                drivenKmLabel.Visible = enable;
                instructorLabel.Text = "Oktató: " + GetInstructor();
                instructorLabel.Visible = enable;
            }
            
        }

        public void RefreshLabels()
        {
            if (CurrentUser.username == null)
            {
                ManageLabels(false);
                return;
            }
            ManageLabels(true);
        }

        string GetAllHours()
        {
            RestRequest request = new RestRequest();
            request.AddParameter("username", CurrentUser.username);
            try
            {
                RestResponse hoursResponse = totalHoursClient.Get(request);

                if (hoursResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(hoursResponse.StatusDescription);
                }
                else
                {
                    string res = hoursResponse.Content;
                    return res;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return "0";
        }
        string GetAllDistance()
        {
            RestRequest request = new RestRequest();
            request.AddParameter("username", CurrentUser.username);
            try
            {
                RestResponse distanceResponse = totalDistanceClient.Get(request);

                if (distanceResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(distanceResponse.StatusDescription);
                }
                else
                {
                    string res = distanceResponse.Content;
                    return res;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return "0";
        }
        string GetInstructor()
        {
            RestRequest request = new RestRequest();
            request.AddParameter("username", CurrentUser.username);
            try
            {
                RestResponse insResponse = personalInstructor.Get(request);

                if (insResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(insResponse.StatusDescription);
                }
                else
                {
                    string res = insResponse.Content;
                    return res;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return "Nincs még";
        }
        public void ManageButtons(bool enable)
        {
            switch (CurrentUser.role)
            {
                case Role.STUDENT:
                    practiceGridView.Enabled = enable;
                    getButton.Text = "Frissítés";
                    getButton.Visible = true;
                    getButton.Enabled = enable;
                    addButton.Visible = false;
                    updateButton.Visible = false;
                    deleteButton.Visible = false;
                    testAddButton.Visible = false;
                    studentAddButton.Visible = false;
                    break;
                case Role.INSTRUCTOR:
                    practiceGridView.Enabled = enable;

                    getButton.Text = "Órák";
                    getButton.Visible = true;
                    getButton.Enabled = enable;

                    addButton.Text = "Hozzáadás";
                    addButton.Visible = true;
                    addButton.Enabled = enable;

                    updateButton.Text = "Módosítás";
                    updateButton.Enabled = enable;
                    updateButton.Visible = true;

                    deleteButton.Text = "Törlés";
                    deleteButton.Enabled = enable;
                    deleteButton.Visible = true;

                    testAddButton.Text = "Vizsga felvétele";
                    testAddButton.Enabled = enable;
                    testAddButton.Visible = true;

                    studentAddButton.Text = "Tanuló felvétele";
                    studentAddButton.Enabled = enable;
                    studentAddButton.Visible = true;
                    break;
                case Role.INVIGILATOR:
                    getButton.Text = "Vizsgák";
                    getButton.Visible = true;
                    getButton.Enabled = enable;

                    addButton.Text = "Felvétel";
                    addButton.Enabled = enable;
                    addButton.Visible = true;

                    updateButton.Text = "Értékelés";
                    updateButton.Enabled = enable;
                    updateButton.Visible = true;

                    deleteButton.Visible = false;

                    testAddButton.Visible = false;

                    studentAddButton.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            if (CheckConnection())
            {
                if (IsLoggedIn())
                {
                    if (CurrentUser.role == Role.STUDENT)
                    {
                        RefreshStudentData(CurrentUser.username);
                        ManageLabels(true);
                    }
                    else if (CurrentUser.role == Role.INSTRUCTOR)
                    {
                        ManageButtons(false);
                        new LessonHandler(studentClient, this, RequestType.GET).Show();
                    }
                    else if (CurrentUser.role == Role.INVIGILATOR)
                    {
                        RefreshTestData();
                    }
                }
                
            }            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (CheckConnection())
            {
                if (IsLoggedIn())
                {
                    if (CurrentUser.role == Role.INSTRUCTOR)
                    {
                        ManageButtons(false);
                        new LessonHandler(studentClient, this, RequestType.POST).Show();
                    }
                    else if (CurrentUser.role == Role.INVIGILATOR)
                    {
                        ManageButtons(false);
                        new TestHandler(testClient, this, RequestType.PUT).Show();
                    }
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (CheckConnection())
            {
                if (IsLoggedIn())
                {
                    if (CurrentUser.role == Role.INSTRUCTOR)
                    {
                        ManageButtons(false);
                        new LessonHandler(studentClient, this, RequestType.PUT).Show();
                    }
                    else if (CurrentUser.role == Role.INVIGILATOR)
                    {
                        ManageButtons(false);
                        new TestHandler(testClient, this, RequestType.PUT2).Show();
                    }
                }
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (CheckConnection())
            {
                if (IsLoggedIn())
                {
                    ManageButtons(false);
                    new LessonHandler(studentClient, this, RequestType.DELETE).Show();
                }
            }
            
        }

        private void testAddButton_Click(object sender, EventArgs e)
        {
            if (CheckConnection())
            {
                if (IsLoggedIn())
                {
                    if (CurrentUser.role == Role.INSTRUCTOR)
                    {
                        ManageButtons(false);
                        new TestHandler(testClient, this, RequestType.POST).Show();
                    }
                }
            }
        }

        private void studentAddButton_Click(object sender, EventArgs e)
        {
            if (CheckConnection())
            {
                if (IsLoggedIn())
                {
                    if (CurrentUser.role == Role.INSTRUCTOR)
                    {
                        ManageButtons(false);
                        new StudentHandler(getStudentClient, this, RequestType.PUT).Show();
                    }
                }
            }
        }
    }
}
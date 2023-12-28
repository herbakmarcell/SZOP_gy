using RestSharp;
using System;
using System.Windows.Forms;

namespace QAGSVA_BeadandoKliens
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RestClient TESTCONNECTION = new RestClient("http://localhost/beadando/QAGSVA/connection.php");
            if (!CheckConnection())
            {
                MessageBox.Show("Adatbázis nem elérhető!");
                Application.Exit();
            } else
            {
                Application.Run(new Main());
            }

            bool CheckConnection()
            {
                RestRequest request = new RestRequest();
                try
                {
                    RestResponse response = TESTCONNECTION.Get(request);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
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
                            return false;
                        }
                    }

                }
                catch (Exception exc)
                {
                    return false;
                }
            }


        }
    }
}

using ChatBotDataAccess;
using SelectMonitorContractsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SelectMonitorLib
{
    public class SelectMonitor : ISelectMonitor
    {
        
        public int FindScore(string FeatureList,List<string> DesiredFeatures)
        {
            ChatBotDBEntities entities = new ChatBotDBEntities();
            int no_features = entities.Features.Count();
            int no_monitors = entities.Monitors.Count(); ;
            int _score = 0;

            string[] Features = FeatureList.Split(',');
            List<string> FeatureList1 = new List<string>();
            foreach (string arrItem in Features)
                FeatureList1.Add(arrItem);

            _score = (FeatureList1.Intersect(DesiredFeatures)).Count();
            
            return _score;
        }

        //string[] Responses;
        public List<string> FindRequiredProduct(string[] responses)
        {
            ChatBotDBEntities entities = new ChatBotDBEntities();
            List<PatientMonitor> entity = null;
            List<string> Responses = new List<string>();
            List<String> BestMatch = new List<String>();
            List<int> scoreList = new List<int>();
            List<String> DesiredFeatureList = new List<string>();
            int no_features = entities.Features.Count();
            int no_monitors = entities.Monitors.Count();
            List<string> FeatureList1 = new List<string>();
            int _score = 0;

            SqlConnection conn = new SqlConnection(@"Data Source=INGBTCPIC5NBZ24\SQLEXPRESS;Initial Catalog=ChatBotDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            conn.Open();
            if (responses.Length >= 3)
            {
                Responses.Add(responses[3]);
                Responses.Add(responses[4]);
                Responses.Add(responses[5]);
                Responses.Add(responses[6]);
                Responses.Add(responses[7]);
                Responses.Add(responses[8]);

                string[] ResponseArray = Responses.ToArray();
                //List<Boolean> DesiredFeatures = new List<Boolean>();
                int rowID;
                for (int i = 1; i <= Responses.Count; i++)
                {
                    rowID = i;
                    if (string.Compare(ResponseArray[i - 1], "Yes") == 0)
                    {
                        string queryString1 = "SELECT Feature_ID FROM dbo.Features where Row_ID = @rowID";
                        
                        SqlCommand command1 = new SqlCommand(queryString1, conn);
                        command1.Parameters.AddWithValue("@rowID", rowID);
                        SqlDataReader reader1 = command1.ExecuteReader();
                        while(reader1.Read())
                        {
                            string Feature = reader1["Feature_ID"].ToString();
                        DesiredFeatureList.Add(Feature);
                        }
                        

                    }
                    
                }

                List<Boolean> AvailableFeatures = new List<Boolean>();
                //List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

                #region Calculate score
                string queryString = "SELECT * FROM dbo.PatientMonitors ;";
                SqlCommand command = new SqlCommand(queryString, conn);
                SqlDataReader reader = command.ExecuteReader();
                string ModelNumber;
                string Features;
                int score = 0;
                int _maxScore = 0;

                                
                while (reader.Read())
                {                   
                    ModelNumber = reader["Model"].ToString();
                    Features = reader["Features"].ToString();
                    //rows.Add(column);
                    string[] Features1 = Features.Split(',');
                    FeatureList1.Clear();
                    foreach (string arrItem in Features1)
                    {
                        FeatureList1.Add(arrItem);
                    }

                    score = FindScore(Features, DesiredFeatureList);
                    scoreList.Add(score);
                    if (score>_maxScore)
                    {
                        _maxScore = score;
                        BestMatch.Clear();
                        BestMatch.Add(ModelNumber);
                    }
                    else if(score==_maxScore)
                    {
                        BestMatch.Add(ModelNumber);
                    }
                    else
                    {
                        continue;
                    }
                }
                conn.Close();
                #endregion
                

            }
            return BestMatch;
            //return monitors;
        }

        public Question FindQuestion(int ID)
        {
            ChatBotDBEntities entities = new ChatBotDBEntities();
            Question first_question = entities.Questions.Find(ID);
            //Console.WriteLine("Hello");
            return first_question;

        }

        public string[] RetrieveQuestionWithOptions(Question question)
        {
            List<string> Display = new List<string>();
            Display.Add(question.Question1);

            //string[] display;
            //display[0] = question.Question1;
            string[] optionList = question.Option.Split('-');
            //optionList[0] = question.Question1;
            Display.Add(optionList[0]);
            Display.Add(optionList[1]);
            string[] Display1 = Display.ToArray();
            return Display1;
        }
    }
}

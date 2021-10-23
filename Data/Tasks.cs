using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SkillsShowcase.Data
{
    public class Tasks
    {
        public int IdTask { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateFinished { get; set; }
        public bool Done { get; set; }

        public Tasks() { }

        public List<Tasks> GetTasksByUser(string user)
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["TasksConnection"].ToString();
            List<Tasks> lst = new List<Tasks>();

            using (SqlConnection Connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Task WHERE Username = @Username", Connection);
                cmd.Parameters.AddWithValue("@Username", user);
                Connection.Open();
                lst = MapTasks(cmd.ExecuteReader());
                Connection.Close();

            }
            return lst;
        }

        public List<Tasks> GetTasksByUser(string user, bool done)
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["TasksConnection"].ToString();
            List<Tasks> lst = new List<Tasks>();

            using (SqlConnection Connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Task WHERE Username = @Username AND IsDone = @IsDone", Connection);
                cmd.Parameters.AddWithValue("@Username", user);
                cmd.Parameters.AddWithValue("@IsDone", done);
                Connection.Open();
                lst = MapTasks(cmd.ExecuteReader());
                Connection.Close();

            }
            return lst;
        }

        public void Insert()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["TasksConnection"].ToString();

            using (SqlConnection Connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Task (Username, Title, Description, DateStarted, IsDone)VALUES (@Username,@Title,@Description,@DateStarted,@IsDone)", Connection);
                cmd.Parameters.AddWithValue("@Username", this.Username);
                cmd.Parameters.AddWithValue("@Title", this.Title);
                cmd.Parameters.AddWithValue("@Description", this.Description);
                cmd.Parameters.AddWithValue("@DateStarted", this.DateAdded);
                cmd.Parameters.AddWithValue("@IsDone", this.Done);
                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
        }

        public void Update()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["TasksConnection"].ToString();

            using (SqlConnection Connection = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Task SET Username = @Username, Title = @Title, Description = @Description,DateStarted = @DateStarted, DateEnded = @DateEnded, IsDone = @IsDone WHERE IdTask = @IdTask)", Connection);
                cmd.Parameters.AddWithValue("@IdTask", this.IdTask);
                cmd.Parameters.AddWithValue("@Username", this.Username);
                cmd.Parameters.AddWithValue("@Title", this.Title);
                cmd.Parameters.AddWithValue("@Description", this.Description);
                cmd.Parameters.AddWithValue("@DateStarted", this.DateAdded);
                cmd.Parameters.AddWithValue("@DateEnded", this.DateFinished);
                cmd.Parameters.AddWithValue("@IsDone", this.Done);
                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();

            }
        }

        private List<Tasks> MapTasks (SqlDataReader Reader)
        {
            List<Tasks> lst = new List<Tasks>();
            while(Reader.Read())
            {
                Tasks obj = new Tasks();
                obj.IdTask = Convert.ToInt32(Reader["IdTask"]);
                obj.Username = Convert.ToString(Reader["Username"]);
                obj.Title = Convert.ToString(Reader["Title"]);
                obj.Description = Convert.ToString(Reader["Description"]);
                obj.DateAdded = Convert.ToDateTime(Reader["DateStarted"]);
                obj.DateFinished = Convert.ToDateTime((Reader["DateEnded"] == System.DBNull.Value ? null : Reader["DateEnded"]));
                obj.Done = Convert.ToBoolean(Reader["IsDone"]);
                lst.Add(obj);
            }
            return lst;
        }
    }


}
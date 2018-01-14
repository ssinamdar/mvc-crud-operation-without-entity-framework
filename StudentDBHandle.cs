using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MVC_Crud.Models
{
    public class StudentDbHandle
    {
        private SqlConnection _conn;

        public void Connection()
        {
            _conn =
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["SudentConnection"].ToString());
        }

        public bool AddStudent(StudentModel smodel)
        {
            Connection();
            var cmd = new SqlCommand("AddNewStudent", _conn) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);

            _conn.Open();
            var i = cmd.ExecuteNonQuery();
            _conn.Close();

            return i >= 1;
        }

        public bool UpdateStudent(StudentModel smodel)
        {
            Connection();
            var cmd = new SqlCommand("UpdateStudent", _conn) {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.AddWithValue("@Id", smodel.Id);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);

            _conn.Open();
            var i = cmd.ExecuteNonQuery();
            _conn.Close();

            return i >= 1;
        }

        public List<StudentModel> GetStudentModels()
        {
            var dt = new DataTable();
            Connection();
            var cmd = new SqlCommand("GetStudents", _conn) {CommandType = CommandType.StoredProcedure};

            _conn.Open();
            new SqlDataAdapter(cmd).Fill(dt);
            _conn.Close();

            return (from DataRow dr in dt.Rows
                select new StudentModel
                {
                    Id = (int) dr["Id"], Name = dr["Name"].ToString(), City = dr["City"].ToString(), Address = dr["Address"].ToString()
                }).ToList();
        }

        public bool DeleteStudentRecords(int id)
        {
            Connection();
            var cmd = new SqlCommand("DeleteStudent", _conn){CommandType = CommandType.StoredProcedure};

            cmd.Parameters.AddWithValue("@Id", id);
            _conn.Open();
            var i = cmd.ExecuteNonQuery();
            _conn.Close();
            return i >= 1;
        }

        public List<StudentModel> GetStudentModels(int id)
        {
            var dt = new DataTable();
            Connection();
            var cmd = new SqlCommand("GetSingleStudents", _conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Id", id);

            _conn.Open();
            new SqlDataAdapter(cmd).Fill(dt);
            _conn.Close();

            return (from DataRow dr in dt.Rows
                    select new StudentModel
                    {
                        Id = (int)dr["Id"],
                        Name = dr["Name"].ToString(),
                        City = dr["City"].ToString(),
                        Address = dr["Address"].ToString()
                    }).ToList();
        }
    }
}

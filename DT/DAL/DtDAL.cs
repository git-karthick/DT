using DT.Models;
using System.Data;
using System.Data.SqlClient;

namespace DT.DAL
{
    public class DtDAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration Configuration { get; set; }
        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }
        public List<Dt> Getall()
        {
            List<Dt> dtl = new List<Dt>();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "DTALL_SP";
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while (dr.Read())
                {
                    Dt dt = new Dt();
                    dt.Id = Convert.ToInt32(dr["Id"]);
                    dt.Name = (string)dr["Name"];
                    dt.Dob = Convert.ToDateTime(dr["Dob"]);
                    dtl.Add(dt);
                }
            }
            return dtl;
        }
        public Dt GetById(int id)
        {
            Dt dt = new Dt();
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "DTBYID_SP";
                _command.Parameters.AddWithValue("@Id", id);
                _connection.Open();
                SqlDataReader dr = _command.ExecuteReader();
                while (dr.Read())
                {
                    dt.Id = Convert.ToInt32(dr["Id"]);
                    dt.Name = (string)dr["Name"];
                    dt.Dob = Convert.ToDateTime(dr["Dob"]);
                }
            }
            return dt;
        }
        public bool Insert(Dt dt)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "DTINSERT_SP";
                _command.Parameters.AddWithValue("@Name", dt.Name);
                _command.Parameters.AddWithValue("@Dob", dt.Dob);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            return true;
        }
        public bool Edit(Dt dt)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "DTEDIT_SP";
                _command.Parameters.AddWithValue("@Id", dt.Id);
                _command.Parameters.AddWithValue("@Name", dt.Name);
                _command.Parameters.AddWithValue("@Dob", dt.Dob);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            return true;
        }
        public bool Delete(Dt dt)
        {
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "DTUPDATE_SP";
                _command.Parameters.AddWithValue("@Id", dt.Id);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            return true;
        }
    }
}

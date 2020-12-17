using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestExam2
{
    public class ManageMeasurements
    {
        private const string ConnectionString = "empty";
        private const string GET_ALL = "Select * from DB";
        private const string GET_ONE = "Select * from DB where ID = @ID";
        private const string INSERT = "Insert into DB values(@ID, @Pressure, @Humidity, @Temperature, @Timestamp)";
        private const string UPDATE = "Update DB Set UserName = @Name, Password = @Password where UserName = @Name";
        private const string DELETE = "Delete from DB where ID = @ID";// and Pressure = @Pressure and Humidity = @Humidity and Temperature = @Temperature and Timestamp = @Timestamp


        private Measurement ReadMeasurement(SqlDataReader reader)
        {
            Measurement measurement = new Measurement();
            measurement.Id = reader.GetInt32(0);
            measurement.Pressure = reader.GetInt32(1);
            measurement.Humidity = reader.GetInt32(2);
            measurement.Temperature = reader.GetInt32(3);
            measurement.Timestamp = reader.GetDateTime(4);
            return measurement;
        }


        public IEnumerable<Measurement> Get()
        {
            List<Measurement> measurements = new List<Measurement>();

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Measurement measurement = ReadMeasurement(reader);
                measurements.Add(measurement);

            }
            conn.Close();
            return measurements;
        }

        public Measurement Get(int id)
        {
            Measurement measurement = new Measurement();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                measurement = ReadMeasurement(reader);
            }

            conn.Close();
            return measurement;
        }


        public void Post(Measurement measurement)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@ID", measurement.Id);
            cmd.Parameters.AddWithValue("@Pressure", measurement.Pressure);
            cmd.Parameters.AddWithValue("@Humidity", measurement.Humidity);
            cmd.Parameters.AddWithValue("@Temperature", measurement.Temperature);
            cmd.Parameters.AddWithValue("@Timestamp", measurement.Timestamp);
            cmd.ExecuteNonQuery();

            conn.Close();
        }


        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();

            conn.Close();
        }


    }
}

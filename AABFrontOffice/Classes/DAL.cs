using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace AABFrontOffice.Classes
{

    public class DAL
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd = null;
        public static DataSet ds = null;
        public static string jsonString = string.Empty;


        public static string getJSONDataWhere(Dictionary<Object, Object> args, string connectionString, string procedureName)
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand(procedureName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();

                foreach (var item in args)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value.ToString());
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                jsonString = JsonConvert.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                cmd.Connection.Close();
            }
            return jsonString;
        }




        public static string getJSONData(string connectionString, string procedureName)
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand(procedureName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                jsonString = JsonConvert.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                cmd.Connection.Close();
            }
            return jsonString;
        }

        // This method is used for showing Data on the base of Condition

        public static DataSet showDataWhere(Dictionary<Object, Object> args, string connectionString, string procedureName)
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand(procedureName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();


                foreach (var item in args)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value.ToString());
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                cmd.Connection.Close();
            }
            return ds;
        }


        // This method is used to update Data

        public static bool updateData(Dictionary<Object, Object> args, string procedureName, string connectionString)
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand(procedureName, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (var item in args)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value.ToString());
                }

                cmd.Connection.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {

            }

            finally
            {
                cmd.Connection.Close();

            }
            return false;
        }

    }
}
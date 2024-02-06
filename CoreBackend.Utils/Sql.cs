using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreBackend.Utils
{
    public static class Sql
    {
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {

            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch { throw; }
        }
        public static T DataTableClass<T>(this DataTable table) where T : class, new()
        {
            try
            {
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    return obj;
                }

                return null;
            }
            catch { throw; }
        }
        public static Hashtable ModelToHashtableParamSQL<T>(T model)
        {
            Hashtable parameters = new Hashtable();

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string propertyName = "@" + property.Name;
                object propertyValue = property.GetValue(model);
                parameters[propertyName] = propertyValue;
            }

            return parameters;
        }
        public static DataTable ExecuteProcAsDataTable(Hashtable param, string sp_proc, string connectionString)
        {
            try
            {
                DataTable dt = new DataTable();


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sp_proc, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    foreach (DictionaryEntry de in param)
                    {
                        cmd.Parameters.Add(new SqlParameter(de.Key.ToString(), de.Value));
                    }
                    SqlDataAdapter dataAdapt = new SqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    dataAdapt.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
        public static DataSet ExecuteProcAsDataSet(Hashtable param, string sp_proc, string connectionString)
        {

            try
            {
                DataSet ds = new DataSet();


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sp_proc, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    foreach (DictionaryEntry de in param)
                    {
                        cmd.Parameters.Add(new SqlParameter(de.Key.ToString(), de.Value));
                    }
                    SqlDataAdapter dataAdapt = new SqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    dataAdapt.Fill(ds);
                    return ds;
                }
            }
            catch
            {
                throw;
            }

        }
        public static DataTable ExecuteProcNotParamAsDatatable(string proc, string connectionString)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(proc, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataAdapter dataAdapt = new SqlDataAdapter
                    {
                        SelectCommand = cmd
                    };
                    DataTable dataTable = new DataTable();
                    dataAdapt.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;

            }
        }
        public static DataSet ExecuteSqlTextAsDataSet(string sql, string strConnection)
        {
            try
            {

                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter dataAdapt = new SqlDataAdapter();
                    dataAdapt.SelectCommand = cmd;
                    dataAdapt.Fill(ds);
                    return ds;
                }
            }
            catch
            {
                throw;

            }
        }
        public static void ExecuteSqlTextNonQuery(string sql, string strConnection)
        {
            try
            {


                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
            }
            catch
            {
                throw;

            }
        }

    }
}

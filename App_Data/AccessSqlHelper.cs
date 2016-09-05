using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.OleDb;


namespace connectAccess
{
    
    public class AccessSqlHelper
    {

        private static readonly string connStr = "Provider=Microsoft.Ace.OleDb.12.0;DATA Source=E://asp.net//cms//App_Data//HJWLCMS.mdb;";

        //执行sql语句
        public int ExecuteNonQuery(string sql, params OleDbParameter[] olePams)
        {
            using( OleDbConnection conn = new OleDbConnection(connStr))
            {

                using(OleDbCommand OleCmd = new OleDbCommand(sql, conn))
                {

                    if (olePams != null)
                    {
                        OleCmd.Parameters.AddRange(olePams);
                    }

                    conn.Open();

                    return OleCmd.ExecuteNonQuery();
                
                }
            
            }
        
        }

        //执行sql语句
        public object ExecuteScalar(string sql, params OleDbParameter[] olePams)
        {

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {

                using (OleDbCommand OleCmd = new OleDbCommand(sql, conn))
                {

                    if (olePams != null)
                    {

                        OleCmd.Parameters.AddRange(olePams);
                    }

                    conn.Open();

                    return OleCmd.ExecuteScalar();

                }

            }

        }

        //执行sql语句
        public OleDbDataReader ExecuteReader(string sql,params OleDbParameter[] olePams)
        {
            OleDbConnection conn = new OleDbConnection(connStr);

            using (OleDbCommand oleCmd = new OleDbCommand(sql, conn))
            {

                if (olePams != null)
                {

                    oleCmd.Parameters.AddRange(olePams);
                }

                try
                {
                    conn.Open();
                    return oleCmd.ExecuteReader();
                }
                catch 
                {
                    conn.Close();
                    conn.Dispose();
                    throw;
                } 
            }
        }

        
    }
}
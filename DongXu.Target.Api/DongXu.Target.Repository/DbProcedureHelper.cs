using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DongXu.Target.Repository
{
    public class DbProcedureHelper
    {
        static string MyConnection = "Database='dxdatabase';Data Source=169.254.105.125;User ID=root;Password=1234567";

        static string sql = "data source = 169.254.105.125; dataBase=dxdatabase;Uid=root;pwd=1234567";


        /// <summary>
        /// 执行添加、删除、修改
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string ProcName, params MySqlParameter[] arr)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(sql))
                {
                    conn.Open();//打开数据库连接
                    MySqlCommand cmd = new MySqlCommand(ProcName, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;//定义执行的是存储过程
                    if (arr != null)
                        cmd.Parameters.AddRange(arr);//把参数添加到cmd对象中
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static DataTable ExecuteDt(string ProcName, params MySqlParameter[] arr)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(sql))
                {
                    MySqlCommand cmd = new MySqlCommand(ProcName, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;//定义执行的是存储过程
                    if (arr != null)
                        cmd.Parameters.AddRange(arr);//把参数添加到cmd对象中
                    DataTable dt = new DataTable("dt");
                    MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
                    
                    adt.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {

                return null;
            }

        }

    }
}

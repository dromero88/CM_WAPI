using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using CM_WAPI.SharedOPs;
using System.IO;

namespace CM_WAPI.SharedOPs
{
    public class DontSave : Attribute
    { }

    public class sharedOPs
    {
        public static bool canSave(PropertyInfo prop)
        {
            object[] attrs = prop.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                DontSave customAttr = attr as DontSave;
                if (customAttr != null)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<SqlParameter> getParametros(object oj) //reflection method engine
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            var prop = oj.GetType().GetProperties();
            foreach (var props in prop)
            {
                if (sharedOPs.canSave(props))
                {
                    parametros.Add(CM_WAPI.DataAcces.conexion.creaParametro(props.Name, CM_WAPI.DataAcces.conexion.getDbType(props.PropertyType.Name), ParameterDirection.Input, props.GetValue(oj, null)));
                }
            }
            return parametros;
        }

        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Logs\\";
            logFilePath = logFilePath  + System.DateTime.Today.ToString("yyyyMMdd") + "-Log" + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }
    }
}
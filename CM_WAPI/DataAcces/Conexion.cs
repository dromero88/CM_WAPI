using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CM_WAPI.DataAcces
{
    class conexion
    {
        private SqlConnection Con;
        private SqlTransaction Tran;
        private SqlCommand Command;
        

        public SqlCommand command { get; set; }


        public conexion()
        {
            string strConn = "";
            //Leemos conection string

            if (Properties.Settings.Default.CNFPruebas) { strConn = Properties.Settings.Default.ConPruebas; }
            else { strConn = Properties.Settings.Default.ConProduccion; }

            Con = new SqlConnection(strConn);

        }
        
        public void Abrir()
        {
            Con.Open();
        }

        public void Cerrar()
        {
            Con.Close();
        }

        public SqlConnection getConexion()
        {
            return this.Con;
        }
        public void AbrirTransaccion()
        {
            Tran = Con.BeginTransaction();
        }

        public void CommitTransaccion()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Tran.Commit();
            }
        }

        public void RollbackTransaccion()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Tran.Rollback();
            }
        }

        public int execNonQuery(string Comando)
        {
            command = new SqlCommand(Comando, Con);
            command.CommandTimeout = 0;
            command.Transaction = Tran;
            int result = command.ExecuteNonQuery();
            command.Dispose();
            return result;
        }

        public SqlDataReader execReader(string Comando)
        {
            command = new SqlCommand(Comando, Con);
            command.CommandTimeout = 0;
            command.Transaction = Tran;
            SqlDataReader resultado = command.ExecuteReader();
            command.Dispose();
            return resultado;
        }
        public DataTable execDataTable(string Comando)
        {
            SqlCommand command = new SqlCommand(Comando, Con);
            command.CommandTimeout = 0;
            command.Transaction = Tran;
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            command.Dispose();
            return dt;
        }

        public SqlDataReader execProcedure(string procedimiento, SqlParameter[] parametros)
        {
            command = new SqlCommand(procedimiento, Con);
            command.CommandTimeout = 0;
            command.CommandType = CommandType.StoredProcedure;
            command.Transaction = Tran;
            command.Parameters.AddRange(parametros);
            SqlDataReader dr = command.ExecuteReader();
            command.Dispose();
            return dr;
        }

        public static SqlParameter creaParametro(string nombreParametro, System.Data.DbType tipo, System.Data.ParameterDirection direccion, object valor)
        {

            SqlParameter nuevoParam = new SqlParameter();
            nuevoParam.ParameterName = nombreParametro;
            nuevoParam.DbType = tipo;
            nuevoParam.Direction = direccion;
            nuevoParam.Value = valor;
            return nuevoParam;
        }

        public static DbType getDbType(string systemType)
        {
            /*mapping to dbtypes*/
            var dbt = DbType.Object;
            if (systemType == "Int32")
            { dbt = DbType.Int32; }
            else
            { dbt = DbType.String; }
            /*end of mapping to dbtypes*/
            return dbt;
        }

    }
}
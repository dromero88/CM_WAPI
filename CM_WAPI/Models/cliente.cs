using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CM_WAPI.DataAcces;
using System.Data;
using System.Data.SqlClient;
using CM_WAPI.SharedOPs;


namespace WAPI.Models
{
    public class cliente
    {
        [DontSave]
        public int cd_cod_ext { get; set; }//Client DB Ident
        [Required]
        public string name { get; set; }
        public string last_name { get; set; }
        public string ident_doc { get; set; }
        public string company { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string postal { get; set; }
        public string alt_address { get; set; }
        public string movil_phone { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public int lopd { get; set; }
        [Required]
        public string web_origin { get; set; }
        public string user_name { get; set; }
        [DontSave]
        public List<encuesta> surveys = new List<encuesta>();

        public void save()
        {
            conexion con = new conexion();
            List<SqlParameter> _params = new List<SqlParameter>();
            _params = sharedOPs.getParametros(this);
            con.Abrir();
            con.AbrirTransaccion();
            try
            {
                SqlDataReader dr = con.execProcedure("INPUT_CLIENT_PROCEDURE", _params.ToArray());
                if (dr.HasRows)
                {while(dr.Read())
                    { cd_cod_ext = Int32.Parse(dr["CdCodExt"].ToString());}}
                dr.Close();
                foreach (encuesta srv in surveys)
                {
                    srv.cd_cod_ext = this.cd_cod_ext;
                    _params = sharedOPs.getParametros(srv);
                    SqlDataReader drenc = con.execProcedure("INPUT_SURVEY_PROCEDURE", _params.ToArray());
                    drenc.Close();
                }
                con.CommitTransaccion();
            }
            catch (Exception e)
            { con.RollbackTransaccion(); throw e;}
            finally {con.Cerrar();}
        }
    }

}
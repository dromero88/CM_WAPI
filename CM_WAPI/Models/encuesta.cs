using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CM_WAPI.DataAcces;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using CM_WAPI.SharedOPs;

namespace WAPI.Models
{
    public class encuesta
    {
        public int cd_cod_ext { get; set; }
        public string cd_campa { get; set; }
        public string model1 { get; set; }
        public string model2 { get; set; }
        public int n_val { get; set; }
        public string oserv { get; set; }
    }
}
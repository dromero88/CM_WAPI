using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WAPI.Models;
using Newtonsoft.Json.Linq;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CM_WAPI.SharedOPs;
using Newtonsoft.Json;

namespace WAPI.Controllers
{
    public class clienteController : ApiController
    {
        // GET: api/cliente
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/cliente
        public HttpResponseMessage Post([FromBody]cliente cli)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    sharedOPs.WriteLog("400 Bad Request|ModelState.IsValid|Error al validar la peticion, faltan campos o son invalidos.|" + System.DateTime.Now.ToString() + "|" + JsonConvert.SerializeObject(cli));
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    response.Content = new StringContent("Error al validar la peticion, faltan campos o son invalidos.");
                    return response;
                }
                else
                {
                    cli.save();
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                sharedOPs.WriteLog("500 Internal Server Error|" + e.StackTrace.ToString() + "|" + e.Message.ToString() + "|" + System.DateTime.Now.ToString() + "|" + JsonConvert.SerializeObject(cli));
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(e.Message.ToString());
                return response;
            }

        }

        // PUT: api/cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/cliente/5
        public void Delete(int id)
        {
        }
    }
}

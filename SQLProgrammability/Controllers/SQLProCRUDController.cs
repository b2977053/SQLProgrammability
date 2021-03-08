using SQLProgrammability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SQLProgrammability.Controllers
{
    public class SQLProCRUDController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]ProStoredProcedure proSP)
        {
            DateTime dNow = DateTime.Now;
            proSP.CreatedTime = dNow;
            proSP.UpdateTime = dNow;
            using (SQLPro db = new SQLPro())
            {
                db.ProStoredProcedure.Add(proSP);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]ProStoredProcedure proSPNew)
        {


            DateTime dNow = DateTime.Now;

            using (SQLPro db = new SQLPro())
            {
                ProStoredProcedure proSP = db.ProStoredProcedure.Find(id);

                if (proSP.Name != proSPNew.Name)
                {
                    proSP.Name = proSPNew.Name;
                }
                if (proSP.Execute != proSPNew.Execute)
                {
                    proSP.Execute = proSPNew.Execute;
                }
                if (proSP.Content != proSPNew.Content)
                {
                    proSP.Content = proSPNew.Content;
                }
                if (proSP.Remark != proSPNew.Remark)
                {
                    proSP.Remark = proSPNew.Remark;
                }
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

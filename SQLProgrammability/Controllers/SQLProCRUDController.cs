using SQLProgrammability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data.Entity;

namespace SQLProgrammability.Controllers
{
    public class SQLProCRUDController : ApiController
    {
        // GET api/values
        public IEnumerable<ProStoredProcedure> Get()
        {

            Exception exception = null;
            List<ProStoredProcedure> proSPs = new List<ProStoredProcedure>();
            using (SQLPro db = new SQLPro())
            {
                try
                {
                    proSPs = db.ProStoredProcedure.OrderByDescending(r=>r.CreatedTime).ToList();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            return proSPs;
        }

        // GET api/values/5
        public object Get(int id)
        {
            Exception exception = null;
            ProStoredProcedure proSP = null;
            using (SQLPro db = new SQLPro())
            {
                try
                {
                    proSP = db.ProStoredProcedure.Find(id);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            if (exception == null && proSP != null)
            {
                return proSP;
            }
            else
            {
                return exception;
            }
        }

        // POST api/values
        public object Post([FromBody]ProStoredProcedure proSP)
        {
            if (proSP == null)
            {
                return new { msg= "proSP is null !!" };
            }
            else if (proSP.Name == null)
            {
                return new { msg = "proSP.Name is null !!" };
            }
            else if (proSP.Execute == null)
            {
                return new { msg = "proSP.Execute is null !!" };
            }

            proSP.Name = proSP.Name.Trim();
            proSP.Execute = proSP.Execute.Trim();


            Exception exception = null;
            DateTime dNow = DateTime.Now;
            proSP.CreatedTime = dNow;
            proSP.UpdateTime = dNow;
            using (SQLPro db = new SQLPro())
            {
                try
                {
                    db.ProStoredProcedure.Add(proSP);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            if (exception == null)
            {
                return new { msg = "COMMIT" };
            }
            else
            {
                return exception;
            }
        }

        // PUT api/values/5
        public object Put(int id, [FromBody]ProStoredProcedure proSPNew)
        {
            proSPNew.Name = proSPNew.Name.Trim();
            proSPNew.Execute = proSPNew.Execute.Trim();

            Exception exception = null;

            DateTime dNow = DateTime.Now;

            using (SQLPro db = new SQLPro())
            {
                try
                {
                    ProStoredProcedure proSP = db.ProStoredProcedure.Find(id);

                    if (proSP != null)
                    {
                        if (!string.IsNullOrEmpty(proSPNew.Name))
                        {
                            proSP.Name = proSPNew.Name;
                        }
                        if (!string.IsNullOrEmpty(proSPNew.Execute))
                        {
                            proSP.Execute = proSPNew.Execute;
                        }
                        if (!string.IsNullOrEmpty(proSPNew.Content))
                        {
                            proSP.Content = proSPNew.Content;
                        }
                        if (!string.IsNullOrEmpty(proSPNew.Remark))
                        {
                            proSP.Remark = proSPNew.Remark;
                        }
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            if (exception == null)
            {
                return new { msg = "COMMIT" };
            }
            else
            {
                return exception;
            }
        }

        // DELETE api/SQLProCRUD
        public object Delete([FromBody]List<int> ids)
        {
            Exception exception = null;

            List<ProStoredProcedure> proSPs = new List<ProStoredProcedure>();
            using (SQLPro db = new SQLPro())
            {
                try
                {
                    proSPs = db.ProStoredProcedure.Where(r => ids.Any(_id => _id.Equals(r.Id))).ToList();

                    foreach (var proSP in proSPs)
                    {
                        db.Entry(proSP).State = EntityState.Deleted;
                        //db.ProStoredProcedure.Remove(proSP); // 刪除的另一個方法 (上下擇一)
                    }

                    if (proSPs.Count > 0)
                    {
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    exception = ex;
                }

                if (exception == null)
                {
                    if (proSPs.Count > 0)
                    {
                        return new { msg = "COMMIT" };
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return exception;
                }
            }
        }
    }
}

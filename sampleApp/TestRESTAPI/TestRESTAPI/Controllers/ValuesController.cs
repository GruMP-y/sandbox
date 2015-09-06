using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TestRESTAPI.Models;

namespace TestRESTAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// Gets the items from the DB.
        /// </summary>
        /// <returns>Returns the item list in JSON format</returns>

        public List<MyItem> Get()
        {
            List<MyItem> data = new List<MyItem>();

            using (var db = new TestDBEntities())
            {
                var temp = db.Items.ToList();

                foreach (Item itm in temp)
                {
                    MyItem newitem = new MyItem();
                    newitem.ID = itm.ID;
                    newitem.Value = itm.Value;

                    data.Add(newitem);
                }
            }

         
            return data; 
        }

        // GET api/values/5
        /// <summary>
        /// Retrieves the value of an item given the ID
        /// </summary>
        /// <param name="id">The ID of the item</param>
        /// <returns>The string value of the item.</returns>
        public string Get(int id)
        {
            string value = string.Empty;

            using (var db = new TestDBEntities())
            {
                var temp = from itm in db.Items
                           where itm.ID==id
                           select itm;

                if (temp.ToList().Count > 0)
                {
                    value = temp.ToList()[0].Value;
                }
                
            }
            return value;
        }

        // POST api/values
        /// <summary>
        /// Adds a new item on the DB
        /// </summary>
        /// <param name="value">The value of the item to be added</param>
        /// <returns></returns>
        public HttpResponseMessage Post(Item value)
        {
            int affectedRec = -1;
            using (var db = new TestDBEntities())
            {

                Item itm = new Item();
                itm.Value = value.Value;

                if (String.Compare(value.Value, "Error", true) != 0)
                {
                    db.Items.Add(itm);
                    affectedRec = db.SaveChanges();
                }
            }

            if (affectedRec > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK,"Data Recorded");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,"No data recorded");
            }
        }

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureTrainingDBLib;

namespace AzureTrainingWebAPI.Controllers
{
    public class EmailManagerController : Controller
    {
        AzureTrainingDBLib.AzureTrainingEntities objEntity = new AzureTrainingEntities();
        // GET: EmailManager
        public IEnumerable<AzureTrainingDBLib.EmailMessage> GetAllEmails()
        {
            var ouput = objEntity.EmailMessages.ToList();
            return ouput;
        }
        public string GetEmailStatus(int id)
        {
            var ouput = objEntity.EmailMessages.Where(w=> w.Id == id).FirstOrDefault().Status;
            return ouput;
        }

        // POST: EmailManager
        [HttpPost]
        public string SaveEmailData(AzureTrainingDBLib.EmailMessage emailMessage)
        {
            try
            {
                objEntity.EmailMessages.Add(emailMessage);
                objEntity.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed!"+ex.Message;
            }            
        }
    }
}
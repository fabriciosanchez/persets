using Persets.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persets.Backend.Data
{
    public class LogsDB
    {
        public enum eOperation
        {
            Put,
            Post,
            Delete,
        }

        public enum eEntity
        {
            User,
            Category,
            Content,
            ContentShare
        }

        public static async void AddLog(eOperation operation, eEntity entityDb, string EntityGuid, bool SuccessStatus)
        {
            using (var ctx = new PersetsDBEntities())
            {
                Logs log = new Logs();
                log.GUID = Guid.NewGuid().ToString();
                log.UserGUID = string.Empty;
                log.Operation = string.Format(
                    "Operation: {0} EntityDb: {1} EntityGuid: {2}",
                    operation.ToString(),
                    entityDb.ToString(),
                    EntityGuid.ToString());
                log.DateTimeOccurence = DateTime.Now;
                log.SuccessStatus = SuccessStatus;
                log.PublicIP = HttpContext.Current.Request.UserHostAddress.ToString();

                ctx.Logs.Add(log);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
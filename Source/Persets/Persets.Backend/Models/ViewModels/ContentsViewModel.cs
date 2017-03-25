using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Persets.Backend.Models.ViewModels
{
    
    public class ContentsViewModel 
    {
        public string GUID { get; set; }
        public string UserGUID { get; set; }
        public string CategoryGUID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string PhysicalFile { get; set; }
        public int ViewsNumber { get; set; }
        public int DownloasNumber { get; set; }
        public bool PrivacyPublic { get; set; }
    }
}
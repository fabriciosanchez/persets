using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persets.Backend.Models.ViewModels
{
    public class CategoryViewModel
    {
        public string GUID { get; set; }
        public string Category { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

    }
}
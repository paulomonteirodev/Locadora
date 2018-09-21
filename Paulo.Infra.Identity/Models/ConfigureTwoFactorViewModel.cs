using System.Collections.Generic;
using System.Web.Mvc;

namespace Paulo.Infra.Identity.Models
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}

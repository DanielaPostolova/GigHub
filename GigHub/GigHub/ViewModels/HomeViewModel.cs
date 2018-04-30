using System.Collections.Generic;
using GigHub.IdentityModels.DomainModels;

namespace GigHub.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcommingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}
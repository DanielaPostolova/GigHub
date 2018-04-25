using GigHub.IdentityModels.IdentityProviders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.IdentityModels.DomainModels
{
    public class Attendance
    {
        public ApplicationUser Attendee { get; set; }
        public Gig Gig { get; set; }


        [Key]
        [Column(Order = 1)]
        public string AttendeeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int GigId { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.IdentityModels.DomainModels
{
    public class Genre
    {
        public Genre()
        {
            this.Gigs = new HashSet<Gig>();
        }

        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Gig> Gigs { get; set; }
    }
}
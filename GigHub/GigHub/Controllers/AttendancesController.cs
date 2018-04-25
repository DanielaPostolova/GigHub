using GigHub.IdentityModels.DomainModels;
using GigHub.IdentityModels.IdentityProviders;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(Attendance dto)
        {
            var attendanceId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == attendanceId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists!");
            }

            var attendance = new Attendance
            {
                AttendeeId = attendanceId,
                GigId = dto.GigId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
}
}

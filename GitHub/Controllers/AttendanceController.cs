using GitHub.Dtos;
using GitHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GitHub.Controllers
{

    [Authorize]
    public class AttendanceController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendanceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendance.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {

                return BadRequest("Attendance Already Exists");
            }
            var attendance = new Attendance
            {

                GigId = dto.GigId,
                AttendeeId =userId


            };
            _context.Attendance.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}

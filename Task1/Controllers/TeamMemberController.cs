using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.DTO;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITIEntities context;

        public TeamMemberController(ITIEntities _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            List<memberDTO> members = context.TeamMembers.Select(member => new memberDTO
            {
                Name = member.Name,
                Email = member.Email,
                memberId=member.memberId,
               
            }).ToList();

            return Ok(members);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMemberById(int id)
        {

            var member = context.TeamMembers.Where(t => t.memberId == id).Select(member => new memberDTO
            {
                memberId = member.memberId,
                Name = member.Name,
                Email = member.Email,
 
            }).FirstOrDefault();
            if (member != null) { return Ok(member); }
            return NotFound();

        }
        [HttpPost]
        public IActionResult AddMember(memberDTO memberDTO)
        {
            if (ModelState.IsValid)
            {
                var member = new teamMember
                {
                    Name = memberDTO.Name,
                    Email = memberDTO.Email,
                    memberId = memberDTO.memberId,
                };
                context.TeamMembers.Add(member);
                context.SaveChanges();
                return Ok(member);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult UpdateMember(memberDTO memberDTO, int id)
        {
            if (ModelState.IsValid)
            {
                teamMember oldMember = context.TeamMembers.FirstOrDefault(e => e.memberId == id);
                if (oldMember != null)
                {
                    oldMember.memberId = id;
                    oldMember.Name= memberDTO.Name;
                    oldMember.Email= memberDTO.Email;
                    context.SaveChanges();
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult DeleteMember(int id)
        {
            try
            {
                var member = context.TeamMembers.FirstOrDefault(e => e.memberId == id);
                if (member != null)
                {
                    context.Remove(member);
                    context.SaveChanges();
                    return StatusCode(StatusCodes.Status204NoContent);

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

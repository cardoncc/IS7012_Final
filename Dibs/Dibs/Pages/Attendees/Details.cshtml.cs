using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dibs.Data;
using Dibs.Models;

namespace Dibs.Pages.Attendees
{
    public class DetailsModel : PageModel
    {
        private readonly Dibs.Data.DibsContext _context;

        public DetailsModel(Dibs.Data.DibsContext context)
        {
            _context = context;
        }

        public Attendee Attendee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Attendee = await _context.Attendee
                .Include(a => a.Meeting)
                .Include(a => a.MeetingUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Attendee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

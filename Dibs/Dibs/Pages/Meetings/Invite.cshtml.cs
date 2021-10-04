using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dibs.Data;
using Dibs.Models;

namespace Dibs.Pages.Meetings
{
    public class InviteModel : PageModel
    {
        private readonly Dibs.Data.DibsContext _context;

        //connect to database
        public InviteModel(Dibs.Data.DibsContext context)
        {
            _context = context;
        }

        //added page model attributes
        public Meeting NewMeeting { get; set; }
        public List<MeetingUser> UserList { get; set; }
        [BindProperty]
        public InviteFormModel Form { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Find the meeting that was just created
            NewMeeting = _context.Meeting.Find(id);
            //Find all of the users
            UserList = _context.MeetingUser.ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewMeeting = _context.Meeting.Find(id);
            
            foreach(int? uid in Form.UserIds)
            {
                if (uid == null) { continue; }//skip blank entries
                //Create an attendee reccord
                var ma = new Attendee { Meeting = NewMeeting, MeetingUserId = uid };
                _context.Attendee.Add(ma);
            }

            //_context.Attendee.Add(Attendee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

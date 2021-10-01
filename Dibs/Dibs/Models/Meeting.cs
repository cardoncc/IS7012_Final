using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dibs.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Meeting Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Meeting Day")]
        public DateTime MeetDate { get; set; }

        [Required]
        [DisplayName("Number of People Invited to the Meeting")]
        public int NumOfInvites { get; set; }


        [DisplayName("Meeting Notes")]
        public string Notes { get; set; }
       
        //Meeting To MeetingUser
        [DisplayName("Host Name")]
        public MeetingUser MeetingUser { get; set; }
        public int MeetingUserId { get; set; }

        //Meeting to Attendee
        public List<Attendee> Attendees { get; set; }




    }
}

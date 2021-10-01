using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dibs.Models
{
    public class Attendee
    {
        public int Id { get; set; }

        //MeetingUser to Attendee
        public MeetingUser MeetingUser { get; set; }
        public int MeetingUserId { get; set; }

        //MeetingUser to Meeting
        public Meeting Meeting { get; set; }
        public int MeetingId { get; set; }

        [DisplayName("Attending")]
        [DefaultValue(false)]
        public bool IsAttending { get; set; }

        [StringLength(90)]
        public string Message { get; set; }




    }
}

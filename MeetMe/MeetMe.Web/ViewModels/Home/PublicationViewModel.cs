using MeetMe.Data.Models;
using System;
using System.Collections.Generic;

namespace MeetMe.Web.ViewModels.Home
{
    public class PublicationViewModel
    {
        public string Content { get; set; }
        
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
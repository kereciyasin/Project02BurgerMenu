using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project02BurgerMenu.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string AboutTitle { get; set; }
        public string Title { get; set; }
        public string AboutDescription { get; set; }

        public string ImgUrl { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MapLocation { get; set; }
        
    }
}
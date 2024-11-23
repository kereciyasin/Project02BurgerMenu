using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project02BurgerMenu.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }    
    }
}
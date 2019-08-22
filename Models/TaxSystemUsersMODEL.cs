using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_MVCapp_SERAFIN.Models
{
    public class TaxSystemUsersMODEL
    {
        //[Key]
        public int loginId { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string description { get; set; }

        //[Display(Name = "Is this user an Administrator of the system?")]
        //[Required(ErrorMessage = "Please tell us is this User has to have Administrator competences")]
        //[StringLength(3, MinimumLength = 2)]
        public string isAdmin { get; set; }
    }
}
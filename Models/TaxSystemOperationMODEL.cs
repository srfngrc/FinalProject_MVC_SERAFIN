using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_MVCapp_SERAFIN.Models
{
    public class TaxSystemOperationMODEL
    {
        //[Key]
        public int operationId { get; set; }
        public string isin { get; set; }

        //[Display(Name = "Date you bougth the article or item")]
        //[Required(ErrorMessage = "Please tell us when you bougth that item")]
        //[Range(typeof(DateTime), "1/1/2000", "08/20/2019", ErrorMessage = "Your response must be between {1} and {2}")]
        public DateTime purchaseDate { get; set; }

        //[Display(Name = "Date you sold the article or item")]
        //[Required(ErrorMessage = "Please tell us when you sold that item")]
        //[Range(typeof(DateTime), "1/1/2000", "08/20/2019", ErrorMessage = "Your response must be between {1} and {2}")]
        public DateTime sellDate { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using cSharpBelt.Extensions;
namespace cSharpBelt.Models
{
    public class Happening
    {
        [Key]
        public int HappeningID {get;set;}

        [Required(ErrorMessage="What are we going to be doing?")]
        [Display(Name="Activity Title: ")]
        public string HappeningTitle {get;set;}


        [Required(ErrorMessage="When is this happening? Or have you decided yet?")]
        // [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name="Date: ")]
        public DateTime HappeningDay {get; set; }

        [Required(ErrorMessage="What time is this thing going down?")]
        [DataType(DataType.Time)]
        [Display(Name="Time: ")]
        public DateTime HappeningTime {get;set;}

        [Required(ErrorMessage="How long will this event last?")]
        [Display(Name="Duration: ")]
        [Range(0,double.PositiveInfinity)]
        public int Duration {get;set;}

        [Required(ErrorMessage="How Long will this event last?")]
        public string Length {get;set;}

        [MinLength(10)]
        [Display(Name="Description: ")]
        public string Description {get;set;}
//ONE TO MANY FOR ONE CREATOR OF "HAPPENING"
        public int UserID {get;set;}
        public User UserCreator {get; set;}

//MANY TO MANY FOR GUESTS ATTENDING
        public List<Attending> GuestsAttending {get;set;}


        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}
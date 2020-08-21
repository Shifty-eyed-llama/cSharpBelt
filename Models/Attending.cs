using System;
using System.ComponentModel.DataAnnotations;
namespace cSharpBelt.Models
{

    //GUEST IS MANY TO MANY TABLE OF USERS(MANY) ATTENDING ACTIVITY(MANY)
    public class Attending
    {
        [Key]
        //JUST FOR KEEPING TRACK OF MANY TO MANY
        public int AttendingID {get;set;}

        //GUEST ID
        public int UserID {get;set;}
        public User User {get;set;}

        public int HappeningID {get;set;}
        public Happening Happening {get;set;}


        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}
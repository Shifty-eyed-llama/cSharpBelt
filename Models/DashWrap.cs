using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cSharpBelt.Models
{
    public class DashWrapper
    {
        public User UserThis {get;set;}
        public List<Happening> AllHappening {get;set;}
    }
}
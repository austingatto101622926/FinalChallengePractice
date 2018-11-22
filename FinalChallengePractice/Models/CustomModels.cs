using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace FinalChallengePractice.Models
{
    public class CoffeeDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoffeeDateId { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public List<Shout> Shouts { get; set; }
    }

    public class Shout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoutId { get; set; }
        public CoffeeDate CoffeeDate { get; set; }
        public AspNetUser Member { get; set; }
        public double Amount { get; set; }
    }
}
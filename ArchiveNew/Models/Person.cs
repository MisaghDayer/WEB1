using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArchiveNew.Models
{
    public class Person
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        public int Role_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Family { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(15)]
        public string Password { get; set; }

        [Required]
        public bool ACTIVE { get; set; }


        public Person()
        {
            ACTIVE = true;
            Password = "1234";
        }
    }
}
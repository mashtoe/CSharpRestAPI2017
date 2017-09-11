using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp2BLL.BusinessObjects
{
    public class CustomerBO
    {
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public string FullName
        {
            get { return $"{Name} {Lastname}"; }
        }

        public CustomerBO()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    [Table("Customer")]
    public class Customer
    {
        public int CustomerId { get; set; }
    }
}

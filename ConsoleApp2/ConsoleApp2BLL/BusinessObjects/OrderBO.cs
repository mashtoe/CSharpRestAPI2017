using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2BLL.BusinessObjects
{
    public class OrderBO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}

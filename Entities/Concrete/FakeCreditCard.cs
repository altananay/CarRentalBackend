using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FakeCreditCard : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}

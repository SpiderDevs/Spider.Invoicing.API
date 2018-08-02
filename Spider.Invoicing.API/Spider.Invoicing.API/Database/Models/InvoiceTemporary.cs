using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Database.Models
{
    public class InvoiceTemporary
    {
        [Key]
        public Guid InvoiceTemporaryId { get; set; }

        public Guid? InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "money")]
        public decimal GrossAmmount { get; set; }

        [Column(TypeName = "money")]
        public decimal NetAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal VatAmount { get; set; }

        public InvoiceTemporary()
        {
            InvoiceTemporaryId = new Guid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBAccountingRestriction
    {
        [Key]
        public int IdaccountingRestrictions { get; set; }
        public int NumberaccountingRestrictions { get; set; }
        public string AccountingName { get; set; }
        public string BondType { get; set; }
        public decimal Debtor { get; set; }
        public decimal creditor { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlStatementPurchase")]
        [MaxLength(500, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength500")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string Statement { get; set; }
        [MaxLength(500, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength500")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string? Nouts { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
    }
}


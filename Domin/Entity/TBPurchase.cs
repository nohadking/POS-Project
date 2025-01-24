using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class TBPurchase 
    {
        [Key] 
        public int IdPurchase { get; set; }
        public int IdSupplier { get; set; }
        public int IdPaymentMethod { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlStatementPurchase")]
        [MaxLength(500, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength500")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string Statement { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlPurchaseDate")]
        public DateOnly PurchaseDate { get; set; }
        public int PurchaseNumber { get; set; }
        public int? PurchaseSubNumber { get; set; }
        public int IdProduct { get; set; }
        public int IdUnit { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlQuantity")]
        public int Quantity { get; set; }
        public int? FreeQuantity { get; set; }
        public int AllQuantity { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlPurchasePrice")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "VlTotal")]
        public decimal Total { get; set; }
        public decimal? SingleDiscount { get; set; }
        public decimal? shipping { get; set; }
        [MaxLength(500, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MaxLength500")]
        [MinLength(3, ErrorMessageResourceType = typeof(Resource.ResourceData), ErrorMessageResourceName = "MinLength3")]
        public string? Nouts { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAll { get; set; }
        public string DataEntry { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public bool CurrentState { get; set; }
      











    }
}

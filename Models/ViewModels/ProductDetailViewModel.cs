using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public int ProductDetailViewModelID { get; set; }
        public int ProductID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string ImageUrl { get; set; }
        public bool IsPrefered { get; set; }
        [Range(0, int.MaxValue)]
        public int InStock { get; set; }
        [Range(0, int.MaxValue)]
        public int NumberOfOrders { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCreate { get; set; }
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<SelectListItem> CategoryNames { get; set; }
    }
}

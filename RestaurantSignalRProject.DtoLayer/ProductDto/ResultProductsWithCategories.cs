﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSignalRProject.DtoLayer.ProductDto
{
    public class ResultProductsWithCategories
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryCategoryName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

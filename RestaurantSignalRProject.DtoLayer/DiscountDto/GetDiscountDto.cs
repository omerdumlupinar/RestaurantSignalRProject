﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSignalRProject.DtoLayer.DiscountDto
{
    public class GetDiscountDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

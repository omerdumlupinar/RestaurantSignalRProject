﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSignalRProject.DtoLayer.ContentDto
{
    public class CreateContentDto
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterDescription { get; set; }
    }
}

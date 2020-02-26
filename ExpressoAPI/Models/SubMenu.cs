﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressoAPI.Models
{
    public class SubMenu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}
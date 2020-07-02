﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRIS.WEB.Models
{
    public class Test
    {
        public DateTime DateOfTest { get; set; }
        public int TestId { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
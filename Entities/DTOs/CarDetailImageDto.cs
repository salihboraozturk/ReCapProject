using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailImageDto:IDto
    {
        public CarDetailDto Car { get; set; }
        public List<CarImage> ImagePath { get; set; }
    }
}

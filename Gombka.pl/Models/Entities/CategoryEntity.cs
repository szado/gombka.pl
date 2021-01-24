using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gombka.pl.Models.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VideoEntity> Videos { get; set; }
    }
}

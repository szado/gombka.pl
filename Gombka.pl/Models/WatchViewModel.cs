using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gombka.pl.Models.Entities;

namespace Gombka.pl.Models
{
    public class WatchViewModel
    {
        public VideoEntity Video { get; set; }
        public VoteEntity? VoteEntity { get; set; }
    }
}

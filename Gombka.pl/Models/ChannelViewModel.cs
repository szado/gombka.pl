using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gombka.pl.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Gombka.pl.Models
{
    public class ChannelViewModel
    {
        public IQueryable<VideoEntity> Videos { get; set; }
        public IdentityUser User { get; set; }
        public VoteEntity? Votes { get; set; }
    }
}

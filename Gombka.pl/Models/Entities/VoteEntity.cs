using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Gombka.pl.Models.Entities
{
    public enum VoteTypes
    {
        Positive,
        Negative
    }

    public class VoteEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int VideoId { get; set; }
        public VideoEntity Video { get; set; }
        public VoteTypes Type { get; set; }
    }
}
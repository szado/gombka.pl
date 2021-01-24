using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int VideoId { get; set; }
        public VideoEntity Video { get; set; }
        public VoteTypes Type { get; set; }
    }
}

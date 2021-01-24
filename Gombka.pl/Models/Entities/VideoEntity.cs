using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gombka.pl.Models.Entities
{
    public class VideoEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }
        public int ViewsCounter { get; set; }
        public List<VoteEntity> Votes { get; set; }
    }
}

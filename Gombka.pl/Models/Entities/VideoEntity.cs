using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Gombka.pl.Models.Entities
{
    public class VideoEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }
        public int ViewsCounter { get; set; }
        public List<VoteEntity> Votes { get; set; }
        public string FileName { get; set; }
    }
}
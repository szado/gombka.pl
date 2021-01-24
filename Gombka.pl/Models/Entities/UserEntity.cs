﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gombka.pl.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<VideoEntity> Videos { get; set; }
        public List<VoteEntity> Votes { get; set; }
    }
}

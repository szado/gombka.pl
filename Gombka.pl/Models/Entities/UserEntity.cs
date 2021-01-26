using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Gombka.pl.Attributes;

namespace Gombka.pl.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        [NoSpace]
        [Alphanum]
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login jest wymagany")]
        [StringLength(16, ErrorMessage = "Login musi zawierać pomiędzy {2} i {1} znaków.", MinimumLength = 3)]
        public string Login { get; set; }
        [NoSpace]
        [Alphanum]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(32, ErrorMessage = "Hasło musi zawierać pomiędzy {2} i {1} znaków.", MinimumLength = 8)]
        public string Password { get; set; }
        public List<VideoEntity> Videos { get; set; }
        public List<VoteEntity> Votes { get; set; }
    }
}

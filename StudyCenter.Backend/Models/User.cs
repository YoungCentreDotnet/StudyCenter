﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LinqToDB.Mapping;

namespace StudyCenter.Backend.Models
{
    public class User
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string FirsName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTimeOffset DataOfBrith { get; set; }
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [PasswordPropertyText]
        [MaxLength(18)]
        public string Password { get; set; }
    }
}
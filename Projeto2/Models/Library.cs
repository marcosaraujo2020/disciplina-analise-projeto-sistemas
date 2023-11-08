using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Models;

namespace Models
{
    public class Library
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? address { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<FacultyMember>? FacultyMembers { get; set; }
        public virtual ICollection<ReferenceBook>? ReferenceBooks { get; set; }
        public virtual ICollection<GeneralBook>? GeneralBooks { get; set; }

    }
}
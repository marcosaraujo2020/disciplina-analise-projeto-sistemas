using System.ComponentModel.DataAnnotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Models;

namespace Models
{
    public class Student : Member
    {
        public string? sName { get; set; }        
        public string? Studentcoll { get; set; }  
        public int LibraryId { get; set; }
        public virtual Library? Library { get; set; }      
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Book
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int age { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }   

        public virtual Author Author { get; set; }






    }
}
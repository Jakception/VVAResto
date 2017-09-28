﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VVAResto.Models
{
    public class Annulation
    {
        [Key]
        [Column(Order = 1)]
        public int Identifiant { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CodeTM { get; set; }
        [Key]
        [Column(Order = 3)]
        public DateTime DateMenu { get; set; }
    }
}
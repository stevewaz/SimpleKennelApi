using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleKennelApi.Models
{
    public class Pet
    {
        public int PetId {get;set;}
        public string PetName{get;set;}
        public string PetType{get;set;}
        public string PetBread{get;set;}

    }
}
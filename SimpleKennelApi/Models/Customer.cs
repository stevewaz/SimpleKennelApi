using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleKennelApi.Models
{
    public class Customer
    {
        public int CustomerId {get;set;}
        public string FirstName {get;set;}
        public string LastName{get;set;}
        public string Address {get;set;}
        public string Address2 {get;set;}
        public string State{get;set;}
        public string ZipCode{get;set;}
        public string PhoneNumber {get;set;}
        public string EmailAddress {get;set;}
        public List<Pet> Pets {get;set;}
    } 
}
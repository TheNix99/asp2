using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models;

[Index(nameof(Brand))] // Vytváření indexu
    public class NewSocks
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Brand { get; set; }
        public SockSize Size { get; set; }
        public decimal Price { get; set; }

        [Range(0,100)]
        public int OnStock { get; set; }

    }



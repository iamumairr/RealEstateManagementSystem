using System.ComponentModel.DataAnnotations;

namespace RealEstateManagementSystem.Models
{
    public class Home
    {
        [Key]
        public int HomeId { get; set; }
        public int CategoryId { get; set; }
        public string? Address { get; set; }
        public HomeStatus Status { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal SquareFoot { get; set; }
        public int NoOfBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public DateTime YearBuilt { get; set; }
        public string? ImageUrl { get; set; }
        public int OwnerId { get; set; }
        public int ZipCode { get; set; }
        public Owner? Owner { get; set; }
        public Category? Category { get; set; }
    }

    public enum HomeStatus
    {
        Available, Sold, Off_The_Market
    }
}

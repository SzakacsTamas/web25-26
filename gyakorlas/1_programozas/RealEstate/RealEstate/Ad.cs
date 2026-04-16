using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Ad
    {
        public int Area;
        public Category Category;
        public DateTime CreateAt;
        public string Description;
        public int Floors;
        public bool FreeOfCharge;
        public int Id;
        public string ImageUrl;
        public string LatLong;
        public int Rooms;
        public Seller Seller;

        public Ad(int area, Category category, DateTime createAt, string description, int floors, bool freeOfCharge, int id, string imageUrl, string latLong, int rooms, Seller seller )
        {
            Area = area;
            Category = category;
            CreateAt = createAt;
            Description = description;
            Floors = floors;
            FreeOfCharge = freeOfCharge;
            Id = id;
            ImageUrl = imageUrl;
            LatLong = latLong;
            Rooms = rooms;
            Seller = seller;
        }
    }
}

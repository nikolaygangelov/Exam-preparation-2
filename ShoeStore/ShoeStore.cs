using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();//!!!!!
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }

        public List<Shoe> Shoes
        {
            get { return shoes; }
           // set { shoes = value; }
        }

        public int Count
        {
            get { return shoes.Count; }
            //set { myVar = value; }
        }


        public string AddShoe(Shoe shoe)
        {
            if (shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            else
            {
                shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
        }

        public int RemoveShoes(string material)
        {
            return shoes.RemoveAll(s => s.Material == material);
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return shoes.FindAll(s => s.Type.ToLower() == type.ToLower());
        }

        public Shoe GetShoeBySize(double size)
        {
            return shoes.FindAll(s => s.Size == size).FirstOrDefault();
        }

        public string StockList(double size, string type)
        {
            List<Shoe> stockList = shoes.FindAll(s => s.Size == size && s.Type == type);

            StringBuilder sb = new StringBuilder();

            if (!stockList.Any())
            {
                return $"No matches found!";
            }
            else
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (Shoe shoe in stockList)
                {
                    sb.AppendLine(shoe.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}

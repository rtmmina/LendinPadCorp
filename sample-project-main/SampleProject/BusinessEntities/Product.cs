using System;
using System.Collections.Generic;
using System;

namespace BusinessEntities
{    public class Product : IdObject
    {
        private string _name;
        private string _description;
        private string _category;
        private decimal _price;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public string Category
        {
            get => _category;
            private set => _category = value;
        }
        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name)) 
                throw new ArgumentNullException("name was not provided.");
            _name = name;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("description was not provided.");
            _description = description;
        }

        public void SetCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                throw new ArgumentNullException("category was not provided.");
            _category = category;
        }

        public void SetPrice(decimal price)
        {
            _price = price;
        }
    }
}

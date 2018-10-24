using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
   public  class Cart
   {
        private List<CartLine> _lineCollection = new List<CartLine>();

       public IEnumerable<CartLine> Lines
       {
           get { return _lineCollection; }
       }

       public void AddItem(Product product, int quantity)
       {
           CartLine line = _lineCollection.FirstOrDefault(p => p.Product.ProductID == product.ProductID);

           if (line == null)
           {
               _lineCollection.Add(new CartLine
               {
                   Product =  product,
                   Quantity = quantity
               });
           }
           else
           {
               line.Quantity+= quantity;
           }
       }

       public void RemoveLine(Product product)
       {
           _lineCollection.RemoveAll(p=>p.Product.ProductID == product.ProductID);
       }

       public decimal ComputeTotalValue()
       {
           return _lineCollection.Sum(p => p.Product.Price * p.Quantity);
       }

       public void Clear()
       {
           _lineCollection.Clear();
       }

   }
}

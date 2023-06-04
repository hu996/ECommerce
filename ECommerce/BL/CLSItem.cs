using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.BL
{
    public interface IIitem
    {
        List<Item> GetAll();
        bool Save(Item item);
        Item GetById(int? ItemId);
        bool Edit(Item item);
        bool Delete(int? ItemId);

    }
    public class CLSItem:IIitem
    {
        private readonly ECommerceContext _context;
        public CLSItem(ECommerceContext context) 
        {
            _context = context;
        }
        public List<Item> GetAll()
        {
            try
            {
                List<Item> MyItem = _context.Items.ToList();
                return MyItem;
            }
            catch(Exception Ex)
            {
                return new List<Item>();
            }
           
        }
        public bool Save(Item item)
        {
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch(Exception Ex)
            {
                return false;
            }
        }
        public Item GetById(int? ItemId)
        {
            try
            {
               var result= _context.Items.FirstOrDefault(x => x.ItemId == ItemId);
                return result;
            }
            catch(Exception Ex)
            {
                return new Item();
            }
        }
        public bool Edit(Item item) 
        {
            try
            {
                var result = _context.Items.FirstOrDefault(x=>x.ItemId==item.ItemId);
                result.ItemName = item.ItemName;
                result.SalesPrice = item.SalesPrice;
                result.PurchasPrice = item.PurchasPrice;
                result.ItemImage = item.ItemImage;
                result.Category.CategoryName = item.Category.CategoryName;
                _context.Update(result);
                return true;
            }
            catch(Exception Ex)
            {
                return false;
            }
        }
        public bool Delete(int? ItemId)
        {
            try
            {
                var result = _context.Items.FirstOrDefault(x => x.ItemId == ItemId);
                _context.Items.Remove(result);
                _context.SaveChanges();
                return true;
            }
            catch(Exception Ex)
            {
                return false;
            }
        }
    }
}

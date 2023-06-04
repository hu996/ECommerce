using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce.BL
{
	public interface IICategory
	{
		List<Category> GetAll();
		bool Create(Category cat);
		bool Edit(Category category);
		Category GetById(int CategoryId);
		bool Delete(int? CategoryId);

    }
	public class CLSCategory:IICategory
	{
		private readonly ECommerceContext _context;
		public CLSCategory(ECommerceContext context)
		{
			_context = context;
		}
		public List<Category> GetAll()
		{
			try
			{
				var result= _context.Categories.ToList();
				return result;
			}
			catch(Exception ex)
			{
				return new List<Category>();
			}
		}
		public bool Create(Category cat)
		{
			try
			{
				_context.Add(cat);
				_context.SaveChanges();
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}

		}
		public Category GetById(int CategoryId) 
		{
			try
			{
				var result=_context.Categories.FirstOrDefault(x => x.CategoryId == CategoryId);
				return result;
			}
			catch(Exception ex)
			{
				return new Category();
			}
			
		}
		public bool Edit(Category category)
		{
			try
			{
				var result=_context.Categories.FirstOrDefault(x=>x.CategoryId==category.CategoryId);
				result.CategoryName=category.CategoryName;
				result.CategoryId=category.CategoryId;
				_context.Categories.Update(result);
				_context.SaveChanges();
				//_context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				return true;
			}
			catch(Exception Ex)
			{
				return false;
			}
		}
		public bool Delete(int? CategoryId) 
		{
			try
			{
				var result = _context.Categories.FirstOrDefault(x => x.CategoryId == CategoryId);
				_context.Categories.Remove(result);
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

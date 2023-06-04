using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerce.BL
{
    public interface IISlider
    {
        List<Slider> GetAll();
        Slider GetById(int id);
        bool Update(Slider slider);
        bool Create(Slider slider);
        bool Delete(int? SliderId);



    }
    public class CLSSlider:IISlider
    {
        private readonly ECommerceContext _context;
        public CLSSlider(ECommerceContext context)
        {
            _context = context;
        }
        public List<Slider> GetAll()
        {
           
           List<Slider>MySlider= _context.Sliders.OrderBy(x=>x.SliderId).ToList();
            return MySlider;
        }
        public Slider GetById(int id)
        {
           
            var result=_context.Sliders.FirstOrDefault(x=>x.SliderId==id);
            return result;
        }
        public bool Create(Slider slider)
        {
            try
            {
              
                _context.Sliders.Add(slider);
                _context.SaveChanges();
                return true;
                
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Update(Slider slider)
        {
          
            //ctr.Entry(slider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result=_context.Sliders.FirstOrDefault(x=>x.SliderId==slider.SliderId);
            result.SliderImage=slider.SliderImage;
            _context.Sliders.Update(slider);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int? SliderId)
        {
            try
            {
              
               var slider= _context.Sliders.FirstOrDefault(x => x.SliderId == SliderId);
                _context.Sliders.Remove(slider);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }
        }
    }
}

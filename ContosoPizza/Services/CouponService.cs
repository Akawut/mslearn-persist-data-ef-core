using ContosoPizza.Models;
using ContosoPizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Services;

public class CouponService
{
    private readonly PromotionsContext _context;

    public CouponService(PromotionsContext context)
    {
        _context = context;
    }

    public IEnumerable<Coupon> GetAll()
    {
        return _context.Coupons
            .AsNoTracking()
            .ToList();
    }

    public ActionResult<Coupon> GetById(int id)
    {
        var item = _context.Coupons.FirstOrDefault(c => c.Id == id);
    
        // Create a new Coupon object and map values from the retrieved item
        var res = new Coupon {
            Id = item.Id,
            Description = item.Description,
            Expiration = item.Expiration
        };

        return res; // Return the mapped Coupon object
        }


    /// ...
    /// CRUD operations removed for brevity
    /// ...
}
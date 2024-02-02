using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class CouponController : ControllerBase
{
    CouponService _service;

    public CouponController(CouponService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Coupon> Get()
    {
        return _service.GetAll()
            .ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Coupon> GetById(int id)
    {
        var coupon = _service.GetById(id);

        if(coupon is not null)
        {
            return coupon;
        }
        else
        {
            return NotFound();
        }
    }
}
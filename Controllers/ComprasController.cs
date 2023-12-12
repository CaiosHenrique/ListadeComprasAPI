using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListadeCompras.Data;
using ListadeCompras.Models;

namespace ListadeCompras.Controllers
{
   
    public class ComprasController : Controller
    {
       
        private readonly DataContext _context;

        public ComprasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var compras = await _context.Compras.ToListAsync();
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var compra = await _context.Compras.FindAsync(id);
                return Ok(compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Compras compra)
        {
            try
            {
                _context.Compras.Add(compra);
                await _context.SaveChangesAsync();
                return Ok(compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Compras compra)
        {
            try
            {
                if (id != compra.Id)
                    return NotFound();

                _context.Entry(compra).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var compra = await _context.Compras.FindAsync(id);
                if (compra == null)
                    return NotFound();

                _context.Compras.Remove(compra);
                await _context.SaveChangesAsync();
                return Ok(compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


    }
        
    }
}
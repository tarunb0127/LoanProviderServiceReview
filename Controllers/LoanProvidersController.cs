using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanProviderService.Data;
using LoanProviderService.Models;

namespace LoanProviderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanProvidersController : ControllerBase
    {
        private readonly LoanProviderDbContext _context;

        public LoanProvidersController(LoanProviderDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanProvider>>> GetloanProviders()
        {
            return await _context.loanProviders.ToListAsync();
        }

        // GET: api/LoanProviders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanProvider>> GetLoanProvider(int id)
        {
            var loanProvider = await _context.loanProviders.FindAsync(id);

            if (loanProvider == null)
            {
                return NotFound();
            }

            return loanProvider;
        }

        // PUT: api/LoanProviders/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanProvider(int id, LoanProvider loanProvider)
        {
            if (id != loanProvider.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanProviderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanProviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanProvider>> PostLoanProvider(LoanProvider loanProvider)
        {
            _context.loanProviders.Add(loanProvider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanProvider", new { id = loanProvider.Id }, loanProvider);
        }

        // DELETE: api/LoanProviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanProvider(int id)
        {
            var loanProvider = await _context.loanProviders.FindAsync(id);
            if (loanProvider == null)
            {
                return NotFound();
            }

            _context.loanProviders.Remove(loanProvider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanProviderExists(int id)
        {
            return _context.loanProviders.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentDetailsContext _context;

        public PaymentDetailsController(PaymentDetailsContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetail()
        {
          if (_context.PaymentDetail == null)
          {
              return NotFound();
          }
            return await _context.PaymentDetail.ToListAsync();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetails>> GetPaymentDetails(int id)
        {
          if (_context.PaymentDetail == null)
          {
              return NotFound();
          }
            var paymentDetails = await _context.PaymentDetail.FindAsync(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return paymentDetails;
        }

        // PUT: api/PaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetails(int id, PaymentDetails paymentDetails)
        {
            if (id != paymentDetails.PaymentDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.PaymentDetail.ToListAsync());
        }

        // POST: api/PaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentDetails)
        {
          if (_context.PaymentDetail == null)
          {
              return Problem("Entity set 'PaymentDetailsContext.PaymentDetail'  is null.");
          }
            _context.PaymentDetail.Add(paymentDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetail.ToListAsync());
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails(int id)
        {
            if (_context.PaymentDetail == null)
            {
                return NotFound();
            }
            var paymentDetails = await _context.PaymentDetail.FindAsync(id);
            if (paymentDetails == null)
            {
                return NotFound();
            }

            _context.PaymentDetail.Remove(paymentDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetail.ToListAsync());
        }

        private bool PaymentDetailsExists(int id)
        {
            return (_context.PaymentDetail?.Any(e => e.PaymentDetailsId == id)).GetValueOrDefault();
        }
    }
}

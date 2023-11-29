using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWII6_Models.Dtos;
using SWII6_Models.Utils;
using SWII6_TP03.Context;

namespace SWII6_API.Controllers
{
    [Route("carros")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly TpContext _context;

        public CarroController(TpContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id == null || _context.Carros == null)
                return NotFound();

            var carro = await _context.Carros.FirstOrDefaultAsync(m => m.Id == id);

            if (carro == null)
                return NotFound();

            return Ok(carro);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carros = await _context.Carros.ToListAsync();

            if (carros == null || carros.Count <= 0)
                return NotFound();

            return Ok(carros);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarroCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dto.toModel());
                var carro = await _context.SaveChangesAsync();
                return Created("", carro);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id == null || _context.Carros == null)
                return NotFound();

            var carro = await _context.Carros.FirstOrDefaultAsync(m => m.Id == id);

            if (carro == null)
                return NotFound();

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CarroUpdateDTO dto)
        {
            if (id == null || _context.Carros == null)
                return NotFound();

            var carro = await _context.Carros.FirstOrDefaultAsync(m => m.Id == id);

            if (carro == null)
                return NotFound();

            carro.toUpdateWithDto(dto);

            _context.Carros.Update(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

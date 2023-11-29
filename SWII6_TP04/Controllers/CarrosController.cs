using Microsoft.AspNetCore.Mvc;
using SWII6_TP04.Services;
using SWII6_Models.Dtos;

namespace SWII6_TP03.Controllers;

public class CarrosController : Controller
{
    private readonly CarroService _carroService;

    public CarrosController(CarroService carroService)
    {
        _carroService = carroService;
    }

    // GET: Carros
    public async Task<IActionResult> Index()
    {
        var carros = await _carroService.GetAll();
        return View(carros);
    }

    // GET: Carros/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var carro = await _carroService.Get((int)id);
        return View(carro);
    }

    // GET: Carros/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Carros/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CarroCreateDTO carro)
    {
        if (ModelState.IsValid)
        {
            await _carroService.Create(carro);
            return RedirectToAction(nameof(Index));
        }

        return View(carro);
    }

    // GET: Carros/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var carro = await _carroService.Get((int)id);

        if (carro == null)
            return NotFound();

        return View(carro);
    }

    // POST: Carros/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CarroUpdateDTO carro)
    {
        if (id != carro.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _carroService.Update(carro);
            return RedirectToAction(nameof(Index));
        }
        return View(carro);
    }

    // GET: Carros/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var carro = await _carroService.Get((int)id);

        if (carro == null)
            return NotFound();

        return View(carro);
    }

    // POST: Carros/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var carro = await _carroService.Get(id);
        if (carro != null)
        {
            await _carroService.Delete(carro.Id);
        }
        
        return RedirectToAction(nameof(Index));
    }
}

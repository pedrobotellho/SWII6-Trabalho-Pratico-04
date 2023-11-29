using Microsoft.AspNetCore.Mvc;

namespace SWII6_TP03.Controllers;

public class CreditosController : Controller
{

    // GET: Creditos
    public async Task<IActionResult> Index()
    {
        return View();
    }
}

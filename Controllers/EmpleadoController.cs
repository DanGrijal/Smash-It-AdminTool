using Microsoft.AspNetCore.Mvc;
using SGA_Smash.Models;

namespace SGA_Smash.Controllers;

public class EmpleadoController : Controller
{
    private static List<Empleado> empleados = new()
    {
        new Empleado { Id = 1, Nombre = "Carlos Soto", Puesto = "Cocinero", SalarioBase = 450000, FechaIngreso = new DateTime(2022, 3, 15), Estado = "Activo" },
        new Empleado { Id = 2, Nombre = "Andrea Gómez", Puesto = "Mesera", SalarioBase = 350000, FechaIngreso = new DateTime(2023, 1, 10), Estado = "Activo" },
        new Empleado { Id = 3, Nombre = "Luis Mora", Puesto = "Cajero", SalarioBase = 400000, FechaIngreso = new DateTime(2021, 9, 5), Estado = "Inactivo" }
    };

    public IActionResult Index() => View(empleados);

    public IActionResult Details(int id)
    {
        var empleado = empleados.FirstOrDefault(e => e.Id == id);
        if (empleado == null) return NotFound();
        return View(empleado);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Empleado empleado)
    {
        empleado.Id = empleados.Max(e => e.Id) + 1;
        empleados.Add(empleado);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var empleado = empleados.FirstOrDefault(e => e.Id == id);
        if (empleado == null) return NotFound();
        return View(empleado);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Empleado empleado)
    {
        var emp = empleados.FirstOrDefault(e => e.Id == empleado.Id);
        if (emp == null) return NotFound();

        emp.Nombre = empleado.Nombre;
        emp.Puesto = empleado.Puesto;
        emp.SalarioBase = empleado.SalarioBase;
        emp.FechaIngreso = empleado.FechaIngreso;
        emp.Estado = empleado.Estado;

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var empleado = empleados.FirstOrDefault(e => e.Id == id);
        if (empleado == null) return NotFound();
        return View(empleado);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var empleado = empleados.FirstOrDefault(e => e.Id == id);
        if (empleado != null)
        {
            empleados.Remove(empleado);
        }
        return RedirectToAction(nameof(Index));
    }
}
using Microsoft.AspNetCore.Mvc;
using SGA_Smash.Models;

namespace SGA_Smash.Controllers
{
    public class ClienteController : Controller
    {
        // Lista simulada de clientes
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "Juan Pérez", Correo = "juanperez@email.com", Telefono = "8888-0001", FechaRegistro = new DateTime(2024, 3, 10) },
            new Cliente { Id = 2, Nombre = "Ana María", Correo = "ana.maria@email.com", Telefono = "8888-0002", FechaRegistro = new DateTime(2024, 4, 5) },
            new Cliente { Id = 3, Nombre = "Luis Fernando", Correo = "lfernando@email.com", Telefono = "8888-0003", FechaRegistro = new DateTime(2024, 5, 1) }
        };

        public IActionResult Index()
        {
            return View(clientes);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            cliente.Id = clientes.Max(c => c.Id) + 1;
            cliente.FechaRegistro = DateTime.Now;
            clientes.Add(cliente);
            return RedirectToAction("Index");
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(int id, Cliente clienteActualizado)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();

            cliente.Nombre = clienteActualizado.Nombre;
            cliente.Correo = clienteActualizado.Correo;
            cliente.Telefono = clienteActualizado.Telefono;
            // FechaRegistro no se modifica

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();

            clientes.Remove(cliente);
            return RedirectToAction("Index");
        }

        
    }
}
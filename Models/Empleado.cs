namespace SGA_Smash.Models;

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Puesto { get; set; }
    public decimal SalarioBase { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string Estado { get; set; }
}
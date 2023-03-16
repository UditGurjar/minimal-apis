using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Controllers
{
    public  class EmployeeController
    {

        //private readonly ApplicationDbContext _context;

        //public EmployeeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public static void ConfigureEndpoints( IEndpointRouteBuilder endpoints)
        {

            endpoints.MapGet("/getEmployees", async (ApplicationDbContext _context) =>
            {
                var employees = await _context.Employees.ToListAsync();
                //await context.Response.WriteAsJsonAsync(employees);
                return Results.Ok(employees);

            });
           

            endpoints.MapPost("/saveEmployees", async (ApplicationDbContext _context,Employee employees) =>
            {
              //  var employee = await context.Request.ReadFromJsonAsync<Employee>();
              if(employees != null )
                {
                    _context.Employees.Add( employees );
                    await _context.SaveChangesAsync();
                    return Results.Ok();
                }
            return Results.BadRequest();
            });

            endpoints.MapGet("/getEmployees/{id}", async (ApplicationDbContext _context, int id) =>
            {
                var findEmployees = await _context.Employees.FindAsync(id);
                return Results.Ok(findEmployees);
            });

            endpoints.MapPut("/updateEmployees", async (ApplicationDbContext _context, Employee employees) =>
            {
                var checkEmployee = await _context.Employees.FindAsync(employees.Id);
                if (checkEmployee != null)
                {
                    _context.Employees.Update( employees );
                    await _context.SaveChangesAsync();
                    return Results.Ok(employees);
                }
                return Results.NoContent();
            });

        }

    }
}
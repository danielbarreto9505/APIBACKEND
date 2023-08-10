using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBACKEND.Models;
namespace APIBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        public readonly PruebafiContext _dbcontext;
        public TodoListController(PruebafiContext _context)
        {
            _dbcontext = _context;
        }
        [HttpGet]
        [Route("Lista")]
       public IActionResult lista()
        {
            List<Todolist> lista = new List<Todolist>();
            try
            {
                lista=_dbcontext.Todolists.ToList();
                return StatusCode(StatusCodes.Status200OK, new {mensaje="OK", Response=lista});
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje =ex.Message, Response = lista });
            }
        }
        [HttpGet("{id}")]
        [Route("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var item = _dbcontext.Todolists.Find(id);
                if (item == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Elemento no encontrado" });
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", Response = item });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("Crear")]
        public IActionResult Crear(Todolist nuevoItem)
        {
            try
            {
                _dbcontext.Todolists.Add(nuevoItem);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { mensaje = "Elemento creado exitosamente", Response = nuevoItem });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPut("{id}")]
        [Route("Editar/{id}")]
        public IActionResult Editar(int id, Todolist itemActualizado)
        {
            try
            {
                var item = _dbcontext.Todolists.Find(id);
                if (item == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Elemento no encontrado" });
                }

                item.Titulo = itemActualizado.Titulo; // Actualiza las propiedades necesarias
                item.EsActivo = itemActualizado.EsActivo;

                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Elemento actualizado exitosamente", Response = item });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        [Route("Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var item = _dbcontext.Todolists.Find(id);
                if (item == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Elemento no encontrado" });
                }

                _dbcontext.Todolists.Remove(item);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Elemento eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


    }
}


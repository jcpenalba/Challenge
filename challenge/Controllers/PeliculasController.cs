using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using challenge.Models;
using challenge.DTOs.Peliculas;
using challenge.Repositories.Interfaces;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : BaseController
    {
        private readonly IPeliculaService _peliculaService;

        public PeliculasController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        
        [HttpGet]
        public ActionResult<List<GetPeliculaDTO>> Getpelicula()
        {
            IList<Pelicula> peliculas = _peliculaService.GetAll();
            IList<GetPeliculaDTO> getPeliculaDTOs = _mapper.Map<IList<Pelicula>, IList<GetPeliculaDTO>>(peliculas);
            return Ok(getPeliculaDTOs); 
        }

        [HttpGet("id")]
        public ActionResult<List<GetPeliculaDTO>> GetpeliculaId(int id)
        {
            Pelicula peliculas = _peliculaService.GetById(id);
            GetPeliculaDTO getPeliculaDTOs = _mapper.Map<Pelicula, GetPeliculaDTO>(peliculas);
            return Ok(getPeliculaDTOs);
        }

        [HttpPost]
        public ActionResult PostPelicula(NewPeliculaDTO peliculaDTO)
        {
            if (ModelState.IsValid)
            {
                Pelicula newPelicula = _mapper.Map<NewPeliculaDTO, Pelicula>(peliculaDTO);
                try
                {
                    newPelicula = _peliculaService.Create(newPelicula);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest("Se Produjo Un Error.");
                }
            }

            return NoContent();
        }

        [HttpPut]
        public ActionResult<Pelicula> PutPelicula(PeliculaDTO peliculaDTO)
        {
            if (ModelState.IsValid)
            {
                Pelicula pelicula = _mapper.Map<PeliculaDTO, Pelicula>(peliculaDTO);
                try
                {
                    _peliculaService.Update(pelicula);

                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest("Se Produjo Un Error."+e);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeletePelicula(int id)
        {
            try
            {
                _peliculaService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Se Produjo Un Error.");

            }
        }

    }
}

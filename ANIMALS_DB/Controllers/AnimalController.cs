using System.ComponentModel;
using ANIMALS_DB.Models;
using ANIMALS_DB.Models.DTO_s;
using ANIMALS_DB.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ANIMALS_DB.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;

        public AnimalController(AnimalService animalService)
        {
            _animalService = animalService;
        }
        
        [HttpGet]
        public IActionResult GetAnimals([FromQuery]string orderBy = "name")
        {
            var animals = _animalService.GetAnimals(orderBy);
            return Ok(animals);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _animalService.GetAnimal(id);
            return Ok(animal);
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAnimal(int id)
        {
            _animalService.DeleteAnimal(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult addAnimal(AddAnimal animal)
        {
            _animalService.AddAnimal(animal);
            return Ok();
        }


        [HttpPost("{AnimalId:int}")]
        public IActionResult UpdateAnimal(int AnimalId, UpdateAnimal animal)
        {
            _animalService.UpdateAnimal(AnimalId, animal);
            return Ok();
        }




    }
}
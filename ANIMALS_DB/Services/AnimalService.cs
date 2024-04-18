using ANIMALS_DB.Models;
using ANIMALS_DB.Models.DTO_s;
using ANIMALS_DB.Repositories;

namespace ANIMALS_DB.Services;

public class AnimalService
{
    private AnimalRepository _animalRepository;
    
    public AnimalService(AnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalRepository.GetAnimals(orderBy);
    }

    public Animal GetAnimal(int IdAnimal)
    {
        return _animalRepository.GetAnimal(IdAnimal);
    }


    public void DeleteAnimal(int AnimalId)
    {
        _animalRepository.DeleteAnimal(AnimalId);
    }

    public void AddAnimal(AddAnimal animal)
    {
        _animalRepository.addAnimal(animal);
    }


    public void UpdateAnimal(int AnimalId, UpdateAnimal animal)
    {
        _animalRepository.UpdateAnimal(AnimalId, animal);
    }

}
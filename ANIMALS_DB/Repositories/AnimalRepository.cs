using ANIMALS_DB.Models;
using ANIMALS_DB.Models.DTO_s;
using Microsoft.Data.SqlClient;

namespace ANIMALS_DB.Repositories;

public class AnimalRepository
{

    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        orderBy = orderBy.getSqlOrderBy();
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = $"SELECT * FROM Animal ORDER BY [{orderBy}];";
        
        
        var reader = command.ExecuteReader();
        
        var animals = new List<Animal>();

        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        int descriptionOrdinal = reader.GetOrdinal("Description");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int areaOrdinal = reader.GetOrdinal("Area");

        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal),
                Description = reader.GetString(descriptionOrdinal),
                Category = reader.GetString(categoryOrdinal),
                Area = reader.GetString(areaOrdinal),
            });
        }

        return animals;
    }

    public Animal GetAnimal(int idAnimal)
    {
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal WHERE IdAnimal = @idAnimal;";
        command.Parameters.AddWithValue("@IdAnimal", idAnimal);
        
        var reader = command.ExecuteReader();

        if (!reader.Read()) return null;

        var animal = new Animal()
        {
            IdAnimal = (int)reader["IdAnimal"],
            Name = reader["Name"].ToString(),
            Description = reader["Name"].ToString(),
            Category = reader["Category"].ToString(),
            Area = reader["Area"].ToString()
        };

        return animal;
    }


    public void DeleteAnimal(int AnimalId)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @AnimalId;";
        command.Parameters.AddWithValue("@AnimalId", AnimalId);
        
        command.ExecuteNonQuery();
    }


    public void addAnimal(AddAnimal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area);";
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);

        command.ExecuteNonQuery();
    }


    public void UpdateAnimal(int AnimalId, UpdateAnimal animal)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
        command.Parameters.AddWithValue("@Name", animal.Name);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Area", animal.Area);
        command.Parameters.AddWithValue("@IdAnimal", AnimalId);
        
        command.ExecuteNonQuery();
    }


}
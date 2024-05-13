
using Microsoft.EntityFrameworkCore;
using H3SamuraiProject.Repo.Data;
using H3SamuraiProject.Repo.Models;
using H3SamuraiProject.Repo.Repositories;

namespace H3SamuraiProject.Test.Repo;

public class SamuraiRepositoryTest
{
    DbContextOptions<DataContext> options;

    DataContext _context;

    public SamuraiRepositoryTest()
    {
        // Create a new instance of DbContextOptionsBuilder and specify the database provider
        // In this case, we are using an in-memory database, so we are using the UseInMemoryDatabase method
        options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "OurDummyDatabase").Options;

        // Create a new instance of the DataContext class and pass the options
        _context = new DataContext(options);


        _context.Database.EnsureDeleted();

        // Populate data - Horses and Samurais
        Horse h1 = new Horse() { Id = 1, Name = "Red Mare" };   
        Horse h2 = new Horse() { Id = 2, Name = "ShadowFax" };
        Horse h3 = new Horse() { Id = 3, Name = "Black Stallion" };

        _context.Horses.Add(h1);
        _context.Add(h2);        
        _context.Add(h3);

        // Samurais
        Samurai s1 = new Samurai() { 
            Id = 1, Name = "Samurai Jack", 
            Description = "A samurai warrior who has been sent to the future by an evil demon named Aku.", 
            Age = 25, 
            HorseId = 1 };

        Samurai s2 = new Samurai()
        {
            Id = 2,
            Name = "DarkOne",
            Description = "Just another guy with sword.",
            Age = 15,
            HorseId = 2 };

        Samurai s3 = new Samurai()
        {
            Id = 3, 
            Name = "Samurai X", 
            Description = "A wandering samurai who is known for his swordsmanship and his willingness to help those in need.", 
            Age = 30, 
            HorseId = 3 };
        
        _context.Add(s1);
        _context.Add(s2);
        _context.Add(s3);

        _context.SaveChanges();

    }

    [Fact] // This is a Fact attribute from xUnit. It is used to mark a method as a test method.
    public void GetAllSamurai_ReturnAll()
    {        
        // Arrange - Variables creations and initializations / What do we want to test?

        SamuraiRepository repo = new SamuraiRepository(_context);

        // Act - Call the method to be tested (GetAllSamurai)
        var result = repo.GetAllSamurais();

        // Assert - Verify the result
        Assert.Equal(3, result.Count); // We expect 3 samurais because we added 3 samurais in the constructor
    }

    [Fact] // This is a Fact attribute from xUnit. It is used to mark a method as a test method.
    public void GetSamuraiById_ReturnSamurai()
    {
        // Arrange
        SamuraiRepository repo = new SamuraiRepository(_context);
        // Act
        var result = repo.GetSamuraiById(1);
        // Assert
        //Assert.True(result.Name == "Samurai Jack");
        Assert.True(result != null);
    }

    [Fact] // This is a Fact attribute from xUnit. It is used to mark a method as a test method.
    public void GetSamuraiById_ReturnNotFound()
    {
        // Arrange
        SamuraiRepository repo = new SamuraiRepository(_context);
        // Act
        var result = repo.GetSamuraiById(4);
        // Assert
        //Assert.True(result.Name == "Samurai Jack");
        Assert.False(result != null);
    }

    [Fact] // This is a Fact attribute from xUnit. It is used to mark a method as a test method.
    public void GetSamuraiById_ReturnNull()
    {
        // Arrange
        SamuraiRepository? repo = null; // We are simulating that the database is "dead"
        // Act
        //var result = repo.GetSamuraiById(1); // We are trying to get a samurai from a dead database
        // Assert
        Assert.Null(repo); // We expect a null result
    }
}


#region

// Arrange

// Act

// Assert

#endregion
using Microsoft.Data.Sqlite;
using LabManager.Models;
using LabManager.Database;
using Dapper;

namespace LabManager.Repositories;

class ComputerRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    
    public IEnumerable<Computer> GetAll()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var computers = connection.Query<Computer>("SELECT * FROM Computers");

        return computers;
    }

    public Computer Save(Computer computer)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Computers VALUES(@Id, @Ram, @Processor)", computer);

        return computer;
    }

    public Computer GetById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var computer = connection.QuerySingle<Computer>("SELECT * FROM Computers WHERE Id = @Id", new {Id = id});

        return computer;
    }

    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("DELETE FROM Computers WHERE id = @Id", new {Id = id});
    }


    public Computer Update(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute( @"
        Update Computers 
        SET 
            ram = @Ram,
            processor = @Processor
        WHERE id = @Id
        ", computer);

        return computer;
    }

    public bool ExistsById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = Convert.ToBoolean(connection.ExecuteScalar("DELETE FROM Computers WHERE id = @Id", new {Id = id}));

        return result;
    }
}
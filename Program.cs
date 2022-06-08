﻿using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);

var modelName = args[0]; 
var modelAction = args[1]; 

if (modelName == "Computer")
{
    var computerRepository = new ComputerRepository(databaseConfig);

    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");

        var computers = computerRepository.GetAll();

        foreach (var computer in computers)
        {
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}"); 
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("New Computer");
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args [4]; 
        
        var computer = new Computer(id, ram, processor);

        computerRepository.Save(computer);

    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Show Computer");

        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}"); 
        } else {
            Console.WriteLine($"Computador com id {id} não existe");
        }

    }

     if(modelAction == "Delete")
    {
        Console.WriteLine("Delete Computer");
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            computerRepository.Delete(id);
        } else {
            Console.WriteLine($"Computador com id {id} não existe");
        }
    }

    if(modelAction == "Update")
    {
        Console.WriteLine("Update Computer");
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            var ram = args[3];
            var processor = args [4]; 
            var computer = new Computer(id, ram, processor);

            computerRepository.Update(computer);
        } else {
            Console.WriteLine($"Computador com id {id} não existe");
        }
    }
}
    
if (modelName == "Lab")
{
    var labRepository = new LabRepository(databaseConfig);

    if(modelAction == "List")
    {
        Console.WriteLine("Lab List");

        var labs = labRepository.GetAll();

        foreach (var lab in labs)
        {
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}"); 
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("New Lab");
        var id = Convert.ToInt32(args[2]);
        var number = args[3];
        var name = args [4]; 
        var block = args [5];
        
       var lab = new Lab(id, number, name, block);

       labRepository.Save(lab);
    }

    if(modelAction == "Show")
    {
        Console.WriteLine("Show Lab");
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var lab = labRepository.GetById(id);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}"); 
        } else {
            Console.WriteLine($"Lab com id {id} não existe");
        }
    }

    if(modelAction == "Delete")
    {
        Console.WriteLine("Delete Lab");
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            labRepository.Delete(id);
        } else {
            Console.WriteLine($"Lab com id {id} não existe");
        }
    }

    if(modelAction == "Update")
    {
        Console.WriteLine("Update Lab");
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var number = args[3];
            var name = args [4]; 
            var block = args [5];
        
            var lab = new Lab(id, number, name, block);

            labRepository.Update(lab);
        } else {
            Console.WriteLine($"Lab com id {id} não existe");
        }
    }
}
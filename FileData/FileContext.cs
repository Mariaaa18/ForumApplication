﻿using System.Text.Json;
using Shared;

namespace FileData;

public class FileContext
{
    private const string filePath = "datu.json";
    private DataContainer? dataContainer;
    
    
    
    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.Users;
        }
    }
    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            Console.WriteLine("in collection posts after load data");
            return dataContainer!.Posts;
            
        }
    }


    
    private void LoadData()
    {
        if (dataContainer != null) return;
    
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                
                Users = new List<User>(),
                Posts = new List<Post>()
                
               
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
    
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}

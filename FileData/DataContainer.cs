﻿using System.Text.Json;
using Shared;

namespace FileData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
}   
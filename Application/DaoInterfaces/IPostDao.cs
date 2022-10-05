﻿using Shared;
using Shared.DTOs;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<PostTitleDto>> GetAsync();
    
}
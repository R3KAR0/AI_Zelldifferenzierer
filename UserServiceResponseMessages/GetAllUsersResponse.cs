﻿using UserServiceModels;

namespace UserServiceResponseMessages
{
    public interface GetAllUsersResponse
    {
        List<ApplicationUser> Users { get; }
    }
}

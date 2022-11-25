﻿using CustomBlog.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Api.Application.Interfaces.Repositories;

internal interface IUserReadListRepository : IGenericRepository<UserReadList>
{
}
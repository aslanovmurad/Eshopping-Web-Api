﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Abstraction.Hub
{
    public interface IProductHubSerice
    {
        Task ProductAddedMessageAsync(string message);
    }
}

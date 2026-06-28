using Shop.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string? UserId => "System";

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIDecorateTest.Models;

namespace DIDecorateTest.Services
{
    public interface IPlayersService
    {
        IEnumerable<Player> GetPlayersList(); 
    }
}

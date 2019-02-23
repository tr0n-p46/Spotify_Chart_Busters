using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class ChartbustersRepository : RepositoryBase<Chartbusters>, IChartbustersRepository
    {
        public ChartbustersRepository(SpotifyDBContext dBContext): base(dBContext)
        {

        }
    }
}
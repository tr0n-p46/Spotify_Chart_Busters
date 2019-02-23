using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataTransfer;
using AutoMapper;
using WebAPI.AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartbustersController : ControllerBase
    {
        private readonly IMapper autoMapper;
        private readonly IChartbustersRepository chartbustersRepository;

        public ChartbustersController(IChartbustersRepository chartbustersRepository, IMapper autoMapper)
        {
            this.chartbustersRepository = chartbustersRepository;
            this.autoMapper = autoMapper;
        }

        // GET: api/Chartbusters
        [HttpGet]
        public async Task<ActionResult<ListResponse<ChartbusterViewModel>>> GetChartbusters([FromQuery] DataSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BadResponse<ModelError> { Success = false, Errors = ModelState.SelectMany(s => s.Value.Errors).ToList() });
            }

            var query = chartbustersRepository.FindAll();
            if(request.OrderBy == "name" && request.OrderByAsc)
            {
                query = query.OrderBy(o => o.Name);
            }
            else if(request.OrderBy == "name")
            {
                query = query.OrderByDescending(o => o.Name);
            }

            var total = query.Count();

            if(request.Search != null && request.Search.Trim().Length > 0)
            {
                var search = request.Search.Trim().ToLower();

                query = query.Where(w => w.Name.ToLower().StartsWith(search));
            }
            var filtered = query.Count();

            var data = await query.Skip(request.Start.Value).Take(request.Count.Value).Select(s => autoMapper.Map<ChartbusterViewModel>(s)).ToListAsync();
            return Ok(new ListResponse<ChartbusterViewModel>
            {
                Data = data,
                Total = total,
                Filtered = filtered
            });
        }

        // GET: api/Chartbusters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChartbustersResourceModel>> GetChartbuster(int? id)
        {
            if (id == null)
                return BadRequest();
            
            var model = await chartbustersRepository.FindByCondition(f => f.Id == id).Select(s => autoMapper.Map<ChartbustersResourceModel>(s)).FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }
}

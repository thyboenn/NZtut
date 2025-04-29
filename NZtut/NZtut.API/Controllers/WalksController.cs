using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZtut.API.CustomActionFilters;
using NZtut.API.Models.Domain;
using NZtut.API.Models.DTO;
using NZtut.API.Repositories;

namespace NZtut.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }


        // POST - Create Walk
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {

            // Map DTO to Domain model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);

            await walkRepository.CreateAsync(walkDomainModel);

            //Map domain model to DTO
            var walkDTO = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDTO);
         

        }

        // GET - All walks
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? SortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walkDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, SortBy, isAscending ?? true, pageNumber, pageSize);

            //Create exception
            throw new Exception("This is a custom exception");

            // Map domain model to DTO
            var walkDTOList = mapper.Map<List<WalkDTO>>(walkDomainModel);
            return Ok(walkDTOList);
        }

        //GET - walk by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<WalkDTO>(walkDomainModel);

            // Map domain model to DTO
            return Ok(walkDTO);
        }

        //PUT - update a walk by id
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateById([FromRoute] Guid id, UpdateWalkRequestDTO updateWalkRequestDTO)
        {

            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDTO);

            walkDomainModel = await walkRepository.UpdateByIdAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map domain model to DTO
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));

        }

        //DELETE - a walk by id
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var deletedWalkDomainModel = await walkRepository.DeleteByIdAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain model to DTO
            return Ok(mapper.Map<WalkDTO>(deletedWalkDomainModel));
        }
    }
}

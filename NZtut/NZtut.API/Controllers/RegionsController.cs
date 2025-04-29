using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZtut.API.CustomActionFilters;
using NZtut.API.Data;
using NZtut.API.Models.Domain;
using NZtut.API.Models.DTO;
using NZtut.API.Repositories;
using System.Collections.Generic;
using System.Text.Json;

namespace NZtut.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZtutDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZtutDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        // GET ALL REGIONS
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {

            // Get data from database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Map domain models to DTOs
            var regionsDTO = mapper.Map<List<RegionDTO>>(regionsDomain);

            logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");

            // Return DTOs
            return Ok(regionsDTO);
        }

        // GET SINGLE REGION (By ID)
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            //Get region domain model from database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map region domain model to region DTO
            var regionDTO = mapper.Map<RegionDTO>(regionDomain);

            //Return DTO back to client
            return Ok(regionDTO);
        }


        // POST to create a new region
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {

            // MAP DTO to domain model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDTO);

            //Use domain model to create region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //map domain model back to DTO
            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDTO.Id }, regionDTO);

        }


        //PUT to Update a Region
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {

            //Map DTO to domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

            // Check if region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert domain model to DTO
            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);


        }

        //Delete a single region
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            //does region exist?
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //return deleted region back in response
            //Map domain model to DTO
            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using PayrollAPI.Data;
using PayrollAPI.Dtos;
using PayrollAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollAPI.Models;

namespace PayrollAPI.Controllers
{
   // [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public EmployeeController(IEmployeeRepository repo, IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _repo = repo;
            _context = context;
        }

         [HttpPost("create/{companyid}")]
        public async Task<IActionResult> AddEmployee(int companyid,
            EmployeeForCreationDto employeeForCreationDto)
        {
             
                
            employeeForCreationDto.CompanyId = companyid;
            var employee = _mapper.Map<Employee>(employeeForCreationDto);
            _repo.Add(employee);

            foreach (var ecompdeduct in employeeForCreationDto.ECompDeducts)
         {
             _context.EcompDeducts.Add(new EcompDeduct()
             {
                  Name  = ecompdeduct.Name,
                Year = ecompdeduct.Year,
                Value = ecompdeduct.Value,
                Type = ecompdeduct.Type,
                EmployeeId = employee.Id,
                CompanyId = companyid
             });
         }

            _context.SaveChanges();

            if (await _repo.SaveAll())
            {
                return Ok(employee);
            }

            return BadRequest("Could not add the employee");
        }
 
         [HttpGet("find/{id}")]
        public async Task<IActionResult> GetEmployee( int id)
        {
            var employee = await _repo.GetEmployee(id);

            var employeeToReturn = _mapper.Map<UserForDetailedDto>(employee);

            if (employeeToReturn == null)
                return NotFound();

            return Ok(employeeToReturn);
        }

/*
         [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyForUpdateDto companyForUpdateDto)
        {

            var companyFromRepo = await _repo.GetCompany(id);

            _mapper.Map(companyForUpdateDto, companyFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating company {id} failed on save");
        }

        [HttpPost("createcompensation/{companyid}")]
        public async Task<IActionResult> AddCompensation(int companyid,
            CompensationForCreationDto compensationForCreationDto)
        {
            compensationForCreationDto.CompanyId = companyid;
            var compensation = _mapper.Map<Compensation>(compensationForCreationDto);
            _repo.Add(compensation);

            if (await _repo.SaveAll())
            {
                return Ok(compensation);
            }

            return BadRequest("Could not add the compensation");
        }

         [HttpPost("creatededuction/{companyid}")]
        public async Task<IActionResult> AddDeduction(int companyid,
            DeductionForCreationDto deductionForCreationDto)
        {
            deductionForCreationDto.CompanyId = companyid;
            var deduction = _mapper.Map<Deduction>(deductionForCreationDto);
            _repo.Add(deduction);

            if (await _repo.SaveAll())
            {
                return Ok(deduction);
            }

            return BadRequest("Could not add the deduction");
        }



         [HttpPut("updatecompensation/{id}")]
        public async Task<IActionResult> UpdateCompensation(int id, CompensationForUpdateDto compensationForUpdateDto)
        {

            var compensationFromRepo = await _repo.GetCompensation(id);

            _mapper.Map(compensationForUpdateDto, compensationFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating compensation {id} failed on save");
        }

         [HttpPut("updatededuction/{id}")]
        public async Task<IActionResult> UpdateDeduction(int id, DeductionForUpdateDto deductionForUpdateDto)
        {

            var deductionFromRepo = await _repo.GetDeduction(id);

            _mapper.Map(deductionForUpdateDto, deductionFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating deduction {id} failed on save");
        }

         [HttpDelete("deletecompensation/{id}")]
        public async Task<IActionResult> DeleteCompensation(int id)
        {
            var compensationFromRepo = await _repo.GetCompensation(id);
                _repo.Delete(compensationFromRepo);
          
            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the compensation");
        }

         [HttpDelete("deletededuction/{id}")]
        public async Task<IActionResult> DeleteDeduction(int id)
        {
            var deductionFromRepo = await _repo.GetDeduction(id);
                _repo.Delete(deductionFromRepo);
          
            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the deduction");
        } */
       
    }
}
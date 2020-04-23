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
using System.IO;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PayrollAPI.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollHistoryController : ControllerBase
    {
        private readonly IPayrollHistoryRepository _repo;
     
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public PayrollHistoryController(IPayrollHistoryRepository repo, IMapper mapper,IHostingEnvironment hostingEnvironment, DataContext context)
        {
            _mapper = mapper;
            _repo = repo;
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }


        [HttpGet("getpayrollhistory/{companyid}")]
        public async Task<IActionResult> GetPayrollHistory(int companyid)
        {
            var payrollHistory = await _repo.GetPayrollHistory(companyid);

            var payrollHistoryToReturn = _mapper.Map<PayrollHistoryForDetailedDto>(payrollHistory);

            if (payrollHistoryToReturn == null)
                return NotFound();

            return Ok(payrollHistoryToReturn);
        }
       
    }
}
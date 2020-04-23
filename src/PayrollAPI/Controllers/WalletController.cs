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
    public class WalletController : ControllerBase
    {
        private readonly IWalletTransactionRepository _repo;
        private readonly ICompanyRepository _repo2;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public WalletController(IWalletTransactionRepository repo, ICompanyRepository repo2, IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _repo = repo;
            _repo2 = repo2;
            _context = context;

        }

        [HttpPost("credit/{companyid}")]
        public async Task<IActionResult> Credit(int companyid,
            CreditWalletForCreationDto creditWalletForCreationDto)
        {
              var companyFromRepo = await _repo2.GetCompany(companyid);

             var wallet =  companyFromRepo.Wallet +creditWalletForCreationDto.Amount;
            companyFromRepo.Wallet = wallet;

            await _repo2.SaveAll();
                
            creditWalletForCreationDto.CompanyId = companyid;
            creditWalletForCreationDto.TransactionType = "CREDIT";
            creditWalletForCreationDto.ReferenceNo = System.Guid.NewGuid().ToString();
            var creditWallet = _mapper.Map<WalletTransaction>(creditWalletForCreationDto);
            _repo.Add(creditWallet);

            _context.SaveChanges();

            if (await _repo.SaveAll())
            {
                return Ok(creditWallet);
            }

            return BadRequest("Could not add the credit wallet transaction");
        }
       
    }
}
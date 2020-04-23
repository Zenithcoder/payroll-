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
    public class PayoutHistoryController : ControllerBase
    {
        private readonly IPayoutHistoryRepository _repo;
        private readonly ICompanyRepository _repo2;
     
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public PayoutHistoryController(IPayoutHistoryRepository repo, ICompanyRepository repo2, IMapper mapper,IHostingEnvironment hostingEnvironment, DataContext context)
        {
            _mapper = mapper;
            _repo = repo;
            _repo2 = repo2;
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpPost("regular/{companyid}")]
        public async Task<IActionResult> Regular(int companyid, PayoutHistoryDto payoutHistoryDto)
        {
             var employees =  await _repo2.GetCompanyEmployees(companyid);
        
            if (employees == null)
                return NotFound();
            var  uniqueCode = System.Guid.NewGuid().ToString();
          //   payoutHistoryForCreationDto.CompanyId = companyid;
            foreach (var employee in employees)
         {
             _context.PayoutHistories.Add(new PayoutHistory()
             {
                AccountName  = employee.FirstName,
                AccountNumber = employee.AccountNumber,
                Bank = employee.BankName,
                Status = employee.Status,
                Description = payoutHistoryDto.Description,
                Action = payoutHistoryDto.Action,
                Month =payoutHistoryDto.Month,
                Year =payoutHistoryDto.Year,
                UniqueCode = uniqueCode,
             });
         }

         _context.PayrollHistories.Add(new PayrollHistory()
         {
             PayrollType = "Regular",
             Description = payoutHistoryDto.Description,
             PayoutHistoryUniqueCode = uniqueCode,
             Created = DateTime.Now,
             CompanyId = companyid
         });

            _context.SaveChanges();

            if (await _repo2.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not run payroll");
        }

      /*   [HttpPost("quickpay-new/{companyid}")]
        public async Task<IActionResult> QuickPay(int companyid,
            PayoutHistoryForCreationDto payoutHistoryForCreationDto)
        {
             var employees =  await _repo2.GetCompanyEmployees(companyid);
        
            if (employees == null)
                return NotFound();
            
          //   payoutHistoryForCreationDto.CompanyId = companyid;
            foreach (var employee in employees)
         {
            var payoutHistory = _mapper.Map<PayoutHistory>(payoutHistoryForCreationDto);
            _repo.Add(payoutHistory);
         }
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("Could not add the Payout History");
        }
*/

        [HttpPost("quickpay/{companyid}")] 
        public async Task<IActionResult> ImportQuickPay(int companyid, IFormFile formFile, CancellationToken cancellationToken)  
        {  
            if (formFile == null || formFile.Length <= 0)  
            {  
                return null;  
            }  
        
            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))  
            {  
                return null ;
            }  
        
            var list = new List<PayoutHistoryForCreationDto>();  
            var  uniqueCode = System.Guid.NewGuid().ToString();
            using (var stream = new MemoryStream())  
            {  
                await formFile.CopyToAsync(stream, cancellationToken);  
        
                using (var package = new ExcelPackage(stream))  
                {  
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];  
                    var rowCount = worksheet.Dimension.Rows;  
        
                    for (int row = 2; row <= rowCount; row++)  
                    {  
                        list.Add(new PayoutHistoryForCreationDto  
                        {  
                            AccountName = worksheet.Cells[row, 1].Value.ToString().Trim(),  
                            AccountNumber = worksheet.Cells[row, 2].Value.ToString().Trim(),  
                            Bank = worksheet.Cells[row, 3].Value.ToString().Trim(),  
                            NetPay = float.Parse(worksheet.Cells[row, 4].Value.ToString().Trim()),  
                            Description = worksheet.Cells[row, 5].Value.ToString().Trim(),  
                            CompanyId = companyid,
                            UniqueCode = uniqueCode
                            
                        });  
                    }  
                }  
            }  
        
            // add list to db ..  
            
                    var payoutHistory = _mapper.Map<PayoutHistory>(list);
                    _repo.Add(payoutHistory);
                

         _context.PayrollHistories.Add(new PayrollHistory()
         {
             PayrollType = "QuickPay",
             PayoutHistoryUniqueCode = uniqueCode,
             Created = DateTime.Now,
             CompanyId = companyid
         });

            _context.SaveChanges();

                    if (await _repo.SaveAll())
                    {
                        return Ok();
                    }

                    return BadRequest("Could not add the Payout History");
            
            // here just read and return  
        
        // return DemoResponse<List<UserInfo>>.GetResult(0, "OK", list);  
        }  


        [HttpGet("export")]
        public async  Task<IActionResult> Export(CancellationToken cancellationToken)
        {
            string folder = _hostingEnvironment.WebRootPath;
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, excelName);
            FileInfo file = new FileInfo(Path.Combine(folder, excelName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(folder, excelName));
            }

            // query data from database
            await Task.Yield();

            var list = new List<PayoutHistoryForCreationDto>()
            {
                new PayoutHistoryForCreationDto { Bank = "catcher", NetPay = 18 },
                new PayoutHistoryForCreationDto { Bank = "james", NetPay = 20 },
            };

            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                workSheet.Cells.LoadFromCollection(list, true);

                package.Save();
            }

           return Ok();
        }
       
    }
}
using Dto.Model;
using Dto.Model.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using NReco.PdfGenerator;
using OfficeOpenXml;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Controllers.salary
{
    [Route("api/Salary/")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        private readonly IConfiguration _config;
        private IWebHostEnvironment _hostingEnvironment;
        public SalaryController(ISalaryService salaryService, IConfiguration config, IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
            _salaryService = salaryService;
            _config = config;
        }

        [HttpPost]
        [Route("SaveUpdateSalary")]
        public Response SaveUpdateSalary(SalaryModel model)
        {
            try
            {
                return _salaryService.SaveUpdateSalary(model);
            }
            catch (Exception ex)
            {
                throw null;
            }
        }

        [HttpGet]
        [Route("GetAllsalary")]
        public SalaryViewModel GetAllSalary()
        {
            try
            {
                return _salaryService.GetAllSalary();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetSingleSalary/{SalaryComponentId}")]
        public SingleSalaryModel GetSingleSalary(int SalaryComponentId)
        {
            try
            {
                return _salaryService.GetSingleSalary(SalaryComponentId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("DeleteSalary/{SalaryComponentId}")]
        public Response DeleteSalary(int SalaryComponentId)
        {
            try
            {
                return _salaryService.DeleteSalary(SalaryComponentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetSalaryName/{data}")]
        public SalaryNameViewModel GetSalaryName(string data) {
            try
            {
                return _salaryService.GetSalaryName(data);
            }
            catch(Exception exe)
            {
                throw exe;
            }
            return null;
        }
        [HttpGet]
        [Route("GetSalaryComponentType/{companyid=companyid}")]
        public GetSalaryComponentTypeView GetSalaryComponentType(int companyid)
        {
            try
            {
                return _salaryService.GetSalaryComponentType(companyid);
            }
            catch (Exception exe)
            {
                throw exe;
            }
            return null;
        }

        [HttpPost]
        [Route("UpdateSalVal/")]
        public Response UpdateSalVal(SalaryStructureModel model)
        {
            Response response = new Response();
            try 
            {
       
                return _salaryService.UpdateSalVal(model);
            }
            catch (Exception exe)
            {
                throw exe;
            }
            return response;
        }

        [HttpPost]
        [Route("UpdateFeildName/")]
        public Response UpdateFeildName(UpdateFeildName nameModel)
        {
            Response response = new Response();
            try
            {
                return _salaryService.UpdateFeildName(nameModel);
            }
            catch (Exception exe)
            {
                throw exe;
            }
            return response;
        }

       /* [HttpGet]
        [Route("Fortest")]
        public UploadingResult tasktoDo()
        {

            



            string filePath = Path.Combine("D:/HRMS-BackEnd/BWSHRMS-BackEnd/CompanyManagement/Resources/excel data.xlsx");
            UploadingResult result = new UploadingResult();
            FileInfo fileTo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(fileTo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets["BWS"];
            string month = "";
            string year = "";
            var zippath = Path.Combine(Directory.GetCurrentDirectory(), "FilesSalary", "ZipsUpload");

            string r1 = worksheet.Cells[6, 24].Text.ToString();
            string r2 = worksheet.Cells[6, 25].Text.ToString();
            //foreach (string file in Directory.GetFiles(@"F:\SalarySlip\SalarySlip\SalarySlip\FilesSalary\ZipsUpload", "*.pdf").Where(item => item.EndsWith(".pdf")))
            //{
            //    System.IO.File.Delete(file);
            //}

            for (int i = 4; i <= 4; i++)
            {
                #region NullOrEmptyCheck
                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 8].Value)))
                {
                    if (worksheet.Cells[i, 8].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 8].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 8].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 9].Value)))
                {
                    if (worksheet.Cells[i, 9].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 9].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 9].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 11].Value)))
                {
                    if (worksheet.Cells[i, 11].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 11].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 11].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 12].Value)))
                {
                    if (worksheet.Cells[i, 12].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 12].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 12].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 14].Value)))
                {
                    if (worksheet.Cells[i, 14].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 14].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 14].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 15].Value)))
                {
                    if (worksheet.Cells[i, 15].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 15].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 15].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 16].Value)))
                {
                    if (worksheet.Cells[i, 16].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 16].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 16].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 17].Value)))
                {
                    if (worksheet.Cells[i, 17].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 17].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 17].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 20].Value)))
                {
                    if (worksheet.Cells[i, 20].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 20].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 20].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 21].Value)))
                {
                    if (worksheet.Cells[i, 21].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 21].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 21].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 22].Value)))
                {
                    if (worksheet.Cells[i, 22].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 22].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 22].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 23].Value)))
                {
                    if (worksheet.Cells[i, 23].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 23].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 23].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 24].Value)))
                {
                    if (worksheet.Cells[i, 24].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 24].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 24].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 25].Value)))
                {
                    if (worksheet.Cells[i, 25].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 25].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 25].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 27].Value)))
                {
                    if (worksheet.Cells[i, 27].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 27].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 27].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 28].Value)))
                {
                    if (worksheet.Cells[i, 28].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 28].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 28].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 29].Value)))
                {
                    if (worksheet.Cells[i, 29].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 29].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 29].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 30].Value)))
                {
                    if (worksheet.Cells[i, 30].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 30].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 30].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 31].Value)))
                {
                    if (worksheet.Cells[i, 31].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 31].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 31].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 32].Value)))
                {
                    if (worksheet.Cells[i, 32].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 32].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 32].Value = 0;
                }

                if (!String.IsNullOrEmpty(Convert.ToString(worksheet.Cells[i, 33].Value)))
                {
                    if (worksheet.Cells[i, 33].Value.ToString().Contains("-"))
                    {
                        worksheet.Cells[i, 33].Value = 0;
                    }
                }
                else
                {
                    worksheet.Cells[i, 33].Value = 0;
                }
                #endregion  NullOrEmptyCheck

                #region NumberToWordsConversion
                string NumberToWords(int number)
                {
                    if (number == 0)
                        return "Zero";

                    if (number < 0)
                        return "Minus " + NumberToWords(Math.Abs(number));

                    string words = "";

                    //if ((number / 1000000) > 0)
                    //{
                    //	words += NumberToWords(number / 1000000) + " Million ";
                    //	number %= 1000000;
                    //}
                    if ((number / 10000000) > 0)
                    {
                        words += NumberToWords(number / 10000000) + " Crore ";
                        number %= 10000000;
                    }
                    if ((number / 100000) > 0)
                    {
                        words += NumberToWords(number / 100000) + " Lac ";
                        number %= 100000;
                    }
                    if ((number / 1000) > 0)
                    {
                        words += NumberToWords(number / 1000) + " Thousand ";
                        number %= 1000;
                    }
                    if ((number / 100) > 0)
                    {
                        words += NumberToWords(number / 100) + " Hundred ";
                        number %= 100;
                    }
                    if (number > 0)
                    {
                        if (words != "")
                            words += " ";

                        var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                        var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                        if (number < 20)
                            words += unitsMap[number];
                        else
                        {
                            words += tensMap[number / 10];
                            if ((number % 10) > 0)
                                words += " " + unitsMap[number % 10];
                        }
                    }
                    return words;
                }
                #endregion NumberToWordsConversion

                month = (worksheet.Cells[1, 3].Value ?? "-").ToString().Split('.')[0].Trim();
                year = (worksheet.Cells[1, 3].Value ?? "-").ToString().Split('.')[1].Trim();
                int fixedbasic = Convert.ToInt32((worksheet.Cells[i, 14].Value ?? 0).ToString());
                int fixedHRA = Convert.ToInt32((worksheet.Cells[i, 15].Value ?? 0).ToString());
                int fixedConveyance = Convert.ToInt32((worksheet.Cells[i, 16].Value ?? 0).ToString());
                int fixedSpecial = Convert.ToInt32((worksheet.Cells[i, 17].Value ?? 0).ToString());
                int totalEarningsFixedPay = fixedbasic + fixedHRA + fixedConveyance + fixedSpecial;
                string totalEarningsFixedPayFormated = totalEarningsFixedPay.ToString("0,0", CultureInfo.CreateSpecificCulture("hi-IN"));


                //(worksheet.Cells[i, 37].Value??String.Empty).ToString()
                int earnedbasic = Convert.ToInt32((worksheet.Cells[i, 20].Value ?? 0).ToString());
                int earnedHRA = Convert.ToInt32((worksheet.Cells[i, 21].Value ?? 0).ToString());
                int earnedConveyance = Convert.ToInt32((worksheet.Cells[i, 22].Value ?? 0).ToString());
                int earnedSpecial = Convert.ToInt32((worksheet.Cells[i, 23].Value ?? 0).ToString());
                int leaveSalary = Convert.ToInt32((worksheet.Cells[i, 25].Value ?? 0).ToString());
                int incentives = Convert.ToInt32((worksheet.Cells[i, 24].Value ?? 0).ToString());
                int totalEarningsEarnedPay = earnedbasic + earnedHRA + earnedConveyance + earnedSpecial + leaveSalary + incentives;
                string totalEarningsEarnedPayFormatted = totalEarningsEarnedPay.ToString("0,0", CultureInfo.CreateSpecificCulture("hi-IN"));



                int providentFund = Convert.ToInt32((worksheet.Cells[i, 28].Value ?? 0).ToString());
                int ESIC = Convert.ToInt32((worksheet.Cells[i, 27].Value ?? 0).ToString());
                int VoluntaryPF = Convert.ToInt32((worksheet.Cells[i, 29].Value ?? 0).ToString());
                int IncomeTax = Convert.ToInt32((worksheet.Cells[i, 32].Value ?? 0).ToString());
                int LWF = Convert.ToInt32((worksheet.Cells[i, 33].Value ?? 0).ToString());
                int professionalTax = Convert.ToInt32((worksheet.Cells[i, 30].Value ?? 0).ToString());
                int AdvanceAgainstSalary = Convert.ToInt32((worksheet.Cells[i, 31].Value ?? 0).ToString());
                int TotalDeductions = providentFund + ESIC + VoluntaryPF + IncomeTax + LWF + professionalTax + AdvanceAgainstSalary;
                string TotalDeductionsFormatted = TotalDeductions.ToString("0,0", CultureInfo.CreateSpecificCulture("hi-IN"));


                int netPayable = totalEarningsEarnedPay - TotalDeductions;
                string NumberInWords = NumberToWords(netPayable);
                string netPayableFormatted = netPayable.ToString("0,0", CultureInfo.CreateSpecificCulture("hi-IN"));


                int grossSalary = totalEarningsFixedPay;
                int medicalInsurance = Convert.ToInt32((worksheet.Cells[i, 8].Value ?? 0).ToString());
                int employerShareESIC = Convert.ToInt32((worksheet.Cells[i, 11].Value ?? 0).ToString());
                int employerSharePF = Convert.ToInt32((worksheet.Cells[i, 12].Value ?? 0).ToString());
                int employerShareLWF = Convert.ToInt32((worksheet.Cells[i, 9].Value ?? 0).ToString());
                int gratuity = Convert.ToInt32((worksheet.Cells[i, 10].Value ?? 0).ToString());
                int totalCTCForMonth = grossSalary + medicalInsurance + employerShareESIC + employerSharePF + employerShareLWF + gratuity;
                string totalCTCForMonthFormatted = totalCTCForMonth.ToString("0,0", CultureInfo.CreateSpecificCulture("hi-IN"));


                int grossSalaryEarned = totalEarningsEarnedPay;
                int medicalInsuranceEarned = Convert.ToInt32((worksheet.Cells[i, 8].Value ?? 0).ToString());
                int employerShareESICEarned = Convert.ToInt32((worksheet.Cells[i, 27].Value ?? 0).ToString());
                int employerSharePFEarned = Convert.ToInt32((worksheet.Cells[i, 28].Value ?? 0).ToString());
                int employerShareLWFEarned = Convert.ToInt32((worksheet.Cells[i, 33].Value ?? 0).ToString());
                int gratuityEarned = Convert.ToInt32((worksheet.Cells[i, 10].Value ?? 0).ToString());
                int totalCTCForMonthEarned = grossSalaryEarned + medicalInsuranceEarned + employerShareESICEarned + employerSharePFEarned + employerShareLWFEarned + gratuityEarned;
                string totalCTCForMonthEarnedFormatted = totalCTCForMonthEarned.ToString("0,0", CultureInfo.CreateSpecificCulture("hi-IN"));

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">");

                sb.AppendLine("<header style='padding: 5px;font-family:Calibri'>");
                sb.AppendLine("<div class='mainheading' style='display: flex;justify-content: space-between;align-items: center;'>");
                //sb.AppendLine("<div class='company_name' style='display:inline-block'> <p >");
                sb.AppendLine("<div style='display:inline-block'><p>");
                sb.AppendLine("<span style='font-size: 34px; font-weight: bold;'>Business WebSoft Pvt. Ltd.</span></p>");
                sb.AppendLine("<p style='font-size: 20px'>Unit No 7, Second Floor, Royal Motiaz Business Park, Zirakpur-  140604 </p>");
                sb.AppendLine("</div>");

                sb.AppendLine("<div class='compnay_logo' style='display:table-cell; vertical-align:middle' ><img src='https://businesswebsoft.com/wp-content/uploads/2022/06/logo.png' alt='business-websoft ' max-width='150px' style='float:right;margin-left:auto; position:absolute; right:0px;top:30px;padding-right: 5px' /></div>");

                sb.AppendLine("<hr style='margin-bottom:0px;height:4px;background-color: #cccccc;border: none;'/></div>");
                sb.AppendLine("<div>");
                sb.AppendLine("<p style='margin-top:15px;margin-bottom:15px;font-size: 20px; font-weight: bold;display:inline-block;float:left'>");
                sb.AppendLine("Pay Slip for the month of " + month + " " + year);
                sb.AppendLine("</p>");
                sb.AppendLine("<h3 style='font-size: 20px; font-weight: bold;display:inline-block;float:right;margin-left:auto;margin-top:15px;margin-bottom:15px'>" + 
                    (worksheet.Cells[i, 2].Value ?? "-").ToString() + "</h3>");
                sb.AppendLine("</div>");
                sb.AppendLine("<hr style='width: 100%;height:4px;background-color: #cccccc;border: none;' /></header>");

                sb.AppendLine("<table style='width: 100%;background-color: #e6ba7b;font-family:Calibri'>");
                sb.AppendLine("<tbody>");
                sb.AppendLine("<tr style='height: 20px; margin-bottom: 5px;'>");

                sb.AppendLine("<td style='width:33%;vertical-align:baseline;line-height:1.5;word-break: break-word;'>");
                sb.AppendLine("<table><tr><td style='vertical-align:baseline;' width='130px'><b style='padding-left:15px ;'>" +
                    "Employee ID</td><td >BWS-1083</td></tr>" +
                    "<tr><td style='vertical-align:baseline;'><b style='padding-left:15px ;'> " +
                    "Department</b></td><td >" + "Marketing" + "</td>" +
                    "</tr>" + "<tr><td style='vertical-align:baseline'><b style='padding-left:15px'>" +
                    "Designation</b></td><td >" + (worksheet.Cells[i, 3].Value ?? "-").ToString() + "</td></tr></table");
                sb.AppendLine("</td>");

                sb.AppendLine("<td style='width:33%;vertical-align:baseline;line-height:1.5;word-break: break-word;'>");
                sb.AppendLine("<table><tr><td width='130px' style='vertical-align:baseline;'><b style='padding-left:15px ;'>PAN Number</td><td >CEUPC1310K</td></tr>" +
                    "<tr><td style='vertical-align:baseline;'><b style='padding-left:15px ;'> PF UAN No</b></td><td >" + (worksheet.Cells[i, 37].Value ?? "-").ToString() + "</td>" + "</tr>" +
                    "<tr><td style='vertical-align:baseline;'><b style='padding-left:15px;'>ESIC No</b></td><td >" + (worksheet.Cells[i, 36].Value ?? "-").ToString() + "</td></tr>" +
                    //"<tr><td><b style='padding-left:15px;vertical-align:baseline;'>Date of Birth</b></td><td >06-10-1997</td></tr>"+
                    "</table");
                sb.AppendLine("</td>");

                sb.AppendLine("<td style='width:33%;vertical-align:baseline;line-height:1.5;word-break: break-word;'>");
                sb.AppendLine("<table><tr><td width='130px' style='vertical-align:baseline;'><b style='padding-left:15px ;'>Date of Joining</td><td >" + (worksheet.Cells[i, 4].Text ?? "-").ToString() + "</td></tr>" +
                    "<tr><td style='vertical-align:baseline;'><b style='padding-left:15px ;'>Total Days</b></td><td >" +
                    (worksheet.Cells[1, 6].Value ?? "-").ToString() + ".00"

                    + "</td>" +
                    "</tr>" +
                    "<tr><td style='vertical-align:baseline;'><b style='padding-left:15px;'>No of Days Paid</b></td><td >" + (worksheet.Cells[i, 18].Text ?? "-").ToString() + "</td></tr>" +
                    //"<tr><td><b style='padding-left:15px;vertical-align:baseline;'>Leave Days Paid</b></td><td >0.00</td></tr>" +
                    "</table");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</tbody></table>");
                sb.AppendLine("<h3 style='margin-bottom:0px;padding-left:5px;font-family:Calibri'>Salary Details</h3><hr style='height: 4px;background-color: #cccccc;border: none;'/>");
                sb.AppendLine("<table style='width: 100%;margin:0px !important'>");
                sb.AppendLine("<tbody><tr>");
                sb.AppendLine("<td style='width:50%'>");
                sb.AppendLine("<table style='width:100%;border-collapse: collapse;font-family:Calibri'>");
                sb.AppendLine("<tr style='height: 20px;'>");
                sb.AppendLine("<th style='text-align: left;background-color: #e6ba7b;padding: 3px;font-weight: bold;font-size: 20px;padding-left:15px;'>Earnings (&#x20B9;)</th>");
                sb.AppendLine("<th style='text-align: left; background-color: #e6ba7b'></th>");
                sb.AppendLine("<th style='text-align: left;background-color: #e6ba7b;border-right: 2px solid #e6ba7b;'></th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='text-align: left;border-top: 2px solid black;border-bottom: 2px solid black;height: 20px;background-color: #f2f2f2;padding-left:15px;'>Particulars</th>");
                sb.AppendLine("<th style='text-align: center;border-top: 2px solid black;border-bottom: 2px solid black;height: 20px;background-color: #f2f2f2;'>Fixed Pay</th>");
                sb.AppendLine("<th style='text-align: center;border-top: 2px solid black;border-bottom: 2px solid black;height: 20px;border-right: 2px solid #f2f2f2;background-color: #f2f2f2;'>Earned</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='text-align: left; border-bottom: 2px solid #f2f2f2;padding-left:15px;'>Fixed Pay</th>");
                sb.AppendLine("<th style='text-align: center; border-bottom: 2px solid #f2f2f2'></th>");
                sb.AppendLine("<th style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'></th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px;'>Basic Salary</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 14].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 20].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px;'>House Rent Allowance</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 15].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 21].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr><td style='border-bottom: 2px solid #f2f2f2;padding-left:15px;'>");
                sb.AppendLine("Conveyance Allowance</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 16].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 22].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px;'>");
                sb.AppendLine("Special Allowance</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 17].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 23].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr style='height:20px;border-right: 2px solid #f2f2f2;'><td><td><td></tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2'></td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'></td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'></td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='text-align: left; border-bottom: 2px solid #f2f2f2;padding-left:15px;'>Variable Pay</th>");
                sb.AppendLine("<th style='text-align: center; border-bottom: 2px solid #f2f2f2'></th>");
                sb.AppendLine("<th style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'></th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr><td style='border-bottom: 2px solid #f2f2f2;padding-left:15px;'>Leave Salary</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'></td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 25].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='padding-left:15px;'>Incentives</td>");
                sb.AppendLine("<td style='text-align: center;'></td>");
                sb.AppendLine("<td style='text-align: center;border-right: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 24].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2'></td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'></td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;'></td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='border-bottom: 2px solid #f2f2f2;text-align: left;background-color: #faf4cf;padding-left:15px;'>Total Earnings</th>");
                sb.AppendLine("<th style='text-align: center;border-bottom: 2px solid #f2f2f2;background-color: #faf4cf;'>");
                sb.AppendLine((totalEarningsFixedPayFormated ?? "-"));
                sb.AppendLine("</th>");
                sb.AppendLine("<th style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;background-color: #faf4cf;'>");
                sb.AppendLine((totalEarningsEarnedPayFormatted ?? "-"));
                sb.AppendLine("</th></tr></table>");
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='width:50%'>");
                sb.AppendLine("<table style='width:100%;height:287px !important;border-collapse: collapse;font-family:Calibri'>");
                sb.AppendLine("<tr style='height: 20px;' >");
                sb.AppendLine("<th style='text-align: left;background-color: #e6ba7b;padding: 3px;font-weight: bold;font-size: 20px;border-left: 2px solid #e6ba7b;padding-left:15px'>Deductions (&#x20B9;)</th>");
                sb.AppendLine("<th style='background-color: #e6ba7b'></th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='text-align: left;border-top: 2px solid black;border-bottom: 2px solid black;height: 20px;border-left: 2px solid #f2f2f2;background-color: #f2f2f2;padding-left:15px'>Particulars</th>");
                sb.AppendLine("<th style='text-align: right;border-top: 2px solid black;border-bottom: 2px solid black;height: 20px;background-color: #f2f2f2;'>Amount</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='text-align: left;border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>");
                sb.AppendLine("Statutory Deductions</th>");
                sb.AppendLine("<th style='text-align: right; border-bottom: 2px solid #f2f2f2'></th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>Provident Fund</td>");
                sb.AppendLine("<td style='text-align: right; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 28].Text ?? "-").ToString());
                sb.AppendLine("</td></tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>ESIC</td>");
                sb.AppendLine("<td style='text-align: right; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 27].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr><td style='border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>Voluntary PF</td>");
                sb.AppendLine("<td style='text-align: right; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 29].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>Income Tax</td>");
                sb.AppendLine("<td style='text-align: right; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 32].Text ?? "-").ToString());
                sb.AppendLine("</td></tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>");
                sb.AppendLine("LWF");
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: right; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 33].Text ?? "-").ToString());
                sb.AppendLine("</td></tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>Professional Tax</td>");
                sb.AppendLine("<td style='text-align: right; border-bottom: 2px solid #f2f2f2'>" +
                    (worksheet.Cells[i, 30].Text ?? "-").ToString() +
                    "</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='text-align: left;border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;padding-left:15px'>Other Deductions</th>");
                sb.AppendLine("<th style='text-align: right; border-bottom: 2px solid #f2f2f2'></th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-left: 2px solid #f2f2f2;padding-left:15px'>Advance Against Salary</td>");
                sb.AppendLine("<td style='text-align: right; ></td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-left: 2px solid #f2f2f2;'>" + (worksheet.Cells[i, 31].Text ?? "-").ToString() + "</td>");
                sb.AppendLine("<td style='text-align: right; '></td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th");
                sb.AppendLine("style='text-align: left;border-bottom: 2px solid #f2f2f2;border-left: 2px solid #f2f2f2;background-color: #faf4cf;padding-left:15px'>Total Deductions</th>");
                sb.AppendLine("<th style='text-align: right;border-bottom: 2px solid #f2f2f2;background-color: #faf4cf;'>");
                sb.AppendLine((TotalDeductionsFormatted ?? "-"));
                sb.AppendLine("</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</table>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
                sb.AppendLine("<div class=\"net_payable\" style=\"display: flex; gap: 80px;margin-top:5px;margin-bottom:5px;margin-left:5px;font-family:Calibri\">");
                sb.AppendLine("<p style='display:inline-block;margin-right:35px;margin-left:10px;'><b>Net Payable</b></p>");

                if (netPayableFormatted != worksheet.Cells[i, 34].Text.ToString())
                {
                    sb.AppendLine("<i class='fa fa-exclamation-triangle' style='font-family:FontAwesome;color:red;'></i>");
                }
                else
                {
                    sb.AppendLine();
                }
                sb.AppendLine("<p style='display:inline-block'><b>&#x20B9; " + (netPayableFormatted ?? "-") + " (" + NumberInWords + " Rupees Only)</b>");
                sb.AppendLine("</p>");
                sb.AppendLine("</div>");
                sb.AppendLine("<table style='width: 100%;margin:0px !important;font-family:Calibri'>");
                sb.AppendLine("<tbody>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='width:100%'>");
                sb.AppendLine("<table style='width:100%;border-collapse: separate;border-spacing:0; height:165px'>");
                sb.AppendLine("<th style='text-align: center; '></th>");
                sb.AppendLine("<th");
                sb.AppendLine("style='text-align: center;'>");
                sb.AppendLine("</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("");
                sb.AppendLine("<tr style='height: 20px;'>");
                sb.AppendLine("<th");
                sb.AppendLine("style='text-align: left;background-color: #e6ba7b;padding: 3px;font-weight: bold;font-size: 20px;padding-left:15px'>");
                sb.AppendLine("CTC Details (&#x20B9;)");
                sb.AppendLine("</th>");
                sb.AppendLine("<th style='text-align: left; background-color: #e6ba7b'></th>");
                sb.AppendLine("<th style='text-align: left;background-color: #e6ba7b;border-right: 2px solid #e6ba7b;'></th>");
                sb.AppendLine("<th style='width:50% ;text-align: left; background-color: #e6ba7b'>");
                sb.AppendLine("</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px'>Gross Salary</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((totalEarningsFixedPayFormated ?? "-"));
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine((totalEarningsEarnedPayFormatted ?? "-"));
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='width:50% ;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px'>");
                sb.AppendLine("Medical Insurance");
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 8].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td");
                sb.AppendLine("style='text-align: center;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 8].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='width:50%;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px'>Employer Share - ESIC</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 11].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 27].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='width:50%;border-bottom: 2px solid #f2f2f2;'></td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px'>");
                sb.AppendLine("Employer Share - PF</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 12].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 28].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='width:50% ;border-bottom: 2px solid #f2f2f2;'></td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px'>");
                sb.AppendLine("Employer Share - LWF</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 9].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 33].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='width:50% ;border-bottom: 2px solid #f2f2f2;'></td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='border-bottom: 2px solid #f2f2f2;padding-left:15px'>Gratuity</td>");
                sb.AppendLine("<td style='text-align: center; border-bottom: 2px solid #f2f2f2'>");
                sb.AppendLine((worksheet.Cells[i, 10].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='text-align: center;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine((worksheet.Cells[i, 10].Text ?? "-").ToString());
                sb.AppendLine("</td>");
                sb.AppendLine("<td style='width:50% ;border-bottom: 2px solid #f2f2f2;'>");
                sb.AppendLine("</td></tr>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th style='border-bottom: 2px solid #f2f2f2;text-align: left;background-color: #faf4cf;;padding-left:15px'>Total CTC for the month</th>");
                sb.AppendLine("<th style='text-align: center;border-bottom: 2px solid #f2f2f2;background-color: #faf4cf;'>"); ;
                sb.AppendLine(totalCTCForMonthFormatted);
                sb.AppendLine("</th>");
                sb.AppendLine("<th style='text-align: center;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;background-color: #faf4cf;'>");
                sb.AppendLine(totalCTCForMonthEarnedFormatted);
                sb.AppendLine("</th>");
                sb.AppendLine("<td style='width:50%;border-bottom: 2px solid #f2f2f2;border-right: 2px solid #f2f2f2;background-color: #faf4cf;'></td>");
                sb.AppendLine("</tr></table>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
                sb.AppendLine("<table style='width: 100%;text-align:left;position:absolute;bottom:0px;font-family:Calibri'><tbody><tr style='height: 20px; margin-bottom: 5px'><td style='width:100%'><center><p><i><b>Computer Generated Slip, Signature Not Required</b></i></p></center></td></tr></tbody></table>");

                string fileName = worksheet.Cells[i, 2].Value.ToString().Replace(' ', '_') + "_" + month + "_" + year + ".pdf";

                HtmlToPdfConverter nPdf = new HtmlToPdfConverter();
                var margins = new PageMargins();
                margins.Bottom = 2;
                margins.Top = 2;
                margins.Left = 2;
                margins.Right = 2;
                nPdf.Margins = margins;
                nPdf.Orientation = PageOrientation.Portrait;
                string fileNames = worksheet.Cells[i, 2].Value.ToString().Replace(' ', '_') + "_" + month + "_" + year + ".pdf";
                byte[] bytes = nPdf.GeneratePdf(sb.ToString()).ToArray();
                System.IO.File.WriteAllBytes(zippath + "/" + fileNames, bytes);
            }

            var sourcezipPath = new PhysicalFileProvider(zippath).Root;
            var zipname = $"SalarySlip_{month}_{year}.zip";

            string destinationPath = "";
            if (_hostingEnvironment.IsProduction())
            {
                destinationPath = Path.Combine(Directory.GetCurrentDirectory(), @"FilesSalary\ZipsUpload", zipname);
            }
            else
            {
                destinationPath = Path.Combine(Directory.GetCurrentDirectory(), @"FilesSalary\ZipsUpload", zipname);
            }

            if (System.IO.File.Exists(destinationPath))
            {
                System.IO.File.Delete(destinationPath);
            }


            try
            {
                ZipFile.CreateFromDirectory(sourcezipPath, destinationPath);
                result.filepath = zipname;
            }
            catch (Exception ex)
            {
                result.filepath = ex.ToString();
            }
            return result;




        }*/
    }

}

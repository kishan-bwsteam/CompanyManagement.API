using Datas.Abstract;
using Dto.Model.Common;
using NReco.PdfGenerator;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Service.Abstract;
using System;
using System.IO;



namespace Service.Concrete
{
    public class AttendanceRegisterService : IAttendanceRegisterService
    {
        private readonly IAttendanceRegisterRepository _IAttendanceRegisterRepository;


        public AttendanceRegisterService(IAttendanceRegisterRepository attendanceRegisterRepository)
        {
            _IAttendanceRegisterRepository = attendanceRegisterRepository;
        }

        public AttendanceViewModels GetAll(int companyID)
        {
            return _IAttendanceRegisterRepository.GetAll(companyID);
        }
        public Response GernateSalary(int companyID, int date,int year)
        {
            Response response = new Response();
            GernateSalaryViewModels report = new GernateSalaryViewModels();

            //report=_IAttendanceRegisterRepository.GernateSalary(companyID,date);

            response = GernateExcel(companyID, date,year);
            response = GernatePdf(companyID, date,year);
            return response;
        }
        public Response GernatePdf(int companyID, int date,int year)
        {
            Response response = new Response();
            try
            {
                var data = _IAttendanceRegisterRepository.GernateSalary(companyID, date, year);
                string html = "<html> " +
                    "<head</head>" +
                    "<body> <div><h1 align='center'> Salary of " + data.DetailModelList[0].Months + "</h1></div>" +
                    "<table border='1' cellspacing='2'>" +
                    "<tr bgcolor='#F39C12'>" +
                    "<th rowspan='2'><font color='white'>EmployeeId</font></th> <th rowspan='2'><font color='white'>Name</font>" +
    "</th><th rowspan='2'> <font color='white'>TotalMonthDays</font></th><th rowspan='2'><font color='white'>WorkingDays</font> </th>" +
                     "<th rowspan='2'><font color='white'>AbsentDays</font> </th><th rowspan='2'><font color='white'>FullDays</font> " +
                                    "</th><th rowspan='2'><font color='white'>HalfDays</font> </th><th rowspan='2'> <font color='white'>ShortLeaves</font>" +
                                                     "</th><th rowspan='2'><font color='white'>LeaveDueLessTime</font> </th><th colspan='10'> <font color='white'>Salary Break up</font> " +
                                                                      "</th> </tr> <tr> <th> Basic Salary</th><th> HRA" +
                                                                                       "</th><th> C.Allowance </th><th> Spacel Allowance " +
                                                                                                           " </th><th>Provident Fund </th><th>  LWF" +
                                                                                                                            " </th><th>Professional Tax </th> <th>  Medical Insurance</th><th> Gratuity</th> " +
                                                                                                                            "</tr>"
                                                                                                                           ;

                string s = "";
                foreach (var item in data.DetailModelList)
                {

                    s = s + " <tr bgcolor='#FCF3CF'> <td> " + item.EmployeeID + "</td>" +
                    "<td>" + item.UserName + "</td>" +
                        "<td>" + item.TotalMonthDays + "</td>" +
                        "<td>" + item.WorkingDays + "</td>" +
                        "<td>" + item.AbsentDays + "</td>" +
                        "<td>" + item.FullDays + "</td>" +
                        "<td>" + item.HalfDays + "</td>" +
                        "<td>" + item.ShortLeave + "</td> " +
                        "<td<" + item.LeaveDueLessTime + "</td>" +
                        "<td>" + item.LeaveDueLessTime + "</td> ";
                    ;
                    foreach (var salary in data.SalaryBreakUpModelList)
                    {

                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Basic Salary ")
                        { s = s + "<td> " + salary.CalculateValues + "</td>"; }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "House Rent Allowance")
                        { s = s + "<td> " + salary.CalculateValues + "</td>"; }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Conveyance Allowance")
                        {
                            s = s + "<td> " + salary.CalculateValues + "</td>";
                        }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Special Allowance")
                        {
                            s = s + "<td> " + salary.CalculateValues + "</td>";
                        }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Provident Fund ")
                        { s = s + "<td> " + salary.CalculateValues + "</td>"; }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Medical Insurance")
                        { s = s + "<td> " + salary.CalculateValues + "</td>"; }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "LWF")
                        { s = s + "<td> " + salary.CalculateValues + "</td>"; }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Professional Tax")
                        { s = s + "<td> " + salary.CalculateValues + "</td>"; }
                        if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Gratuity")
                        { s = s + "<td> " + salary.CalculateValues + "</td>"; }


                    }
                }
                html = html + s + "</table> </body></html>";

                string htmlContent = html;


                string _filepath = "D:\\SalaryFilePdf.pdf";

                var htmlToPdf = new HtmlToPdfConverter();

                htmlToPdf.Orientation = PageOrientation.Landscape;
                htmlToPdf.PageWidth = 100;

                if (File.Exists(_filepath))
                {
                    File.Delete(_filepath);
                }


                htmlToPdf.GeneratePdf(htmlContent, null, _filepath);
                response.Message = "Excel Gernate Successfuly";
                response.Status = 200;
            }

            catch (Exception ex)
            {
                response.Message = ex.ToString();
                response.Status = -99;

            }

            // return DownloadFile(filePath);
            return response;
        }

            


     
        public Response GernateExcel(int companyID, int date,int year)
        {

            var data = _IAttendanceRegisterRepository.GernateSalary(companyID, date,year);
            Response response = new Response();

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var excelPackage = new ExcelPackage())
                {

                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SalarySheet");

                    worksheet.Cells["A1"].Value = "Salary Of Month " + data.DetailModelList[0].Months;
                    worksheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                    worksheet.Cells["A1"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                    // worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("gray"));
                    worksheet.Cells["A1:R1"].Merge = true;
                    worksheet.Cells["A2"].Value = "EmployeeID";
                    worksheet.Cells["A2:A3"].Merge = true;
                    worksheet.Cells["B2"].Value = "FirstName";
                    worksheet.Cells["B2:B3"].Merge = true;
                    worksheet.Cells["C2"].Value = "TotalMonthDays";
                    worksheet.Cells["C2:C3"].Merge = true;
                    worksheet.Cells["D2"].Value = "WorkingDays";
                    worksheet.Cells["D2:D3"].Merge = true;
                    worksheet.Cells["E2"].Value = "AbsentDays";
                    worksheet.Cells["E2:E3"].Merge = true;
                    worksheet.Cells["F2"].Value = "FullDays";
                    worksheet.Cells["F2:F3"].Merge = true;
                    worksheet.Cells["G2"].Value = "HalfDays";
                    worksheet.Cells["G2:G3"].Merge = true;
                    worksheet.Cells["H2"].Value = "ShortLeave";
                    worksheet.Cells["H2:H3"].Merge = true;
                    worksheet.Cells["I2"].Value = "LeaveDueLessTime";
                    worksheet.Cells["I2:I3"].Merge = true;
                    worksheet.Cells["J2"].Value = "Salary Break Up";
                    worksheet.Cells["J2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells["A2:J2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["A2:J2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.AntiqueWhite);
                    worksheet.Cells.AutoFitColumns();

                    worksheet.Cells["J2:R2"].Merge = true;
                    worksheet.Cells["J3"].Value = "Basic";
                    worksheet.Cells["K3"].Value = "HRA";
                    worksheet.Cells["L3"].Value = "C.Allownce";
                    worksheet.Cells["M3"].Value = "Spacel Allownce";
                    worksheet.Cells["N3"].Value = "PF";
                    worksheet.Cells["O3"].Value = "ESI";
                    worksheet.Cells["P3"].Value = "LWF";
                    worksheet.Cells["Q3"].Value = "Pro.Tax";
                    worksheet.Cells["R3"].Value = "Gratuity";

                    worksheet.Cells["J3:R3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["J3:R3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);






                    int row = 4;
                    foreach (var item in data.DetailModelList)
                    {
                        worksheet.Cells["A" + row].Value = item.EmployeeID == 0 ? 0 : item.EmployeeID;
                        worksheet.Cells["B" + row].Value = item.UserName == null ? "No Data" : item.UserName;
                        worksheet.Cells["C" + row].Value = item.TotalMonthDays == 0 ? 0 : item.TotalMonthDays;
                        worksheet.Cells["D" + row].Value = item.WorkingDays == 0 ? 0 : item.WorkingDays;
                        worksheet.Cells["E" + row].Value = item.AbsentDays == 0 ? 0 : item.AbsentDays;
                        worksheet.Cells["F" + row].Value = item.FullDays == 0 ? 0 : item.FullDays;
                        worksheet.Cells["G" + row].Value = item.HalfDays == 0 ? 0 : item.HalfDays;
                        worksheet.Cells["H" + row].Value = item.ShortLeave == 0 ? 0 : item.ShortLeave;
                        worksheet.Cells["I" + row].Value = item.LeaveDueLessTime == 0 ? 0 : item.LeaveDueLessTime;
                        foreach (var salary in data.SalaryBreakUpModelList)
                        {
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Basic Salary ")
                            { worksheet.Cells["J" + row].Value = salary.CalculateValues; }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "House Rent Allowance")
                            { worksheet.Cells["K" + row].Value = salary.CalculateValues; }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Conveyance Allowance")
                            {
                                worksheet.Cells["L" + row].Value = salary.CalculateValues;
                            }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Special Allowance")
                            {
                                worksheet.Cells["M" + row].Value = salary.CalculateValues;
                            }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Provident Fund ")
                            { worksheet.Cells["N" + row].Value = salary.CalculateValues; }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Medical Insurance")
                            { worksheet.Cells["O" + row].Value = salary.CalculateValues; }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "LWF")
                            { worksheet.Cells["P" + row].Value = salary.CalculateValues; }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Professional Tax")
                            { worksheet.Cells["Q" + row].Value = salary.CalculateValues; }
                            if (item.EmployeeID == salary.EmployeeID && salary.DisplayName == "Gratuity")
                            { worksheet.Cells["R" + row].Value = salary.CalculateValues; }
                        }
                        row++;
                    }
                    worksheet.Cells["A1:R" + row].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["A1:R" + row].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["A1:R" + row].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells["A1:R" + row].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells.AutoFitColumns();
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedExcelfile", "D:\\CM_SalaryReport\\SalaryFileExcel.xlsx");

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    excelPackage.SaveAs(new FileInfo(filePath));
                }
                response.Message = "Excel Gernate Successfuly";
                response.Status = 200;
            }

            catch (Exception ex)
            {
                response.Message = ex.ToString();
                response.Status = -99;

            }

                // return DownloadFile(filePath);
                return response;
            }
          

        }
    }

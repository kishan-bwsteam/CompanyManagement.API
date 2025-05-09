using CompanyManagement.Data.Datas.Abstract;
using CompanyManagement.Data.Datas.Concrete;
using CompanyManagement.Datas.Concrete;
using CompanyManagement.Repository.Interface;
using CompanyManagement.Repository.Repositories;
using CompanyManagement.Service.Interface;
using CompanyManagement.Service.Services;
using CompanyManagement.Services.Service.Abstract;
using CompanyManagement.Services.Service.Concrete;
using Datas.Abstract;
using Datas.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Service.Abstract;
using Service.Concrete;
using SqlDapper.Abstract;
using SqlDapper.Concrete;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

services.AddScoped(typeof(HttpClient), typeof(HttpClient));
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddTransient<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddTransient<IDatabaseContext, DatabaseContext>();
services.AddTransient<ITransitTimeOperationService, TransitTimeOperationService>();
services.AddTransient<ITransitTimeOperationRepository, TransitTimeOperationRepository>();
services.AddTransient<ILoginRepository, LoginRepository>();
services.AddTransient<ILoginService, LoginService>();
services.AddTransient<IUserService, UserService>();
services.AddTransient<IUserRepository, UserRepository>();
services.AddScoped<IPositionService, PositionService>();
services.AddScoped<IPositionRepositiory, PositionRepositiory>();
services.AddTransient<IRoleService, RoleService>();
services.AddTransient<IRoleDataRepository, RoleDataRepository>();
services.AddTransient<IResetPasswordService, ResetPasswordService>();
services.AddTransient<IResetPasswordRepository, ResetPasswordRepository>();
services.AddTransient<IDepartmentService, DepartmentService>();
services.AddTransient<IDepartmentRepository, DepartmentRepository>();
services.AddTransient<IEmpPersonalDetailService, EmpPersonalDetailService>();
services.AddTransient<IEmpPersonalDetailRepository, EmpPersonalDetailRepository>();
services.AddTransient<IEmpAddressService, EmpAddressService>();
services.AddTransient<IEmpAddressRepository, EmpAddressRepository>();
services.AddTransient<IEmpEducationRepository, EmpEducationRepository>();
services.AddTransient<IEmpEducationService, EmpEducationService>();
services.AddTransient<IEmpEmploymentService, EmpEmploymentService>();
services.AddTransient<IEmpEmploymentRepository, EmpEmploymentRepository>();
services.AddTransient<IEmpBankRepository, EmpBankRepository>();
services.AddTransient<IEmpBankService, EmpBankService>();
services.AddTransient<IEmployeeDetailService, EmployeeDetailService>();
services.AddTransient<IEmployeeDetailRepository, EmployeeDetailRepository>();
services.AddTransient<IOfficialCommunicationRepository, OfficialCommunicationRepository>();
services.AddTransient<IOfficialCommunicationService, OfficialCommunicationService>();
services.AddTransient<ILeaveDataRepository, LeaveDataRepository>();
services.AddTransient<ILeaveService, LeaveService>();
services.AddTransient<IDocumentsService, DocumentsService>();
services.AddTransient<IDocumentsRepository, DocumentsRepository>();
services.AddTransient<IWagesRepository, WagesRepository>();
services.AddTransient<IWagesService, WagesService>();
services.AddTransient<IEmergencyRepository, EmergencyRepository>();
services.AddTransient<IEmergencyService, EmergencyService>();
services.AddTransient<INotesService, NotesService>();
services.AddTransient<INotesRepository, NotesRepository>();
services.AddTransient<ISalaryService, SalaryService>();
services.AddTransient<ISalaryRepository, SalaryRepository>();
services.AddTransient<ICompanyRepository, CompanyRepository>();
services.AddTransient<ICompanyService, CompanyService>();
services.AddTransient<ICreateUserAdminService, CreateUserAdminService>();
services.AddTransient<ICreateUserAdminRepository, CreateUserAdminRepository>();
services.AddTransient<IAttendanceService, AttendanceService>();
services.AddTransient<IAttendanceRepository, AttendanceRepository>();
services.AddTransient<ICompanyShiftSettingService, CompanyShiftSettingService>();
services.AddTransient<ICompanyShiftSettingRepository, CompanyShiftSettingRepository>();
services.AddTransient<IEmailMassagesRepository, EmailMassagesRepository>();
services.AddTransient<IEmailMassagesService, EmailMassagesService>();
services.AddTransient<IWeekOffRepository, WeekOffRepository>();
services.AddTransient<IWeekOffService, WeekOffService>();
services.AddTransient<IJoiningLetterRepository, JoiningLetterRepository>();
services.AddTransient<IJoiningLetterService, JoiningLetterService>();
services.AddTransient<IShiftRulesRepository, ShiftRulesRepository>();
services.AddTransient<IShiftRulesService, ShiftRulesService>();
services.AddTransient<IAttendanceRegisterRepository, AttandanceRegisterRepository>();
services.AddTransient<IAttendanceRegisterService, AttendanceRegisterService>();
services.AddTransient<ILetterRepository, LetterRepository>();
services.AddTransient<ILetterService, LetterService>();
services.AddTransient<ICalLeaveService, CalLeaveService>();
services.AddTransient<ICalLeaveRepository, CalLeaveRepository>();
services.AddTransient<ISummaryService, SummaryService>();
services.AddTransient<ISummaryRepository, SummaryRepository>();
services.AddTransient<ISupportTicketRepository, SupportTicketRepository>();
services.AddTransient<ISupportTicketService, SupportTicketService>();
services.AddTransient<IPlatformService, PlatformService>();
services.AddTransient<IProfileService, ProfileService>();
services.AddTransient<IBidderService, BidderService>();
services.AddTransient<IProjectService, ProjectService>();
services.AddTransient<IPlatformRepository, PlatformRepository>();
services.AddTransient<IProfileRepository, ProfileRepository>();
services.AddTransient<IBidderRepository, BidderRepository>();
services.AddTransient<IProjectRepository, ProjectRepository>();
services.AddTransient<IClientRepository, ClientRepository>();
services.AddTransient<IClientService, ClientService>();
services.AddTransient<IEmployeePerformanceRepository, EmployeePerformanceRepository>();
services.AddTransient<IEmployeePerformanceService, EmployeePerformanceService>();
services.AddTransient<IPerformanceAttributeRepository, PerformanceAttributeRepository>();
services.AddTransient<IPerformanceAttributeService, PerformanceAttributeService>();
services.AddTransient<IProjectMappingRepository, ProjectMappingRepository>();
services.AddTransient<IProjectMappingService, ProjectMappingService>();
services.AddTransient<IEmpProjectTimeRepository, EmpProjectTimeRepository>();
services.AddTransient<IEmpProjectTimeService, EmpProjectTimeService>();

services.AddTransient<ICommonService, CommonService>();
services.AddTransient<IEmployeeRepository, EmployeeRepository>();
services.AddTransient<IEmployeeService, EmployeeService>();

services.AddTransient<ICommonRepository, CommonFunRepository>();

builder.Services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();
builder.Services.AddScoped<IAddressTypeService, AddressTypeService>();

builder.Services.AddScoped<ICountryStateService, CountryStateService>();
builder.Services.AddScoped<ICountryStateRepository, CountryStateRepository>();


builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            "AllowCors",
            policy =>
            {
                policy.SetIsOriginAllowed(x => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
    });


//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenAnyIP(5000); // HTTP
//    serverOptions.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // HTTPS
//});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

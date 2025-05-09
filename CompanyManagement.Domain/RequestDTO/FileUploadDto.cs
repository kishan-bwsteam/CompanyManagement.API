using Microsoft.AspNetCore.Http;

namespace CompanyManagement.Domain.RequestDTO
{
    public class FileUploadDto
    {
        public IFormFile File { get; set; }
    }
}

using MyOnionApi1.Application.DTOs.Email;
using System.Threading.Tasks;

namespace MyOnionApi1.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}

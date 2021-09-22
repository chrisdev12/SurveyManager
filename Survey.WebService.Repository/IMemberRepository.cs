using Survey.WebService.Models;
using Survey.WebService.Models.DTOs;
using System.Threading.Tasks;

namespace Survey.WebService.Repository
{
    public interface IMemberRepository
    {
        public Task<string> Register(MemberResultDTO newResult);
    }
}

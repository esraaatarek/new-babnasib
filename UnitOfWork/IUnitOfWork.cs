using System.Threading.Tasks;
using Api.IRepositories;

namespace Api.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IFileUploadRepository FileUploadRepository { get; }
        Task<bool> Complete();
    }
}
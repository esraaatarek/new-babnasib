using System.Threading.Tasks;
using Api.Data;
using Api.IRepositories;
using Api.Repositories;
using AutoMapper;

namespace Api.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IFileUploadRepository FileUploadRepository => new FileUploadRepository();

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
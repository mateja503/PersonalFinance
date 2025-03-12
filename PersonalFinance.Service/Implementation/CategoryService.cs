using PersonalFinance.Repository.UnifOfWorkRepository;
using PersonalFinance.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Implementation
{
    public class CategoryService(IUnitOfWorkRepository unitOfWork) : ICategoryService
    {
        private readonly IUnitOfWorkRepository _unitOfWork = unitOfWork;
    }
}

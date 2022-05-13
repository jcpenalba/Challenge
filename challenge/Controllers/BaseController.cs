using AutoMapper;
using hallenge.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseController()
        {
            _mapper = AutomapperConfiguration.Instance().CreateMapper();
        }
    }
}

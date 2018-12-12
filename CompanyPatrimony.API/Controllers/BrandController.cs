using System;
using System.Collections.Generic;
using CompanyPatrimony.Service.Contracts;
using CompanyPatrimony.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPatrimony.API.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IPatrimonyService _patrimonyService;
        private readonly IBrandService _brandService;

        public BrandController(IPatrimonyService patrimonyService, IBrandService brandService)
        {
            _patrimonyService = patrimonyService;
            _brandService = brandService;
        }



        [HttpGet]
        [Route("brand")]
        public IEnumerable<BrandViewModel> Get()
        {
            return _brandService.GetAll();
        }

        [HttpGet]
        [Route("brand/{id:guid}/patromony")]
        public IEnumerable<PatrimonyViewModel> GetByIdBrand(Guid id)
        {
            return _patrimonyService.GetAllByIdBrand(id);
        }

        [HttpGet]
        [Route("brand/{id:guid}")]
        public BrandViewModel GetById(Guid id)
        {
            return _brandService.GetById(id);
        }

        [HttpPost]
        [Route("brand")]
        public IActionResult Post([FromBody] BrandViewModel brandViewModel)
        {
            var result = _brandService.Add(brandViewModel);
            SetNotifications(_patrimonyService.GetNotifications());
            return Response(result);
        }

        [HttpPut]
        [Route("brand")]
        public IActionResult Put([FromBody] BrandViewModel brandViewModel)
        {
            var result = _brandService.Add(brandViewModel);
            SetNotifications(_patrimonyService.GetNotifications());
            return Response(result);
        }

        [HttpDelete]
        [Route("brand/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _brandService.Remove(id);
            SetNotifications(_patrimonyService.GetNotifications());
            return Response();
        }
    }
}
using System;
using System.Collections.Generic;
using CompanyPatrimony.Service.Contracts;
using CompanyPatrimony.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPatrimony.API.Controllers
{
    public class PatrimonyController : BaseController
    {
        private readonly IPatrimonyService _patrimonyService;

        public PatrimonyController(IPatrimonyService patrimonyService)
        {
            _patrimonyService = patrimonyService;
        }

        [HttpGet]
        [Route("patrimony")]
        public IEnumerable<PatrimonyViewModel> Get()
        {
            return _patrimonyService.GetAll();
        }

        [HttpGet]
        [Route("patrimony/{id:guid}")]
        public PatrimonyViewModel GetById(Guid id)
        {
            return _patrimonyService.GetById(id);
        }

        [HttpPost]
        [Route("patrimony")]
        public IActionResult Post([FromBody] PatrimonyViewModel patrimonyViewModel)
        {
            var result = _patrimonyService.Add(patrimonyViewModel);
            SetNotifications(_patrimonyService.GetNotifications());
            return Response(result);
        }

        [HttpPut]
        [Route("patrimony")]
        public IActionResult Put([FromBody] PatrimonyViewModel patrimonyViewModel)
        {
            var result = _patrimonyService.Add(patrimonyViewModel);
            SetNotifications(_patrimonyService.GetNotifications());
            return Response(result);
        }

        [HttpDelete]
        [Route("patrimony/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _patrimonyService.Remove(id);
            SetNotifications(_patrimonyService.GetNotifications());
            return Response();
        }
    }
}
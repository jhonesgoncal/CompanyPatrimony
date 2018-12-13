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
            SetNotifications(result.Item2);
            return Response(result.Item1);
        }

        [HttpPut]
        [Route("patrimony")]
        public IActionResult Put([FromBody] PatrimonyViewModel patrimonyViewModel)
        {
            var result = _patrimonyService.Update(patrimonyViewModel);
            SetNotifications(result.Item2);
            return Response(result.Item1);
        }

        [HttpDelete]
        [Route("patrimony/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var result = _patrimonyService.Remove(id);
            SetNotifications(result);
            return Response();
        }
    }
}
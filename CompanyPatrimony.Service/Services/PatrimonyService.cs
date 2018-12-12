using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CompanyPatrimony.Domain.Contracts;
using CompanyPatrimony.Domain.Core.Commands;
using CompanyPatrimony.Domain.Core.Contracts;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Service.Contracts;
using CompanyPatrimony.Service.ViewModels;
using Flunt.Notifications;

namespace CompanyPatrimony.Service.Services
{
    public class PatrimonyService : BaseService, IPatrimonyService
    {
        private readonly IMapper _mapper;
        private readonly IPatrimonyRepository _patrimonyRepository;
        private readonly IBrandService _brandService;
        private readonly IUnitOfWork _unitOfWork;
        

        public PatrimonyService(IMapper mapper, IPatrimonyRepository patrimonyRepository, IBrandService brandService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _patrimonyRepository = patrimonyRepository;
            _brandService = brandService;
            _unitOfWork = unitOfWork;
        }

        public PatrimonyViewModel Add(PatrimonyViewModel viewModel)
        {
            var entity = _mapper.Map<Patrimony>(viewModel);
            if (entity.Valid)
            {
                var brand = _brandService.GetById(entity.BrandId);
                if (brand != null)
                {
                    _patrimonyRepository.Add(entity);
                    CommandResponse commandResponse = _unitOfWork.Commit();
                    if (!commandResponse.Success)
                    {
                        entity.AddNotification("", "Erro ao salvar");
                    }
                }
                else
                    entity.AddNotification("Brand", "Marca nao cadastrada");
            }

            AddNotifications(entity.Notifications);

            return _mapper.Map<PatrimonyViewModel>(entity);
        }

        public PatrimonyViewModel Update(PatrimonyViewModel viewModel)
        {
            var entity = _mapper.Map<Patrimony>(viewModel);
            if (entity.Valid)
            {
                var brand = _brandService.GetById(entity.BrandId);
                if (brand != null)
                {
                    _patrimonyRepository.Update(entity);
                    CommandResponse commandResponse = _unitOfWork.Commit();
                    if (!commandResponse.Success)
                    {
                        entity.AddNotification("", "Erro ao salvar");
                    }
                }
                else
                    entity.AddNotification("Brand", "Marca nao cadastrada");
            }

            AddNotifications(entity.Notifications);
            return _mapper.Map<PatrimonyViewModel>(entity);
        }

        public IEnumerable<PatrimonyViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<PatrimonyViewModel>>(_patrimonyRepository.GetAll());
        }

        public IEnumerable<PatrimonyViewModel> GetAllByIdBrand(Guid id)
        {
            return _mapper.Map<IEnumerable<PatrimonyViewModel>>(_patrimonyRepository.GetAllByIdBrand(id));
        }

        public PatrimonyViewModel GetById(Guid id)
        {
            return _mapper.Map<PatrimonyViewModel>(_patrimonyRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            _patrimonyRepository.Remove(id);
            CommandResponse commandResponse = _unitOfWork.Commit();
            if (!commandResponse.Success)
            {
                AddNotification(new Notification("", "Erro ao excluir"));
            }
        }

        public void Dispose()
        {
            _patrimonyRepository.Dispose();
        }
    }
}
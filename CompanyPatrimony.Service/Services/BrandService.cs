using System;
using System.Collections.Generic;
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
    public class BrandService : BaseService, IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IMapper mapper, IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public BrandViewModel Add(BrandViewModel viewModel)
        {
            var entity = _mapper.Map<Brand>(viewModel);
            if (entity.Valid)
            {
                var brand = _brandRepository.Find(x => x.Name.ToLower() == entity.Name.ToLower());
                if (brand == null)
                {
                    _brandRepository.Add(entity);
                    CommandResponse commandResponse = _unitOfWork.Commit();
                    if (!commandResponse.Success)
                    {
                        entity.AddNotification("", "Erro ao salvar");
                    }
                }
                    
                else
                    entity.AddNotification("Brand", "Marca ja cadastrada");
            }

            AddNotifications(entity.Notifications);
            return _mapper.Map<BrandViewModel>(entity);
        }

        public BrandViewModel Update(BrandViewModel viewModel)
        {
            var entity = _mapper.Map<Brand>(viewModel);
            if (entity.Valid)
               _brandRepository.Update(entity);

            AddNotifications(entity.Notifications);
            return _mapper.Map<BrandViewModel>(entity);
        }

        public IEnumerable<BrandViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<BrandViewModel>>(_brandRepository.GetAll());
        }

        public BrandViewModel GetById(Guid id)
        {
            return _mapper.Map<BrandViewModel>(_brandRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            _brandRepository.Remove(id);
            CommandResponse commandResponse = _unitOfWork.Commit();
            if (!commandResponse.Success)
            {
                AddNotification(new Notification("", "Erro ao excluir"));
            }
        }

        public void Dispose()
        {
            _brandRepository.Dispose();
        }
    }
}
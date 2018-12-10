using System;
using CompanyPatrimony.Domain.Core.Entities;
using Flunt.Validations;

namespace CompanyPatrimony.Domain.Entities
{
    public class Patrimony : Entity
    {
        public Patrimony(string name, string description,  Brand brand)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(name, "Name", "O nome do patrimonio é obrigatorio")
                .HasMinLen(name, 3, "Name", "O nome do patrimonio deve ter no minimo 3 caracteres")
                .HasMaxLen(name, 100, "Name", "O nome do patrimonio deve ter no maximo 100 caracteres")
                .IsNotNullOrEmpty(description, "Description", "A descrição do patrimonio é obrigatoria")
                .HasMinLen(description, 3, "Description", "A descrição do patrimonio deve ter no minimo 3 caracteres")
                .HasMaxLen(description, 500, "Description", "A descrição do patrimonio deve ter no maximo 500 caracteres")
            );

            AddNotifications(brand.Notifications);

            Name = name;
            Description = description;
            NumberTumble = Guid.NewGuid();
            Brand = brand;     
        }

        protected Patrimony() { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid NumberTumble { get; private set; }
        public Guid BrandId { get; private set; }

        //EF props de navegação
        public virtual Brand Brand { get; private set; }
    }
}
using System.Collections.Generic;
using CompanyPatrimony.Domain.Core.Entities;
using Flunt.Validations;

namespace CompanyPatrimony.Domain.Entities
{
    public class Brand : Entity
    {
        public Brand(string name)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(name, "Name", "O nome da marca é obrigatorio")
                .HasMinLen(name, 3, "Name", "O nome da marca deve ter no minimo 3 caracteres")
                .HasMaxLen(name, 100, "Name", "O nome da marca deve ter no maximo 100 caracteres")
            );

            Name = name;
        }

        //EF Construtor
        protected Brand() { }

        public string Name { get; private set; }

        //Prop navegação EF
        public ICollection<Patrimony> Patrimonies { get; set; }


    }
}
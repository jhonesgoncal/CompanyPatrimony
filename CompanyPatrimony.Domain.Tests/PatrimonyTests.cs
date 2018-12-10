using CompanyPatrimony.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyPatrimony.Domain.Tests
{
    [TestClass]
    public class PatrimonyTests
    {
        private readonly Brand _brand = new Brand("Teste");

        [TestMethod]
        [TestCategory("Patrimony - new Patrimony")]
        public void GivenAValidPatrimonyShouldCreateValidPatrimony()
        {
            var patrimony = new Patrimony("Patrominio 1", "Desc 1", _brand);

            Assert.IsTrue(patrimony.Valid);
        }

        [TestMethod]
        [TestCategory("Patrimony - new Patrimony")]
        public void GivenAnInvalidNameShouldReturnANotification()
        {
            var patrimony = new Patrimony("", "Desc 1", _brand);

            Assert.IsFalse(patrimony.Valid);
        }

        [TestMethod]
        [TestCategory("Patrimony - new Patrimony")]
        public void GivenAnInvalidDescritionShouldReturnANotification()
        {
            var patrimony = new Patrimony("Teste", "D", _brand);

            Assert.IsFalse(patrimony.Valid);
        }

    }
}
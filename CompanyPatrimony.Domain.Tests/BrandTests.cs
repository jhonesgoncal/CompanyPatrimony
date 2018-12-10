using CompanyPatrimony.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyPatrimony.Domain.Tests
{
    [TestClass]
    public class BrandTests
    {
        [TestMethod]
        [TestCategory("Brand - new Brand")]
        public void GivenAValidNameShouldCreateValidBrand()
        {
            var patrimony = new Brand("Brand 1");

            Assert.IsTrue(patrimony.Valid);
        }

        [TestMethod]
        [TestCategory("Brand - new Brand")]
        public void GivenAInvalidNameShouldReturnNotifications()
        {
            var patrimony = new Brand("");

            Assert.IsFalse(patrimony.Valid);
        }
    }
}
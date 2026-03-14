using ClassLibrary;
namespace TestProject2
{
    [TestClass]
    public sealed class PhoneTests
    {
        [TestMethod]
        public void Kostruktor_DanePoprawne()
        {
            //Arrange
            string owner = "John Doe";
            string phoneNumber = "123456789";
            Phone phone = new Phone(owner, phoneNumber);

            //Act & Assert
            Assert.AreEqual(owner, phone.Owner);
            Assert.AreEqual(phoneNumber, phone.PhoneNumber);
        }
            [TestMethod]
            public void Kostruktor_DaneNiepoprawne_OwnerPusty()
        {
            //Arrange
            string owner = "";
            string phoneNumber = "123456789";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        [TestMethod]
            public void Kostruktor_DaneNiepoprawne_OwnerNull()
        {
            //Arrange
            string owner = null;
            string phoneNumber = "123456789";

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        [TestMethod]
            public void Kostruktor_DaneNiepoprawne_NumerTelefonuNull()
        {
            //Arrange
            string owner = "Pavlishak";
            string phoneNumber = null;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        [TestMethod]
        [DataRow("123")]
        [DataRow("12345678901233456797")]
            public void Kostruktor_DaneNiepoprawne_NumerTelefonuZlejDlugosci(string nrTel)
        {
            //Arrange
            string owner = "Pavlishak";
            string phoneNumber = nrTel;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
        [TestMethod]
        [DataRow("la123658670")]
        [DataRow("1234567890.")]
            public void Kostruktor_DaneNiepoprawne_NumerTelefonuNieTylkoCyfry(string nrTel)
        {
            //Arrange
            string owner = "Pavlishak";
            string phoneNumber = nrTel;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new Phone(owner, phoneNumber));
        }
    }
}

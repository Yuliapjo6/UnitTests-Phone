using System;
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
        // Testy dodawanie kontaktów
        [TestMethod]
        public void AddContact_NowyKontakt_PowinnoDodacNowyKontakt()
        {
            var phone = new Phone("Pavlishak", "123456789");
            var wynik = phone.AddContact("Adam", "987654321");
            //Assert 
            Assert.IsTrue(wynik);
            Assert.AreEqual(1, phone.Count);
        }
        [TestMethod]
        public void AddContakt_DublikacjaKontaktu()
        {
            var phone = new Phone("Pavlishak", "123456789");

            phone.AddContact("Adam", "987654321");
            var wynik = phone.AddContact("Adam", "1111111111");
            //Assert
            Assert.IsFalse(wynik);
            Assert.AreEqual(1, phone.Count);
        }
        [TestMethod]
        public void AddContakt_TelefonicznaKsiazka_JestZapelniona()
        {
            var phone = new Phone("Pavlishak", "123456789");

            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Kontakt{i}", "111111111");

            }
            //Assert
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Przepełnienie", "222222222"));
        }

        // Testy Call
        [TestMethod]
        public void Call_OsobaIstniejeWKsiazce()
        {
            var phone = new Phone("Pavlishak", "123456789");
            phone.AddContact("Adam", "987654321");

            string wynik = phone.Call("Adam");
            //Assert
            Assert.AreEqual("Calling 987654321 (Adam) ...", wynik);
        }
        [TestMethod]
        public void Call_OsobaNieIstniejeWKsiazce()
        {
            var phone = new Phone("Pavlishak", "123456789");
            //Assert
            Assert.Throws<InvalidOperationException>(() => phone.Call("Nieznany"));
        }
    }
}

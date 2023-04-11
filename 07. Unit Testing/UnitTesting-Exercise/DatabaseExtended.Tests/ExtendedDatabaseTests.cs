namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        Person person;
        Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void ConstructorTakeArguments()
        {
            person = new Person(1, "Kiro");

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Kiro", person.UserName);
        }

        [Test]
        public void AddMethodTestPerson()
        {
            database.Add(new Person(1, "Pesho"));

            Person result = database.FindById(1);

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Pesho", result.UserName);
        }

        [Test]
        public void ShouldThrowMaximumLength()
        {
            Person[] people = CreateFullArray();
            database = new Database(people);

            InvalidOperationException ae = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17, "Pesho"));
            });

            Assert.That(ae.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddShouldThrowIfNotUniqueUsername()
        {
            database.Add(new Person(1, "Pesho"));

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(2, "Pesho"));
            });

            Assert.That(ioe.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddShouldThrowIfNotUniqueId()
        {
            database.Add(new Person(1, "Pesho"));

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1, "Kiro"));
            });

            Assert.That(ioe.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveFromEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveFromDatabase()
        {
            database = new Database(new Person(1, "Kiro"), new Person(2, "Pesho"));

            database.Remove();

            Person person = database.FindById(1);

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("Kiro", person.UserName);
        }

        [Test]
        public void DatabaseFindByUsername()
        {
            database = new Database(new Person(1, "Pesho"));

            Person person = database.FindByUsername("Pesho");

            Assert.AreEqual("Pesho", person.UserName);
        }

        [Test]
        public void FindByUsernameShouldThrowIfUsernameIsNull()
        {
            database = new Database();
            Person person = new Person(1, null);

            ArgumentNullException ane = Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(person.UserName);
            });

            Assert.That(ane.ParamName, Is.EqualTo("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameShouldThrowIfUsernameDoesntExist()
        {
            InvalidOperationException ane = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Gosho");
            });

            Assert.That(ane.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void DatabaseFindById()
        {
            database = new Database(new Person(1, "Pesho"));

            Person person = database.FindById(1);

            Assert.AreEqual(1, person.Id);
        }

        [Test]
        public void FindByIdShouldThrowIfIdIsNegativeNumber()
        {
            ArgumentOutOfRangeException aoore = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });

            Assert.That(aoore.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdShouldThrowIfIdIsUnExisting()
        {
            InvalidOperationException aoore = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(1);
            });

            Assert.That(aoore.Message, Is.EqualTo("No user is present by this ID!"));
        }

        private Person[] CreateFullArray()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            return persons;
        }
    }
}
namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.ComponentModel;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void AddMethodTest()
        {
            database.Add(5);
            int[] result = database.Fetch();

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(1, result.Length);
        }

        [Test]
        public void ShouldThrowIfMoreThanMaximumLength()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            });

            Assert.That(ioe.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void DatabaseRemove()
        {
            database.Add(1);
            database.Add(2);

            database.Remove();

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void DatabaseRemoveWhenIsEmpty_ExpectToThrow()
        {
            InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });

            Assert.That(ioe.Message, Is.EqualTo("The collection is empty!"));
        }

        [Test]
        public void CreateDatabaseWith10Elements()
        {
            database = new Database(1, 2, 3, 4,5,6, 7, 8, 9, 10);

            Assert.AreEqual(10, database.Count);
        }

        [Test]
        public void FetchDataFromDatabase()
        {
            database = new Database(1, 2, 3);
            var result = database.Fetch();

            Assert.That(new int[] { 1, 2, 3 }, Is.EquivalentTo(result));
        }
    }
}
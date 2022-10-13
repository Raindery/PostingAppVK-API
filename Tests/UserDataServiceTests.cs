using NUnit.Framework;
using UserDataService;

namespace Tests
{
    [TestFixture]
    public class UserDataServiceTests
    {
        private IUserDataService? _userDataService;

        [OneTimeSetUp]
        public void SetUpStart()
        {
            var t = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            _userDataService = new UserDataService.UserDataService(t);
            _userDataService.CreateDataFile();
        }

        [SetUp]
        public void Setup()
        {
            if (_userDataService == null)
                throw new ArgumentNullException(nameof(_userDataService));
            
            _userDataService.CreateDataFile();
            _userDataService.AddUserDataString("test1", "test-1");
            _userDataService.AddUserDataString("test2", "test-2");
            _userDataService.SaveUserData();
        }



        [Test]
        public void AddUserDataTest()
        {
            if (_userDataService == null)
                throw new ArgumentNullException(nameof(_userDataService));

            _userDataService.UserData.Clear();
            _userDataService.AddUserDataString(TestValuesName.TEST_1, "test-1");
        }

        [Test]
        public void AddUserDataAndSaveTest()
        {
            if (_userDataService == null)
                throw new ArgumentNullException(nameof(_userDataService));

            _userDataService.UserData.Clear();
            _userDataService.AddUserDataString(TestValuesName.TEST_1, "test-1");
            _userDataService.SaveUserData();
        }

        [Test]
        public void DataFileExsistTest()
        {
            if (_userDataService == null)
            {
                Assert.IsTrue(false);
                return;
            }

            Assert.AreNotEqual(false, _userDataService.DataFileExsist());
        }

        [Test]
        public void GetUserDataFieldTest()
        {
            if (_userDataService == null)
            {
                Assert.IsTrue(false);
                return;
            }

            var value = _userDataService.GetUserDataField("test1");

            Assert.AreEqual("test-1", value);
        }

        [Test]
        public void GetUserDataAfterUpdate()
        {
            if (_userDataService == null)
            {
                Assert.IsTrue(false);
                return;
            }

            _userDataService.UpdateUserData();
            var value = _userDataService.GetUserDataField("test1");

            Assert.IsNotNull(value);
            Assert.IsNotEmpty(value);
            Assert.AreEqual("test-1", value);
        }

        [Test]
        public void GetUserDataAfterAddAndDontSaveTest()
        {
            if (_userDataService == null)
            {
                Assert.IsTrue(false);
                return;
            }

            _userDataService.AddUserDataString("test3", "test-3");
            var value = _userDataService.GetUserDataField("test3");

            Assert.IsFalse(value == null, $"{nameof(value)} is null!");
            Assert.IsNotEmpty(value, $"{nameof(value)} is empty!");
            Assert.AreEqual("test-3", value);
        }

        [Test]
        public void GetUserDataAfterAddAndUpdateDontSaveTest()
        {
            if (_userDataService == null)
            {
                Assert.IsTrue(false);
                return;
            }

            _userDataService.AddUserDataString("test3", "test-3");
            _userDataService.UpdateUserData();

            var value = _userDataService.GetUserDataField("test3");

            Assert.IsNull(value);
        }

        [Test]
        public void GetNewUserDataAfterAddAndUpdateAndSaveTest()
        {
            if (_userDataService == null)
            {
                Assert.IsTrue(false);
                return;
            }

            _userDataService.AddUserDataString("test3", "test-3");
            _userDataService.SaveUserData();

            string? value = _userDataService.GetUserDataField("test3");

            Assert.IsNotNull(value);
            Assert.IsNotEmpty(value);
            Assert.AreEqual("test-3", value);

            _userDataService.UpdateUserData();

            value = _userDataService.GetUserDataField("test3");

            Assert.IsNotNull(value);
            Assert.IsNotEmpty(value);
            Assert.AreEqual("test-3", value);
        }

        [Test]
        public void GetUserDataAfterRewriteTest()
        {
            if (_userDataService == null)
            {
                Assert.IsTrue(false);
                return;
            }

            string? value = _userDataService.GetUserDataField("test1");

            Assert.AreEqual("test-1", value);

            _userDataService.AddUserDataString("test1", "test-rewrite");
            _userDataService.SaveUserData();

            value = _userDataService.GetUserDataField("test1");

            Assert.IsNotNull(value);
            Assert.IsNotEmpty(value);
            Assert.AreEqual("test-rewrite", value);
        }

        [Test]
        public void SaveEmptyUserDataTest()
        {
            if(_userDataService == null)
                throw new ArgumentNullException(nameof(_userDataService));

            _userDataService.UserData.Clear();
            _userDataService.SaveUserData();

            _userDataService.SaveUserData();
        }

        [Test]
        public void UpdateFromEmptyUserDataFileTest()
        {
            if (_userDataService == null)
                throw new ArgumentNullException(nameof(_userDataService));

            _userDataService.UserData.Clear();
            _userDataService.SaveUserData();
            _userDataService.UpdateUserData();
        }


        
        [TearDown]
        public void TearDown()
        {
            if(_userDataService != null)
            {
                _userDataService.UserData.Clear();
                _userDataService.SaveUserData();
            }
        }
    }


    internal static class TestValuesName
    {
        public const string TEST_1 = "test1";
    }
}

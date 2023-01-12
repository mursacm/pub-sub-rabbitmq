using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        [TestCase("test string", "TEST STRING")]
        [TestCase("another Test string #$%", "ANOTHER TEST STRING #$%")]
        [TestCase("TESTing UpperCase STrInG", "TESTING UPPERCASE STRING")]
        public void TestString(string testValue, string expectedValue)
        {
            var p = new Publisher.Publisher();
            var result = p.TransformMessage(testValue);
            Assert.AreEqual(result, expectedValue);
        }
        
        [TestCase(new string[] {"test string", "test2", "test3"}, 3)]
        public void TestPublisher(string[] testValue, int expectedValue)
        {
            var p = new Publisher.Publisher();
            p.SendMessages(testValue, true);
            Assert.AreEqual(expectedValue, p.SuccessCount);
        }
    }
}
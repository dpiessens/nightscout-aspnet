using Nightscout.Utilities;
using Xunit;

namespace Nightscout.Tests.Utilities
{
    public class DateParserExtensionsFixture
    {
        [Fact]
        public void TestParseDateToJs_WhenDateIsJustDate_ReturnValue()
        {
            const string testString = "2015-08-30";
            var convertedDate = testString.ToJavaScriptDate();

            Assert.Equal(1440892800000, convertedDate);
        }

        [Fact]
        public void TestParseDateToJs_WhenDateIsDateAndTime_ReturnValue()
        {
            const string testString = "2015-08-30T12:22:22";
            var convertedDate = testString.ToJavaScriptDate();

            Assert.Equal(1440937342000, convertedDate);
        }
    }
}
using MailSender.lib.Service;
using Xunit;

namespace MailSender.lib.Tests.Service
{
    public class TestEncoderTests
    {    [Fact]
    public void Encode_ABC_to_BCD_with_key_1()
        {
            const string str = "ABC";
            const int key = 1;
            const string excepted_str = "BCD";

            var actual_str = TextEncoder.Encode(str,key);

            Assert.Equal(excepted_str, actual_str);
        }
        [Fact]
    public void Decode_BCD_to_ABC_with_key_1()
        {
            const string str = "BCD";
            const int key = 1;
            const string excepted_str = "ABC";

            var actual_str = TextEncoder.Decode(str, key);

            Assert.Equal(excepted_str, actual_str);
        }
    }
}

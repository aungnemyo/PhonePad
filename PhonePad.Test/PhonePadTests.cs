namespace PhonePad.Test
{
    public class PhonePadTests
    {
        [Fact]
        public void TestEmptyInput()
        {
            Assert.Equal(string.Empty, PhonePad.OldPhonePad(""));
        }

        [Fact]
        public void TestSpacesOnly()
        {
            Assert.Equal(string.Empty, PhonePad.OldPhonePad("     "));
        }

        [Fact]
        public void TestSimpleInput()
        {
            Assert.Equal("E", PhonePad.OldPhonePad("33#"));
        }

        [Fact]
        public void TestWithBackspace()
        {
            Assert.Equal("B", PhonePad.OldPhonePad("227*#"));
        }

        [Fact]
        public void TestMultipleResets()
        {
            Assert.Equal("HELLO", PhonePad.OldPhonePad("4433555 555666#"));
        }

        [Fact]
        public void TestComplexInput()
        {
            Assert.Equal("TURINNG", PhonePad.OldPhonePad("8 88777444666*664#"));
        }
    }
}
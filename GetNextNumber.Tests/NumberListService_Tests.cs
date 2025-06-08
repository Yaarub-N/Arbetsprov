using GetNextNumber.Services;


namespace GetNextNumber.Tests
{
    public class NumberListService_Tests
    {
        private readonly NumberListService _service;

        public NumberListService_Tests()
        {
            _service = new NumberListService();
        }

        [Fact]
        public void GenerateNumberList__Should_ReturnExpected_Values()
        {
            int start = 1;
            int count = 15;

            var result = _service.GenerateNumberList(start, count).ToList();

            Assert.Equal("1", result[0]);
            Assert.Equal("5 FemMultipel", result[4]);
            Assert.Equal("15 TreMultipelFemMultipel", result[14]);
        }

        [Theory]
        [InlineData(3, "3 TreMultipel")]
        [InlineData(5, "5 FemMultipel")]
        [InlineData(15, "15 TreMultipelFemMultipel")]
        [InlineData(7, "7")]
        public void Handles_Multiples_Correctly(int input, string expected)
        {
            var result = _service.GenerateNumberList(input, 1).First();
            Assert.Equal(expected, result);
        }
    }
}

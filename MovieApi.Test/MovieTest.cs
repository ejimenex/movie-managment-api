using Moq;
using MovieApi.BussinesLogic.Abstract;
using MovieApi.Common.Dto;

namespace MovieApi.Test
{
    [TestClass]
    internal class MovieTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod1()
        {
            var dependency = new Mock<IMovieService>();
            var Movie = new MoviePostDto
            {
                Description = "Test",
                Name = "Test",
                Quality = "HD"
            };
            dependency.Setup(m => m.CreateMovie(Movie));
        }
    }
}

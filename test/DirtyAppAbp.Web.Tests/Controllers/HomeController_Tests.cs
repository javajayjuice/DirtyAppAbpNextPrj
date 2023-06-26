using System.Threading.Tasks;
using DirtyAppAbp.Models.TokenAuth;
using DirtyAppAbp.Web.Controllers;
using Shouldly;
using Xunit;

namespace DirtyAppAbp.Web.Tests.Controllers
{
    public class HomeController_Tests: DirtyAppAbpWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
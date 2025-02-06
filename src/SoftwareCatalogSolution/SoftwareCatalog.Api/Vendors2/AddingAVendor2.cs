namespace SoftwareCatalog.Tests.Vendors;
public class AddingAVendor2
{
    [Fact]
    public async Task CanAddAVendor()
    {
        var host = await AlbaHost.For<Program>();
        var requestModel = new VendorCreateModel
        {
            Name = "Jetbrains",
            Link = "https://jetbrains.com"
        };
        var postResponse = await host.Scenario(api =>
        {
            api.Post.Json(requestModel).ToUrl("/vendors2");
            api.StatusCodeShouldBe(201);
        });
        var postBody = postResponse.ReadAsJson<VendorDetailsResponseModel>();
        Assert.NotNull(postBody);
        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url($"/vendors2/{postBody.Id}");
        });
        var getBody = getResponse.ReadAsJson<VendorDetailsResponseModel>();
        Assert.NotNull(getBody);
        var ts = postBody.CreatedOn - getBody.CreatedOn;
        Assert.Equal(postBody, getBody);
    }
}
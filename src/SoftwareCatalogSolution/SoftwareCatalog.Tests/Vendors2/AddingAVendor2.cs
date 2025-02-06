[Fact]
public async Task CanAddAVendor()
{
    var host = await AlbaHost.For<Program>();
    var requestEntity = new VendorCreateModel()
    {
        Name = "Jetbrains",
        Link = "Https://jetbrains.com"
    };
    var postResponse = await host.Scenario(api =>
    {
        api.Post.Json(requestEntity).ToUrl("/vendors");
        api.StatusCodeShouldBe(201);
    });

    var postBody = postResponse.ReadAsJson<VendorDetailsResponseModel>();

    Assert.NotNull(postBody);

    var getResponse = await host.Scenario(api =>
    {
        api.Get.Url($"/vendors/{postBody.Id}");
    });

    var getBody = getResponse.ReadAsJson<VendorDetailsResponseModel>();

    Assert.NotNull(getBody);

    Assert.Equal(postBody, getBody);
}
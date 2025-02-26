namespace SoftwareCatalog.Api.Vendors;

public class VendorEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Link { get; set; } = null;
    public DateTimeOffset CreatedAt { get; set; }
}
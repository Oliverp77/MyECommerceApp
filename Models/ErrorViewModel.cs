namespace MyECommerceApp.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public required string ErrorMessage { get; set; }
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

}

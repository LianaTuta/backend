namespace TicketService.Models.Configuration
{
    public class GoogleBucketConfigurationModel
    {
        public required string BucketName { get; set; }
        public required string CredentialFile { get; set; }
    }
}

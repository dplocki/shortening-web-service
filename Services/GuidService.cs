namespace ShorteningWebService.Services
{
    public class GuidService : IGuidService
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        public bool TryParseGuid(string guidAsString, out Guid id)
        {
            return Guid.TryParse(guidAsString, out id);
        }
    }
}

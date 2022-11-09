namespace BuisnessCentral.Infrastructure.Exceptions
{
    public class BuisnessCentralDomainException : Exception
    {
        public BuisnessCentralDomainException()
        { }

        public BuisnessCentralDomainException(string message)
            : base(message)
        { }

        public BuisnessCentralDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

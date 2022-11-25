namespace MovieApi.Common.Constant
{
    public class FriendlyException : Exception
    {
        public FriendlyException() : base("Error Interno")
        {

        }
        public FriendlyException(string message) : base(message)
        {

        }
        public FriendlyException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

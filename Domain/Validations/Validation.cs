namespace Domain.Validations
{
    public static class Validation
    {
        public static void ValidationString(string value,  string error)
        {
            DomainExceptionValidationsString.When(string.IsNullOrEmpty(value), error);
        }
        public static void ValidationNumberZero(decimal value, string error)
        {
            DomainExceptionValidationsString.When(value == 0, error);
        }

        public static void ValidationMaxLengthString(string value,int length, string error)
        {
            DomainExceptionValidationsString.When(value.Length > length, error);
        }

        public static void ValidationMinLengthString(string value, int length, string error)
        {
            DomainExceptionValidationsString.When(value.Length < length, error);
        }

        public static void ValidationGuid(Guid id, string error)
        {
            DomainExceptionValidationsString.When(id == Guid.Empty, error);
        }
    }
}

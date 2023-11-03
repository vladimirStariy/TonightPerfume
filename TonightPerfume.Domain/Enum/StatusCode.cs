namespace TonightPerfume.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        OK = 200,
        InternalServerError = 500,
        IncorrectPassword = 401,
        IncorrectData = 401,
        UserExists = 901
    }
}

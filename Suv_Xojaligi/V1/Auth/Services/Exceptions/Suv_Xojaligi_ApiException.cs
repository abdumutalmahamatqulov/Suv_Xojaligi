namespace Suv_Xojaligi.V1.Auth.Services.Exceptions;

public class Suv_Xojaligi_ApiException : Exception
{
    public int Code { get; set; }
    public bool? Global { get; set; }
    public Suv_Xojaligi_ApiException(int code, string message, bool? global = true) : base(message)
    {
        Code = code;
        Global = global;
    }

}

namespace itms_v2.Server.Models.ResponseModel
{
    public class ServiceResponse<T>
    {
        public T? Data {get;set;}
        public bool Success {get;set;} = true;
        public string Message {get;set;} = string.Empty;
    }
}
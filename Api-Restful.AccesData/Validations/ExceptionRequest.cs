using System;


namespace Api_Restful.AccesData.Validations
{
    public class ExceptionRequest
    {
        
       
        public string [] Request(Exception e)
        {
            var _error = e.Message;
            var error = _error.Remove(0, 25);
            error = error.Replace("\r\n ", "");
            string[] errorlist = error.Split("-- ");

            return errorlist;
        }
    }
}

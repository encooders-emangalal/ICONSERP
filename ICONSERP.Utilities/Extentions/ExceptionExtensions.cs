namespace ICONSERP.Utilities
{
    public static class ExceptionExtensions
    {
        public static string GetInnerMessage(this Exception ex)
        {
            string message = string.Empty;
            if (ex != null)
            {
                Exception exInner = ex;
                while (exInner.InnerException != null)
                    exInner = exInner.InnerException;

                message = exInner.Message;
            }
            return message;
        }
    }
}

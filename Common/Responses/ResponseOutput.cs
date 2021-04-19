namespace Common.Responses
{
    public class ResponseOutput<T> : BaseResponseOutput
    {
        public T OutputData { get; set; }

        public ResponseOutput()
        {
        }

        public ResponseOutput(T data, NotificationType type, int statusCode, string displayNotice, string debuggerNotice)
        {
            OutputData = data;
            OutputNotification = new ResponseNotification(type, statusCode, displayNotice, debuggerNotice);
        }
    }
}

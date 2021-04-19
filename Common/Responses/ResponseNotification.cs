namespace Common.Responses
{
    public class ResponseNotification
    {
        public NotificationType Type { get; set; }
        public int StatusCode { get; set; }
        public string DisplayNotice { get; set; }
        public string DebuggerNotice { get; set; }

        public ResponseNotification()
        {
        }

        public ResponseNotification(NotificationType type, int statusCode, string displayNotice, string debuggerNotice)
        {
            Type = type;
            StatusCode = statusCode;
            DisplayNotice = displayNotice;
            DebuggerNotice = debuggerNotice;
        }
    }

    public enum NotificationType
    {
        Success,
        Warning,
        Error
    }
}

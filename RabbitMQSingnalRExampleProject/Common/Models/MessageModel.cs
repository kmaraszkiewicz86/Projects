using System;
namespace Common.Models
{
    public class MessageModel
    {
        public string Message { get; set; }

        public MessageModel()
        {

        }

        public MessageModel(string message)
        {
            Message = message;
        }
    }
}

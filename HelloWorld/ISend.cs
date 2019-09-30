using System;

namespace HelloWorld
{
    public interface ISend
    {
        void Send(string message, DateTime dateToSend);
    }
}
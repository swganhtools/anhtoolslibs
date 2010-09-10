using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceClient
{
    public enum ServerType
    {
        None,
        ConnectionServer,
        ChatServer,
        LoginServer,
        ZoneServer,
        PingServer
    }
    public enum MessageType
    {
        Message,
        Cancelled,
        Completed,
        Failed,
        STDErr
    }
}


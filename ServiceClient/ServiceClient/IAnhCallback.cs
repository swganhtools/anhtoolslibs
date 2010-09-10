﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServiceClient
{
    [ServiceContract]
    public interface IAnhCallback
    {
        [OperationContract(IsOneWay = true)]
        void ServerMessage(ServerType ServType, String Args, MessageType MessType, String Message);

        [OperationContract(IsOneWay = true)]
        void ServerStatus(List<IServerStatus> status);

        [OperationContract(IsOneWay = true)]
        void AvailableServers(List<ServerType> servers);
    }
}
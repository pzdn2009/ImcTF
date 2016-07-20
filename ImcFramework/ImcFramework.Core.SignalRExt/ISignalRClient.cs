using ImcFramework.Core.SignalRExt.Client;
using Microsoft.AspNet.SignalR.Client;
using System;

namespace ImcFramework.Core.SignalRExt
{
    public interface ISignalRClient : IDisposable
    {
        string Name { get; }

        AuthenticationType AuthenticationType { get; }

        IHubProxy HubProxy { get; set; }

        void Connect();

        void RegisterServerMethod();
    }
}

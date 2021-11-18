using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.AspNetCore.ServerSentEvents;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    internal abstract class NotificationsServiceBase
    {
        #region Fields

        private INotificationsServerSentEventsService _notificationsServerSentEventsService;

        #endregion Fields

        #region Constructor

        protected NotificationsServiceBase(INotificationsServerSentEventsService notificationsServerSentEventsService)
        {
            _notificationsServerSentEventsService = notificationsServerSentEventsService;
        }

        #endregion Constructor

        #region Methods

        protected Task SendSseEventAsync(string notification, bool alert)
        {
            return _notificationsServerSentEventsService.SendEventAsync(new ServerSentEvent
            {
                Id = Guid.NewGuid().ToString(),
                Type = alert ? "alert" : null,
                Data = new List<string>(notification.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None))
            });
        }

        protected Task SenSseEventToFirstClientAsync(string notification, bool alert)
        {
            var clients = _notificationsServerSentEventsService.GetClients();
            var client = clients.ElementAtOrDefault(new Random().Next(0, 1000) % clients.Count);
            //var client = _notificationsServerSentEventsService.GetClients().FirstOrDefault();
            if (client == null)
            {
                return Task.FromResult(true);
            }

            return client.SendEventAsync(new ServerSentEvent
            {
                Id = Guid.NewGuid().ToString(),
                Type = alert ? "alert" : null,
                Data = new List<string>(notification.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None))
            });
        }

        #endregion Methods
    }
}
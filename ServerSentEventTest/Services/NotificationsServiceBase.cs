using System;
using System.Collections.Generic;
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

        #endregion Methods
    }
}
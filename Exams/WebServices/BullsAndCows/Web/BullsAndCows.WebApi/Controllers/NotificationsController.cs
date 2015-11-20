namespace BullsAndCows.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Contracts;
    using BullsAndCows.WebApi.Models;
    using Microsoft.AspNet.Identity;

    public class NotificationsController : ApiController
    {
        private INotificationService notifications;

        public NotificationsController(INotificationService notificationService)
        {
            this.notifications = notificationService;
        }

        [Authorize]
        public IHttpActionResult Get(int page = 1)
        {
            IList<NotificationResponseModel> notifications = this.notifications
                                                                 .GetNotificationsForUser(this.User.Identity.GetUserId(), page - 1)
                                                                 .ProjectTo<NotificationResponseModel>()
                                                                 .ToList();
            return this.Ok(notifications);
        }

        [Authorize]
        [HttpGet]
        [Route("api/notifications/next")]
        public IHttpActionResult Next()
        {
            Notification notification = this.notifications.GetNextNotificationForUser(this.User.Identity.GetUserId());

            if (notification == null)
            {
                return this.StatusCode(HttpStatusCode.NotModified);
            }

            NotificationResponseModel response = Mapper.Map<NotificationResponseModel>(notification);

            return this.Ok(response);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPatrimony.API.Controllers
{
    public class BaseController: Controller 
    {
        private IReadOnlyCollection<Notification> _notifications;

        public BaseController()
        {
            _notifications = new List<Notification>();
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperationValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            return BadRequest(new
            {
                success = false,
                errors = _notifications.Select(n => n.Message)
            });
        }

        protected void SetNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications = notifications;
        }

        protected bool OperationValid()
        {
            return !_notifications.Any();
        }
    }
}
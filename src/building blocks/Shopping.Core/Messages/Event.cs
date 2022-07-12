using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Messages
{
    public class Event : Message, INotification
    {
    }
}

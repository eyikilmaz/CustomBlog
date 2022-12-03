using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBlog.Common;

public class BlogConstants
{
#if DEBUG
    public const string RabbitMQHost = "localhost";
#else
public const string RabbitMQHost = "c_rabbitmq";
#endif


    public const string DefaultExchangeType = "direct";


    public const string UserExchangeName = "UserExchange";
    public const string UserEmailChangedQueueName = "UserEmailChangedQueue";
   
}

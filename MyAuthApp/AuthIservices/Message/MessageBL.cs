
using AuthIservices.OtherResourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthIservices.Message
{
    public class MessageBL
    {
        public string GetMessage(string messageCode)
        {
            return MessagesEn.ResourceManager.GetString(messageCode);
        }
    }
}

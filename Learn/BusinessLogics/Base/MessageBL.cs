using System;
using System.Collections.Generic;
using System.Text;
using BussinessObject.OtherResources.;
namespace BusinessLogics.Base
{
    public class MessagesEn
    {
        public string GetMessage(string messageCode)
        {
            return MessagesEn.ResourceManager.GetString(messageCode);
        }
    }
}

using Core.OtherResources;
namespace CInfrastructure.Base
{
    public class MessageBL
    {
        public string GetMessage(string messageCode)
        {
            return MessageEn.ResourceManager.GetString(messageCode);
        }       
    }
}

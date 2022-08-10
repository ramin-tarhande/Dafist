namespace Dafist.RabbitAdp.Get
{
    public interface RbReceiveSettings : RbSettings
    {
        bool RabbitMq_AutoDeleteQueue { get; set; }
        string RabbitMq_Topic { get; set; }
    }
}
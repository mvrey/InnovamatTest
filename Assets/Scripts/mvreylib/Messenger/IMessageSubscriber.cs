namespace mvreylib.features.messenger
{
    public interface IMessageSubscriber
    {
        void AddMessageListeners();
        void RemoveMessageListeners();
    }
}
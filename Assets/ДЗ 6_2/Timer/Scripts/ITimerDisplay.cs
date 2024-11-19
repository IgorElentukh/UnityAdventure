namespace Timer
{
    public interface ITimerDisplay
    {
        void Initialize(CountdownTimer timer);
        void OnTimerStarted(float duration);
        void OnTimeUpdated(float remainingTime);
        void OnTimerFinished();
    }
}

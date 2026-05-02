namespace Munchkin.Events
{
    public class OnTurnBegin : IGameEvent
    {
        public required Player Player { get; set; }
    }
}

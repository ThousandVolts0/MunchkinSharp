namespace Munchkin.Events
{
    public class OnTurnEnd : IGameEvent
    {
        public required Player Player { get; set; }
    }
}

namespace Munchkin.Events
{
    public class OnCardPlayed : IGameEvent
    {
        public required Card Card { get; set; }
        public required Player Player { get; set; }
    }
}

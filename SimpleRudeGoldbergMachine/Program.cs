namespace SimpleRudeGoldbergMachine
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var ball = new Ball();
            var bell = new Bell();

            ball.Collision += bell.BellCollided;

            ball.Roll();
        }
    }
}
namespace SimpleRubeGoldbergMachine
{
    public class Program
    {
        private static void Main(string[] args)
        {
        
            var ball = new Ball();
            var dominoToken = new DominoToken();
            var bell = new Bell();

            ball.Collision += dominoToken.Collided;
            dominoToken.Fall += bell.Collided;

            ball.Roll();
        }
    }
}
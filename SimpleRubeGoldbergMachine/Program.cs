namespace SimpleRudeGoldbergMachine
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Setup the elements of the RubeGoldbergMachine
            var ball = new Ball();
            var dominoToken = new DominoToken();
            var bell = new Bell();

            ball.Collision += dominoToken.Collided;
            dominoToken.Fall += bell.Collided;

            //Kick-off
            ball.Roll();
        }
    }
}
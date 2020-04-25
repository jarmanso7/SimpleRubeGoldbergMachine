namespace SimpleRubeGoldbergMachine
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Setup the elements of the RubeGoldbergMachine
            var ball = new Ball();

            var dominoTokens = new[]
            {
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken()
            };

            var bell = new Bell();

            //target the first domino token with the ball
            ball.Collision += dominoTokens[0].Collided;

            //Set the dominoes in a row so that
            //when each token falls, it triggers the fall of the next one.
            for (var i = 0; i < 4; i++)
            {
                dominoTokens[0].Fall += dominoTokens[i + 1].Collided;
            }

            //Set the bell right after the last domino token
            dominoTokens[4].Fall += bell.Collided; 

            //Kick-off
            ball.Roll();
        }
    }
}
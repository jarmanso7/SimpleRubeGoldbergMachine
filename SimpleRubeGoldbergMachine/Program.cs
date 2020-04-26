namespace SimpleRubeGoldbergMachine
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Setup the elements of the RubeGoldbergMachine
            var ball = new Ball();

            var leftRowOfDominoes = new[]
            {
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken()
            };

            var leftBell = new Bell();

            var rightRowOfDominoes = new[]
            {
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken()
            };

            var rightBell = new Bell();

            //target the first domino token of each row with the same ball
            ball.Collision += leftRowOfDominoes[0].Collided;
            ball.Collision += rightRowOfDominoes[0].Collided;

            //Set the dominoes of each row so that
            //when each token falls, it triggers the fall of the next one.
            for (var i = 0; i < 4; i++)
            {
                leftRowOfDominoes[i].Fall += leftRowOfDominoes[i + 1].Collided;
                rightRowOfDominoes[i].Fall += rightRowOfDominoes[i + 1].Collided;
            }

            //Set the bell right after the last domino token of the left row
            leftRowOfDominoes[4].Fall += leftBell.Collided;

            //Set the bell right after the last domino token of the right row
            rightRowOfDominoes[4].Fall += rightBell.Collided;

            //Kick-off
            ball.Roll();
        }
    }
}
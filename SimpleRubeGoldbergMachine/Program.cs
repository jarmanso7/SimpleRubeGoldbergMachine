using System;
using System.Threading;

namespace SimpleRubeGoldbergMachine
{
    public class Finger { }

    public class DominoToken
    {
        public event EventHandler Fall;

        public void KickOff()
        {
            //Collides with your finger and kicks off the chain reaction
            this.Collided(new Finger(), EventArgs.Empty);
        }

        public void Collided(object sender, EventArgs e)
        {
            var thread = new Thread(() =>
            {
                var objectType = sender.GetType().Name;
                Console.WriteLine($"A {objectType} has bumped into the domino token.");
                Console.WriteLine("The token falls!");

                Thread.Sleep(1000);

                //On falling, the domino token collides with the next token
                this.OnFalling(EventArgs.Empty);
            });

            thread.IsBackground = false;
            thread.Start();
        }
        
        private void OnFalling(EventArgs e)
        {
            Fall?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var rowOfDominoes = new[]
            {
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken(),
                new DominoToken()
            };

            //Attach the Collided delegate of each domino Token to the Fall event of the previous Token
            for (var i = 0; i < 4; i++)
            {
                rowOfDominoes[i].Fall += rowOfDominoes[i + 1].Collided;
            }

            //Kick-off
            rowOfDominoes[0].KickOff();
        }
    }
}
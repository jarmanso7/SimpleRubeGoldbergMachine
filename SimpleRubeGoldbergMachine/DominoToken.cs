using System;
using System.Threading;

namespace SimpleRubeGoldbergMachine
{
    public class DominoToken
    {
        public event EventHandler Fall;

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
            Fall?.Invoke(this, e);
        }
    }
}
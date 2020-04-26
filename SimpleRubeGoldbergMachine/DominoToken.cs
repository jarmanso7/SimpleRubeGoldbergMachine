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
                Console.WriteLine("Current Thread: " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                Console.WriteLine("The token falls!");
                //On falling the domino token collides with the next object
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
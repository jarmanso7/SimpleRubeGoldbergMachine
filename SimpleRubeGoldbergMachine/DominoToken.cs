using System;

namespace SimpleRudeGoldbergMachine
{
    public class DominoToken
    {
        public event EventHandler Fall;

        public void Collided(object sender, EventArgs e)
        {
            var objectType = sender.GetType().Name;
            Console.WriteLine($"A {objectType} has bumped into the domino token.");
            Console.WriteLine("The token falls!");

            //On falling the domino token collides with the next object
            OnFalling(EventArgs.Empty);
        }
        private void OnFalling(EventArgs e)
        {
            Fall?.Invoke(this, e);
        }
    }
}
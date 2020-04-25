using System;

namespace SimpleRudeGoldbergMachine
{
    public class Ball
    {
        public event EventHandler Collision;

        /// <summary>
        ///     Rolls the ball
        /// </summary>
        public void Roll()
        {
            Console.WriteLine("You rolled the ball so it started to move...");
            OnCollision(EventArgs.Empty);
        }

        private void OnCollision(EventArgs e)
        {
            Collision?.Invoke(this, e);
        }
    }
}
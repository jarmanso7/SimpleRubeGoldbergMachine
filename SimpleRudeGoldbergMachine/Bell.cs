using System;

namespace SimpleRudeGoldbergMachine
{
    public class Bell
    {
        public void BellCollided(object sender, EventArgs e)
        {
            var typeOfObject = sender.GetType().Name;
            Console.WriteLine($"A {typeOfObject} has collided with the bell.");
            Console.WriteLine("Ring!");
        }
    }
}
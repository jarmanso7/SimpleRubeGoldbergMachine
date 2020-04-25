using System;

namespace SimpleRudeGoldbergMachine
{
    public class Bell
    {
        public void Collided(object sender, EventArgs e)
        {
            var typeOfObject = sender.GetType().Name;
            Console.WriteLine($"A {typeOfObject} has collided with the bell.");
            Console.WriteLine("Ring!");
        }
    }
}
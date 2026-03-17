using System; 
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Random rand = new Random();
        int hoopHeight = rand.Next(8, 13); 
        int distance = rand.Next(10, 21);
        Console.WriteLine("Welcome to the Bespin Basketball Game!");

        Console.WriteLine($"The hoop is {hoopHeight} feet high and {distance} feet away.");
    while (true)
    {
        {

            Console.Write("On a scale of 1-10 how much power do you want to shoot the ball with?: ");
            double power = Convert.ToDouble(Console.ReadLine());

            Console.Write("Great! Now from 0 degrees to 90 degrees, at what angle do you want to shoot the ball with?: ");
            double angle = Convert.ToDouble(Console.ReadLine());

                if (power + angle >= 44 && power + angle <= 62)
            {
                Console.WriteLine("Nice shot you made it!");
                break;
            }
                else
            {
                    Console.WriteLine("You missed! Try again!");
            }
            
        }
    }
}
}


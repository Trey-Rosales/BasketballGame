using System; 
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Random rand = new Random();
        int hoopHeight = rand.Next(8, 13); 
        int distance = rand.Next(10, 21);

        double x = distance;
        double y = hoopHeight;

        double zTarget = x + 2 * (y - 6);

        Console.WriteLine("\n\nWelcome to the Bespin Basketball Game!\n");

        Console.WriteLine($"\nThe hoop is {hoopHeight} feet high and {distance} feet away. You are 6ft tall.\n");
    while (true)
    {
        {

            Console.Write("On a scale of 1-10 how much power do you want to shoot the ball with?: ");
            double power = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nGreat! Now from 0 degrees to 90 degrees, at what angle do you want to shoot the ball with?: ");
            double angle = Convert.ToDouble(Console.ReadLine());

            double shot = power * angle;

                if (shot >= zTarget - 5 && shot <= zTarget + 5)
            {
                Console.Write("\nNice shot you made it! Do you want to play again? (yes or no): ");
                string feedback = Console.ReadLine();

                if (feedback.ToLower() == "no")
                    {
                        break;
                    }

                else if (feedback.ToLower() == "yes")
                    {
                        Console.WriteLine($"\n\nThe hoop is {hoopHeight} feet high and {distance} feet away. You are 6ft tall.");
                        continue;
                    }
            }
                else if (shot < zTarget - 5)
            {
                Console.WriteLine("You airballed! Try Again.");
            }
                else if (shot > zTarget + 5 )
            {
                Console.WriteLine("You overshot! Try Again.");
            }
            
        }
    }
}
}


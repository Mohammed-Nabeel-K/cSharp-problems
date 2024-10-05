using System;

public class Prime
{

    bool flag = true;
    Console.WriteLine("Enter a number to check whether it is prime or not");
    int num = Convert.ToInt32(Console.ReadLine());
    for (int i = 2; i < num - 1; i++)
    {
        if (num % i == 0)
        {
            flag = false;
            break;
        }
    }
    if (flag == true)
    {
        Console.WriteLine("It is  a Prime");
    }
    else
    {
        Console.WriteLine("It is not a Prime");
    }
    
}

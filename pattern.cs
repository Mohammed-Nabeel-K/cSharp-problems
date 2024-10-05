using System;

public class Class1
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            string str = "";
            for (int j = 5; j > i; j--)
            {
                str += " ";
            }
            for (int k = 0; k < i; k++)
            {
                string+= "*";
            }
            Console.WriteLine(string);
        }
    }
	
}

using System;

public delegate void Func(string str);

public class MyClass
{
    public void Space(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            Console.Write(str[i]);
            if (i < str.Length - 1)
            {
                Console.Write("_");
            }
        }
        Console.WriteLine();
    }

    public void Reverse(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine(new string(charArray));
    }
}

public class Run
{
    private MyClass _myClass = new MyClass();

    public void runFunc(Func func, string str)
    {
        func.Invoke(str);
    }

    public Func GetFuncs()
    {
        Func funcDell = new Func(_myClass.Space);
        funcDell += _myClass.Reverse;
        return funcDell;
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter str:");
        var str = Console.ReadLine();

        Run run = new Run();
        Func funcDell = run.GetFuncs();
        run.runFunc(funcDell, str);
    }
}
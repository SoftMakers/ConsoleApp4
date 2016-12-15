using System;
class MethodsParametrs
{
    // модификатори параметров 
    public int ChParam(ref int i, out int j)
    {
        i = i + 11;
        j = i;
        return i;
    }
    // параметри метода по значению не изменяют аргументов
    public void NoChange (int i, int j)
    {
        i *= 2;
        j /= 2;
    }
    // возврат болеe одного значения из методов модификатором параметра out
    public void OutExample (int e, int f, out int r, out int g)
    {
        e = 765;
        f = 987;
        r = e;
        g = f;
    }
    // возврат болеe одного значения из методов модификатором параметра ref
    public void RefExample(ref int y, ref int j)
    {
        y = 765;
        j = 987;
    }
}
// использование модификаторов параметров для ссылочных типов данных
class ChangeLink
{
    int a, b;
    public ChangeLink(int i, int j)
    {
        a = i;
        b = j;
    }
    public void Show()
    {
        Console.WriteLine("a:{0}, b:{1}", a, b);
    }
    public void Change (ref ChangeLink obj1, ref ChangeLink obj2)
    {
        ChangeLink container = obj1;
        obj1 = obj2;
        obj2 = container;
    }
}
// переменное число паракметров. Модификатор PARAMS
class Min
{
    public int MinVal (params int[] nums)
    {
        int m;
        if (nums.Length==0)
        {
            Console.WriteLine("no arguments!");
            return 0;
        }
        m = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < m) m = nums[i];
        }
        return m;
    }
}
//возврат обьектов из методов
class Rect
{
    public int z, x;
    public Rect (int z, int x)
    {
        this.z = z;
        this.x = x;
    }
    public Rect Scale(int scalar)
    {
        return new Rect(this.z * scalar, this.x * scalar);
    }
}
// полиморфизм, перегрузка конструкторов, перегрузка this, инициализатори обектов
class Poli
{
    public int x,y;
    public Poli()
    {
        x = 1;
        y = 1;
    }
    public Poli(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Poli(int x) : this(x, x) { } 

}

class ConsoleApp
{
    public static void Main()
    {
        MethodsParametrs obj1 = new MethodsParametrs();
        int c = new int();
        int b = new int();
        // модификатори параметров
        int a =100;
        Console.WriteLine("Обьект до визова метода содержит аргументи: {0}, {1}, {2}", a, b, c);
        c = obj1.ChParam(ref a,out b);
        Console.WriteLine("После вызова метода обьект содержит аргументи: {0}, {1}, {2}", a, b, c);
        // параметри метода по значению не изменяют аргументов
        obj1.NoChange(c, b);
        Console.WriteLine("Переменние с,b значимого типа обьявлени с помощью конструктора класа");
        Console.WriteLine("переданние методу в качестве параметров по значению содержат {0} и {1}", c, b);
        // возврат болеe одного значения из методов модификатором параметра out
        int t = new int();
        int h = new int();
        obj1.OutExample(t, h, out t, out h);
        Console.WriteLine("Возврат 2-х значений из метода посредством модификатора out: {0}, {1}", t, h);
        // возврат болеe одного значения из методов модификатором параметра ref
        int u = new int();
        int k = new int();
        obj1.RefExample(ref u, ref k);
        Console.WriteLine("Возврат 2-х значений из метода посредством модификатора ref: {0}, {1}", u, k);
        // использование модификаторов параметров для ссылочных типов данных
        ChangeLink x = new ChangeLink(1, 2);
        ChangeLink y = new ChangeLink(3, 4);
        Console.Write("x до вызова : "); x.Show();
        Console.Write("y до вызова : "); y.Show();
        x.Change(ref x, ref y);
        Console.Write("x после вызова : "); x.Show();
        Console.Write("y после вызова : "); y.Show();
        y.Change(ref y, ref x);
        Console.Write("x после повторного вызова : "); x.Show();
        Console.Write("y после повторного вызова : "); y.Show();
        // переменное число параметров
        Min ob = new Min();
        int min;
        int o = 10, l = 15, p = 20;        
        min = ob.MinVal(p);
        Console.WriteLine("Минимальное {0}", min);
        //возврат обьектов из методов
        Rect prm1 = new Rect(4, 5);
        prm1 = prm1.Scale(50);
        Rect prm2 = new Rect(1, 2);
        Console.WriteLine("prm1.z:{0}, prm1.x:{1}, prm2.z:{2}, prm2.x:{3}", prm1.z, prm1.x ,prm2.z, prm2.x);
        // полиморфизм, перегрузка конструкторов, перегрузка this, инициализатори обектов
        Poli morf1 = new Poli();
        Poli morf2 = new Poli(5);
        Poli morf3 = new Poli(10,10);
        Poli morf4 = new Poli {x=15,y=15};
        Poli morf5 = new Poli {x=20};
        Console.WriteLine("Перегрузка конструкторов:");
        Console.WriteLine("Параметри при инициализации:()            morf1.x: {0}, morf1.y: {1}", morf1.x, morf1.y);
        Console.WriteLine("Параметри при инициализации:(5)           morf2.x: {0}, morf2.y: {1}", morf2.x, morf2.y);
        Console.WriteLine("Параметри при инициализации:(10,10)       morf3.x: {0}, morf3.y: {1}", morf3.x, morf3.y);
        Console.WriteLine("Параметри при инициализации:{x=15,y=15}   morf4.x: {0}, morf4.y: {1}", morf4.x, morf4.y);
        Console.WriteLine("Параметри при инициализации:{x=20}        morf5.x: {0}, morf5.y: {1}", morf5.x, morf5.y);

        Console.Read();
    }
}
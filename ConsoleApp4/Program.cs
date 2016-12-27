using System;
using System.Media;

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
    int a;
    int b;

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
// переменное число параметров. Модификатор PARAMS
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
    public int z;
    public int x;

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
    public int x;
    public int y;

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
// необязательные и именование параметры
class Pamametrs
{
    public static int Sum (int x, int y=0, int z=0)
    {
        return x+y+z;
    }
}
// рекурсия
class Recursion 
{
    public static void Recursor (string i)
    {
        if(i.Length > 0) Recursor(i.Substring(1,i.Length-1)); 
        else return; 
        Console.Write(i[0]);
    }
    public static int Fact (int j)
    {
        int result=0;
        if (j==0) return result;
        else if (j==1) result=1;
        else result = j * Fact(j-1);
        Console.Write("\t"+j);
        return result;        
    }       
}
// перегрузка операторов
class ThreeD 
{
    public int a,b,c;
    public ThreeD () : this (0,0,0) {}    
    public ThreeD (int a, int b, int c) 
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public static ThreeD operator + (ThreeD obj1,ThreeD obj2)
    {
        ThreeD result = new ThreeD();
        result.a = obj1.a + obj2.a;
        result.b = obj1.b + obj2.b;
        result.c = obj1.c + obj2.c;
        return result;
    }

    //public static ThreeD operator + (ThreeD obj1,ThreeD obj2) {
    //return new ThreeD( obj1.a + obj2.a, obj1.b + obj2.b, obj1.c + obj2.c ); }        
    

    public static explicit operator ThreeD (int i)
    {
        ThreeD result = new ThreeD(i,i,i);
        return result;
    }

    //public static implicit operator ThreeD (int i) {
    //return new ThreeD(i,i,i); }
}
// cтатический класс
static class Static
{
    private static int a;
    public static void Show ()
    {
        Console.WriteLine(a);
    }
    public static void Set (int i)
    {
        a = i;
    }         
}
// Свойства класса
class EskdCode 
{
    // конструктор
    public EskdCode (string specifikator, int clasifikator, int number, int version=-1)
    {
        this.Specifikator = specifikator;
        this.Clasifikator = clasifikator;
        this.Number = number;
        this.Version = version;
    }
    // поля
    private int code_type; // if 1 then version not null
    private string specifikator;
    private int clasifikator;
    private int number;
    private int version;    
    // свойства
    public string Specifikator 

    {
        get
        {
            return specifikator;
        }
        set
        {
            if (value=="АЖИЮ" || value=="ГАРК" || value=="ПЦЮИ") specifikator = value;
        }
    } 
    public int Clasifikator 
    {
        get
        {
            return clasifikator;
        }
        set
        {
            if (value>0 & value <1000000) clasifikator = value;
        }
    }
    public int Number 
    {
        get
        {
            return number;
        }
        set
        {
            if (value>0 & value <1000) number = value;
        }
    }
    public int Version 
    {
        get
        {
            return version;
        }
        set
        {
            if (value>0 & value <1000) version = value;
            else version = -1;
        }
    }
    // методы
     public static EskdCode operator + (EskdCode obj1, EskdCode obj2)
        {   
            EskdCode result = new EskdCode("",0,0);
            result.specifikator = obj1.specifikator + obj2.specifikator;
            result.clasifikator = obj1.clasifikator + obj2.clasifikator;
            result.number = obj1.number + obj2.number;
            if (obj1.Version == -1 & obj2.Version == -1)    result.version = -1;
            else if (obj1.Version == -1) result.version = obj2.Version;
            else if (obj2.Version == -1) result.version = obj1.Version;
            else result.version = obj1.Version + obj2.Version;
            return result;
        }
    public string GetFullCode()
    {
        string result="";
        result = Specifikator + ".";
        result += Clasifikator + ".";
        result += Number;
        if (Version != -1) result += "." + Version;
        return result;
    }

}
// Наследование, модификатор доступа protected
class BaseClass                          
{                                       
    protected int a { get; set; }       
    protected int b { get; set; }       
    public BaseClass() : this(0,0) {}   
    public BaseClass(int a=0, int b=0)  
    {                                   // если в базовом класе обявлен явный
        this.a = a;                     // конструктор (кроме конструкторов с 
        this.b = b;                     // параметрами по умолчанию) и отсутствует 
    }                                   // перегрузка неявного конструктора (без 
}                                       // параметров) в производном класе необходимо 
class DotherClass : BaseClass           // обьявить явний конструктор для инициализации 
{                                       // параметров конструктора базового класса с           
    private int c { get; set; }         // перегрузкой наследуемого конструктора базового класа                           
    public DotherClass() : this(0,0,0) {}                       
    public DotherClass(int a=0, int b=0, int c=0) : base (a,b)   
    {                                                            
        this.c = c;                                                        
    }                                                           
    public void Show()
    {
        Console.WriteLine("\ta:{0}\tb:{1},\tc:{2}",a,b,c);
    }
}                                                           

class ConsoleApp
{
    public static int Main ()//out string result)
    {
        MethodsParametrs obj1 = new MethodsParametrs();
        int c = new int();
        int b = new int();
        
        Console.Title="Шилдт Г. Руководство C#.";        
        Console.SetWindowSize(Console.LargestWindowWidth-30,Console.LargestWindowHeight-15);
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        
        if (Console.CapsLock) return 1;//"TurnOff CAPSLOCK!";                 

        // Модификатори параметров        
        Console.WriteLine("\nМодификатори параметров\n");
        int a =100;
        Console.WriteLine("\tОбьект до визова метода содержит аргументи: {0}, {1}, {2}", a, b, c);
        c = obj1.ChParam(ref a,out b);
        Console.WriteLine("\tПосле вызова метода обьект содержит аргументи: {0}, {1}, {2}", a, b, c);
        
        // Параметри метода по значению не изменяют аргументов        
        Console.WriteLine("\nПараметри метода по значению не изменяют аргументов\n");
        obj1.NoChange(c, b);
        Console.WriteLine("\tПеременние с,b значимого типа обьявлени с помощью конструктора класа");
        Console.WriteLine("\tпереданние методу в качестве параметров по значению содержат {0} и {1}", c, b);
        
        // Возврат болеe одного значения из методов модификатором параметра out        
        Console.WriteLine("\nВозврат болеe одного значения из методов модификатором параметра out\n");
        int t = new int();
        int h = new int();
        obj1.OutExample(t, h, out t, out h);
        Console.WriteLine("\tВозврат 2-х значений из метода посредством модификатора out: {0}, {1}", t, h);
        
        // Возврат болеe одного значения из методов модификатором параметра ref        
        Console.WriteLine("\nВозврат болеe одного значения из методов модификатором параметра ref\n");
        int u = new int();
        int k = new int();
        obj1.RefExample(ref u, ref k);
        Console.WriteLine("\tВозврат 2-х значений из метода посредством модификатора ref: {0}, {1}", u, k);
        
        // Использование модификаторов параметров для ссылочных типов данных        
        Console.WriteLine("\nИспользование модификаторов параметров для ссылочных типов данных\n");
        ChangeLink x = new ChangeLink(1, 2);
        ChangeLink y = new ChangeLink(3, 4);
        Console.Write("\tx до вызова : "); x.Show();
        Console.Write("\ty до вызова : "); y.Show();
        x.Change(ref x, ref y);
        Console.Write("\tx после вызова : "); x.Show();
        Console.Write("\ty после вызова : "); y.Show();
        y.Change(ref y, ref x);
        Console.Write("\tx после повторного вызова : "); x.Show();
        Console.Write("\ty после повторного вызова : "); y.Show();
        
        // Переменное число параметров        
        Console.WriteLine("\nПеременное число параметров\n");
        Min ob = new Min();
        int min;
        int o = 10, l = 15, p = 20;        
        min = ob.MinVal(p);
        Console.WriteLine("\tМинимальное {0}", min);
               
        // Возврат обьектов из методов        
        Console.WriteLine("\nВозврат обьектов из методов\n");
        Rect prm1 = new Rect(4, 5);
        prm1 = prm1.Scale(50);
        Rect prm2 = new Rect(1, 2);
        Console.WriteLine("\tprm1.z:{0}, prm1.x:{1}, prm2.z:{2}, prm2.x:{3}", prm1.z, prm1.x ,prm2.z, prm2.x);
        
        // Полиморфизм, перегрузка конструкторов, перегрузка this, инициализатори обектов
        Console.WriteLine("\nПолиморфизм, перегрузка конструкторов, перегрузка this, инициализатори обектов\n");
        Poli morf1 = new Poli();
        Poli morf2 = new Poli(5);
        Poli morf3 = new Poli(10,10);
        Poli morf4 = new Poli {x=15,y=15};
        Poli morf5 = new Poli {x=20};
        Console.WriteLine("\tПерегрузка конструкторов:");
        Console.WriteLine("\tПараметри при инициализации:()            morf1.x: {0}, morf1.y: {1}", morf1.x, morf1.y);
        Console.WriteLine("\tПараметри при инициализации:(5)           morf2.x: {0}, morf2.y: {1}", morf2.x, morf2.y);
        Console.WriteLine("\tПараметри при инициализации:(10,10)       morf3.x: {0}, morf3.y: {1}", morf3.x, morf3.y);
        Console.WriteLine(@"\tПараметри при инициализации:(x=15,y=15)   morf4.x: {0}, morf4.y: {1}", morf4.x, morf4.y);
        Console.WriteLine(@"\tПараметри при инициализации:(x=20)        morf5.x: {0}, morf5.y: {1}", morf5.x, morf5.y);
       
        // Необязательные и именование параметры
        Console.WriteLine("\nНеобязательные и именование параметры\n");
        Console.WriteLine("\tSum(10): " + Pamametrs.Sum(10));
        Console.WriteLine("\tSum(10,11,12): " + Pamametrs.Sum(10,11,12));
        Console.WriteLine("\tSum(10,13): " + Pamametrs.Sum(10,13));
        Console.WriteLine("\tSum(14,z:15): " + Pamametrs.Sum(14,z:15));
        Console.WriteLine("\tSum(x:16,z:17): " + Pamametrs.Sum(x:16,z:17));

        // Рекурсия
        Console.WriteLine("\nРекурсия\n");
        string str="This is test!";
        Console.WriteLine("\tЭто исходная строка: "+str);
        Console.Write("\tЭто строка после рекурсии: ");   
        Recursion.Recursor(str);
        Console.WriteLine("\n\nРекурсия\n");
        Console.WriteLine("\t"+Recursion.Fact(9));        

        // Перегрузка операторов
         Console.WriteLine("\n Перегрузка операторов\n");
        ThreeD tobj1 = new ThreeD(1,2,3);
        ThreeD tobj2 = new ThreeD(10,10,10);
        int i=5;
        tobj2 += tobj1;        
        Console.WriteLine("\tОбьект tobj2 после выражения tobj2 += tobj1 : {0}, {1}, {2}", tobj2.a, tobj2.b, tobj2.c);
        tobj1 = (ThreeD)i;
        Console.WriteLine("\tОбьект tobj1 после выражения tobj1 = (int)i : {0}, {1}, {2}", tobj1.a, tobj1.b, tobj1.c);

        // Перегрузка операторов v.2
        Console.WriteLine("\nПерегрузка операторов v.2\n");
        EskdCode robj1 = new EskdCode("АЖИЮ",111111,111);
        EskdCode robj2 = new EskdCode("ГАРК",222222,222,2);
        Console.WriteLine("\t" + robj1.GetFullCode());
        Console.WriteLine("\t" + robj2.GetFullCode());
        robj1 = robj1 + robj2;
        Console.WriteLine("\t" + robj1.GetFullCode());

        // Cтатический класс
        Console.WriteLine("\n Cтатический класс\n");
        Console.Write("\t");
        Static.Set(25);
        Static.Show();

        // Наследование, модификатор доступа protected
        Console.WriteLine("\n Наследование, модификатор доступа protected\n");
        BaseClass a1 = new BaseClass(5,25);        
        DotherClass b1 = new DotherClass(83,34,67);
        b1.Show();
        
        System.Media.SoundPlayer bep;
        bep = new SoundPlayer("C:\\Windows\\Media\\Windows Proximity Notification.wav");
        bep.Play();          

        Console.Read();
        return 0;//"Ok!";
    }
}
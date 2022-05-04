// Use either shortcut for Refactor (control + T - Mac Intellij) or Right click > Refactor This

using System.Drawing;

namespace Refactorings_and_Quick_Fixes;

public class Refactorings

{
    // Change signature without updating the calls
    // Place caret to Foo > Change signature. Place caret near Foo
    public string Foo(string s, int x)
    {
        return String.Format("'{0}': {1} times", s, x);
    }
    public void Test()
    {
        Foo("test", 10);
    }

}

// Convert Abstract Class to Interface refactoring
//  Caret on the CachedItem > Convert Abstract Class to an Interface

public abstract class CachedItem
{
    public abstract int Id { get; set; }
    public abstract void Register();
    public abstract void UnRegister();
}

// Convert Anonymous to Named Type refactoring
// TODO: it should work before the new {book.Title}, but somehow it is not 


class MyTest
{
    void Test(List<Book> books)
    {
        var bookList = from book in books
            select new {book.Author, title = new {book.Title}};
    }
}
class MyNewTest
{
    void Foo(List<Book> library)
    {
        var bookCatalog = from item in library select new
            {item.Author, item.Title};
    }
}
 
// Convert Extension Method to Plain Static refactoring
// TODO: should work with the DoSomething

public static void DoSomething(this string s)
{
}
private static void Test(string str)
{
    str.DoSomething();
}

// Convert Indexer to Method refactoring
// Caret on the this[int index] > Convert Indexer to Method 

class BookLibrary
{
    private Book[] books = new Book[1000];
    public Book this[int index]
    {
        get => books[index];
        set => books[index] = value;
    }
    public void TestInsertBookAt(Book book, int index)
    {
        this[index] = book;
    }
}

// Convert Interface to Abstract Class refactoring
// Set caret near the Shape > Convert Interface to Abstract Class

interface Shape
{
    double Area { get; }
    void Draw();
}
class Circle : Shape
{
    private readonly int radius;
    public double Area => Math.PI * Math.Pow(radius, 2);
    public void Draw()
    {
    }
}

// Convert Method to Indexer refactoring
// Set caret near GetBookAt or Insert > Convert Method to Indexer

class TestBookLibrary
{
    Book[] _books;
    Book GetBookAt(int index)
    {
        return _books[index];
    }
    void Insert(int index, Book book)
    {
        _books[index] = book;
    }
    void Copy(int copy, int to)
    {
        Insert(to, GetBookAt(copy));
    }
}

// Convert Method to Property refactoring
// Set caret near GetFaculty or SetFaculty > Convert Method to Property

class Student
{
    private string _faculty;
    public string GetFaculty()
    {
        return _faculty;
    }
    public void SetFaculty(string f)
    {
        _faculty = f;
    }
}

// Convert Property to Auto-Property refactoring
//Set caret to BackgroundColor > Convert Property to Auto-Property

class Shape
{
    private Color bgColor;
    public Color BackgroundColor
    {
        get { return bgColor; }
        set { bgColor = value; }
    }
    public Shape(Color background)
    {
        bgColor = background;
    }
}

// Convert Property to Method(s) refactoring
// Set caret to Faculty > Convert Property to Method(s)
class Student
{
    public string Faculty { set; get; }
}

// Convert Static to Extension Method refactoring
// Set caret to Reverse > Convert Static to Extension
static class Foo
{
    public static string Reverse(string input)
    {
        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
    static void Test(string str)
    {
        str = Reverse(str);
    }
}

// Copy Type refactoring
// set caret near Car > Copy Type

class Car 
{
    string color = "red";

    static void Main(string[] args)
    {
        Car myObj = new Car();
        Console.WriteLine(myObj.color);
    }
}

// Encapsulate Field refactoring
// TODO: not solved

private  string myString;
public void DoSomething(string input)
{
    myString = input;
}

internal class EncapsulateField
{
    public double Side
}

class Program
{
    static void Example(string[] args)
    {
        EncapsulateField ef = new EncapsulateField();
        ef.Side = 1.45;
    }
}

private  string myString;
public void DoSomething(string input)
{
    myString = input;
}


//Extract Class refactoring
// Set caret to LogError > Extract Class

class Shape
{
    public void Draw()
    {
        try { /*draw*/ }
        catch (Exception e) { LogError(e); }
    }
    public static void LogError(Exception e)
    {
        File.WriteAllText(@"c:\Errors\Exception.txt", e.ToString());
    }
}

// Extract Interface refactoring
// Set caret to any of the method or property > Extract Interface

class Circle
{
    public Point Center { get; private set; }
    public Color Color { get; private set; }
    public int Radius { get; private set; }
    public void Draw()
    {
        // draw...
    }
}

// Extract Method refactoring
// highlight Method required - several lines below > Extract Method

static void PrintReversed(string input)
{
    var chars = input.ToCharArray();
    Array.Reverse(chars);
    var reversed =  new string(chars);
    Console.WriteLine(reversed);
}

// Extract Superclass refactoring
// Set caret to the class name (Circle) > Extract Superclass

public class Circle : IDrawable
{
    public Point Center { get; private set; }
    public Color MyColor { get; private set; }
    public int Radius { get; private set; }
    public void Draw()
    {
        // draw...
    }
}
public interface IDrawable
{
    void Draw();
}


// Inline Class refactoring
// Set caret to the myPainter = new Painter(c); > Inline Class

class Painter
{
    private Color myColor;
    public Painter(Color c)
    {
        myColor = c;
        InitPainter(myColor);
    }
    private void InitPainter(Color color)
    {
        //init painter
    }
}
class Circle
{
    private Painter myPainter;
    public Circle(Color c)
    {
        myPainter = new Painter(c);
    }
}

// Inline Field refactoring
// set caret to the ErrorMessage declaration > Inline field

class Shape
{
    private const string ErrorMessage = "Something has failed";
    public void Draw(string s)
    {
        try { /*draw*/ }
        catch (Exception e)
        {
            Console.WriteLine("{0} : {1}", ErrorMessage, e);
        }
    }
}

// Inline Method refactoring
// Place caret to LogError > Inline Method

abstract class Shape
{
    public void Draw()
    {
        try { /*draw*/ }
        catch (Exception e)
        {
            LogError(e);
        }
    }
    private static void LogError(Exception e)
    {
        File.WriteAllText(@"c:\Errors\Exception.txt", e.ToString());
    }
}

// Inline Parameter refactoring
// Set caret after double, next to pi > Inline Parameter

private double AreaOfCircle(double rad, double pi)
{
    return pi*rad*rad;
}
public void Test()
{
    var area = AreaOfCircle(10, Math.PI);
}

// Inline Variable refactoring
// Place caret to (chars) > Inline Variable

static string ReversedString(string input)
{
    var chars = input.ToCharArray();
    Array.Reverse(chars);
    var reversed = new string(chars);
    return reversed;
}

// Introduce Field refactoring
// Place caret after File.WriteAllText( > Introduce Field

class ErrorHandler
{
    public static void LogError(Exception e)
    {
        File.WriteAllText(@"c:\Error.txt", "Something has failed" + e);
    }
    public static void PrintError(Exception e)
    {
        Console.WriteLine("{0} : {1}", "Something has failed", e);
    }
}

// Introduce Parameter refactoring
// place caret near LogError > Introduce Parameter

abstract class Shape
{
    public void Draw()
    {
        try { /*draw*/ }
        catch (Exception e)
        {
            LogError(e);
        }
    }
    static void LogError(Exception ex)
    {
        Console.WriteLine("Something has failed...");
        File.WriteAllText(@"c:\Error.txt", "Something has failed..." + ex);
    }
}

// Introduce Variable refactoring
// Place caret to "Something has failed" > Introduce Variable

static void LogError(Exception ex)
{
    Console.WriteLine("Something has failed...");
    File.WriteAllText(@"c:\Error.txt", "Something has failed..." + ex);
}

// Introduce Variable for Substring refactoring
// Highlight the word answer > Introduce Variable for Substring

public string GetMessage()
{
    return "Please enter your answer";
}

// Invert Boolean refactoring
// Place caret to IsEven > Invert Boolean

public bool IsEven(int input)
{
    return input % 2 == 0;
}
public void Test(int value)
{
    if (IsEven(value))
        Console.WriteLine("\n the number is even");
}

// Make Method Non-Static refactoring
// TODO: it should work: Place caret before Merge > Make Method Non-Static

class Info
{
    string Id { get; set; }
    string Name { get; set; }
    static Info Merge(Info i1, Info i2)
    {
        return new Info
        {
            Id = i1.Id + i2.Id,
            Name = i1.Name + i2.Name
        };
    }
    void Test()
    {
        var i1 = new Info()
            { Id = "123", Name = "AA" };
        var i2 = new Info()
            { Id = "456", Name = "BB" };
        var merged =
            Info.Merge(i1, i2);
    }
}

// Make Method/Property Static refactoring
// Place caret to Merge method of Info class > Make Static

class Info
{
    string Id { get; set; }
    string Name { get; set; }
    Info Merge(Info other)
    {
        return new Info
        {
            Id = Id + other.Id,
            Name = Name + other.Name
        };
    }
    
// Extract Members to Partial Refactoring
// Set caret to Test method > Extract Members to Partial

    void Test()
    {
        var i1 = new Info()
            { Id = "123", Name = "AA" };
        var i2 = new Info()
            { Id = "456", Name = "BB" };
        var merged = i1.Merge(i2);
    }
}

// Move Instance Method refactoring
// Set caret to the LogDrawing instance method > Move Instance Method

class Shape
{
    private Point pivot;
    private void LogDrawing(Logger logger)
    {
        var msg = $"Shape is drawn at {pivot.X}, {pivot.Y}";
        logger.Log(msg);
    }
}

// Move Type to Another File refactoring
// Set caret to Logger > Move to Another File

class Logger
{
    public void Log(string msg)
    {
        // log the message
    }
}

// Move Type to Another Namespace refactoring
// Set caret to Tests > Move to Another Namespace

public class Tests
{
    public void TestMethod1()
    {
    }
}

// Move Type to Outer Scope refactoring
// Set caret to the Nested > Move to Outer Scope

public class Container
{
    class Nested
    {
        Nested() { }
    }
}

// Move to Another Type refactoring
// Set caret to the Nested2 > Move to Another Type

public class Container2
{
    class Nested2
    {
        Nested2() { }
    }
}

// Move to Folder refactoring
// Set caret to Container3 > Move to Folder

public class Container3
{
    class Nested3
    {
        Nested3() { }
    }
}

// Pull Members Up refactoring, Push Members Down refactoring
// Set caret to Foo > Pull Members Up
// To Push Members Down set caret to the Foo or IMyInterface > Push Members Down

interface IMyInterface
{
}
class MyDerivedClass : IMyInterface
{
    public void Foo()
    {
        Console.WriteLine("Hello");
    }
}

// Rename refactoring
//Safe Delete refactoring
// Set caret to any of the existing below entities: Car or Engine, displayCar, displayEngine, ExampleClass > Rename or Safe Delete

public class ExampleClass {

    public void displayCar() {
        string Car = "Oka"
        Console.WriteLine($"Car: {Car}");
    }
 
    public class Engine {
        public void displayEngine()
        {
            string Engine = "Petrol Engine";
            Console.WriteLine($"{Car}, Engine: {Engine}");
        }
    }
}

// Replace Constructor with Factory Method refactoring
// Set caret to class Foo >  Replace Constructor with Factory Method

class Foo
{
    public Foo()
    {
        // instance initialization
    }
}

// Transform Parameters refactoring
// Set caret to the DrawCircle > Transform Parameters

class TestClass
{
    public void DrawCircle(Point ctr, float rad, out bool res)
    {
        // draw...
        res = true;
    }
}

// Use Base Type Where Possible refactoring
// TODO: The refactoring itself appearing when caret is placed at class name, but it does not seem to do anything here. It is required to tweak it a bit.

class Example
{
    static void TypeExample()
    {
        Type t = typeof(String);

        MethodInfo substr = t.GetMethod("Substring", 
            new Type[] { typeof(int), typeof(int) });

        Object result = 
            substr.Invoke("Hello, World!", new Object[] { 7, 5 });
        Console.WriteLine("{0} returned \"{1}\".", substr, result);
    }
    static void TypeExample : ToBase
    {
        new ToBase() = typeof(bool);
        

    }
}


using System;

namespace Inheritance {

    // base class
    class Animal { 

        public string name;

        public void display() {
            Console.WriteLine("I am an animal");
        }
    
    } 
  
    // derived class of Animal 
    class Dog : Animal {
    
        public void getName() {
            Console.WriteLine("My name is " + name);
        }
    }

    class Program {

        static void Main(string[] args) {

            // object of derived class
            Dog labrador = new Dog();

            // access field and method of base class
            labrador.name = "Rohu";
            labrador.display();

            // access method from own class
            labrador.getName();

            Console.ReadLine();
        }

    }
}
internal class ToBase
{
}



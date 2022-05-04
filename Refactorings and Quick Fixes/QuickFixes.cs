//TODO rename quickfixes back to program.cs fxd
//Put QuickFixes to another class and call it from the program.cs (needed?) 
// TODO дописать куда что ставить и как делается квикфикс

using System.Net;

namespace QuickFixes
{
    class Fixes
    {
        static void Main(string[] args)
        {
            // Type mismatch
            object o = "123";
            //click on string
            string s = o;

            //Undefined variable
            a = "123";

            //Undefined method call
            return GetQuickFix(1, 2);
        }
        

        //Missing Using directives 
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
            
            //Forgotten method return
            private string GetFix()
            {
            }

            // Missing async modifier
            private void Test1(string[] site)
            {
                site = await new WebClient().DownloadStringTaskAsync("https://i.imgflip.com/3ibl7m.gif");
                
                
                // Converting a loop to a LINQ expression -
                //TODO https://www.jetbrains.com/help/rider/Code_Analysis__Examples_of_Quick-Fixes.html#loop_to_LINQ
                IEnumerable<string> Linq()
                {
                    List<string> greetings = new List<string>()
                        {"hey", "hi", "..."};
                    foreach(string greet in greetings)
                    {
                        if (greet.Length < 3)
                        {
                            yield return greet;
                        }
                        yield break;
                    }
                }
            }
            
            //Migrating to IEnumerable in method parameters and returns
            //set caret to int[]

            private static void SimInt(int[] vector)
            {
                vector[0] = lowerData;
                vector[1] = upperData;
            }

        }
    }

    class test1
    {
        void test123()
        {
            //Converting assignment statements to object initializers 
            //set caret to new
            AssignmentStatemtents c = new AssignmentStatemtents();
            c.name = "this object";
            c.id = 00001;
        }
    }

    internal class AssignmentStatemtents
    {
        public string name;
        public int id;
    }

    // Converting static method invocation to extension method call -
    class Test3
    {
        public string SendToLog;
        
        // TODO get sorted
        private void ConvertingStaticMethodInvocationToExtensionMethodCall()
        {
            Test3 cTest3 = new Test3();
            string b = "some text";
            cTest3.SendToLog( b );
        }
    }

    //Converting anonymous method to lambda expression

        Func<int, int> func = delegate(int x) { return x + 2;};
        
        // Converting to auto-property
        private int t;
        public int t
        {
            get { return t; } 
            set { value = t; }
        }
        
        // Making type parameter invariant
        public interface Example<in TContext>
        {
            TContext GetContext()
        }

        internal class FileSystemChangeDelta
    {
    }
}
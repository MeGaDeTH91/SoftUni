namespace DeprecatedClass
{
    public class StartUp
    {
        public static void Main()
        {
            var summator = new Summator();
            var privateObject = new PrivateObject(summator);
            var result = privateObject.Invoke("GetSum", 12, 13);

            System.Console.WriteLine(result);
        }
    }
}
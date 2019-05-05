using System;

namespace ResharperFinallyBug
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoTest();
            }
            catch
            {
                //ignoring
            }
        }

        static void DoTest()
        {
            var success = true;
            try
            {
                throw new Exception();
            }
            catch
            {
                success = false;
                throw;
            }
            finally
            {
                Console.WriteLine($"Success: {success}");
                Console.ReadKey();
            }
        }

    }
}

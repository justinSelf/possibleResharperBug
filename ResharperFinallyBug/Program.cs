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
                //ReSharper is telling me that success is not used and implying it is safe to delete.
                //however, if I delete it, then there is a bug in the finally block.
                success = false;
                throw;
            }
            finally
            {
                //This will print false
                Console.WriteLine($"Success: {success}");
                Console.ReadKey();
            }
        }

    }
}

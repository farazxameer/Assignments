using System;

namespace Static
{
    public class Static
    {
        private static bool isConnected = false;

        ///<summary>
        ///This method will change the connected state to true.
        ///</summary>
        public static void Connect()
        {
            isConnected = true;
        }

        ///<summary>
        ///This method will Display the stuatus of connection either true or false.
        ///</summary>
        public static void Status()
        {
            Console.WriteLine(isConnected);
        }
    }
}
using System;

/*
Copyrite (c) 2018
AUTHOR: Lina Chung
FILENAME: tester.cs
VERSION: 1.1

DESCRIPTION:    File to test all basic functionality by creating a heterogeneous iSlogan array and 
                heterogeneous iConverter array. Randomly creates child objects of the two types and 
                passes into the paramaters random values.
*/


namespace projectsix
{
    public class p6
    {
        public static void Main()
        {
            Random rnd = new Random();
            const int n = 10;
            iSlogan[] iS = iS_arr(n,rnd);
            test_iS(n, iS);
            IconVerter[] iC = iconV_arr(n, rnd);
            test_iC(n, iC);
        }

        public static string getString(Random rnd)
        {
            string [] strArr = {"Hi my name is Lina",
                                "I am a student at Seattle University",
                                "I am from Hawaii", 
                                "I speak Japanese", 
                                "I like to read", 
                                "I like whales", 
                                "I like food", 
                                "How are you?",
                                "It is cold today",
                                "I love chocolate"};

            return strArr[rnd.Next(0,10)];
        }

        public static iSlogan[] iS_arr(int n, Random rnd)
        {
            const int x = 2;
            const int y = 3;
            const int z = 4;

            iSlogan[] arr = new iSlogan[n];
            uint pVal = (uint)rnd.Next(1,9);
            uint cVal = (uint)rnd.Next(1,9);

            for(int i = 0; i < n; i++)
            {
                if(i % x == 0)
                {
                    arr[i] = new repconVert(pVal, getString(rnd),cVal);
                }
                else if(i % y == 0)
                {
                    arr[i] = new garbledconVert(pVal, getString(rnd));
                }
                else if(i % z == 0)
                {
                    arr[i] = new iSloganConVert(pVal, getString(rnd));
                }
                else
                    arr[i] = new iSlogan(pVal, getString(rnd)); 
            }
            return arr;
        }

        public static IconVerter[] iconV_arr(int n, Random rnd)
        {
            const int x = 2;
            const int y = 3;
            const int z = 4;

            IconVerter[] array = new IconVerter[n];
            uint pVal = (uint)rnd.Next(1,9);
            //uint cVal = (uint)rnd.Next(1,9);

            for(int i = 0; i < n; i++)
            {
                if(i % x == 0)
                {
                    array[i] = new garbledconVert(pVal, getString(rnd));
                }
                else if(i % y == 0)
                {
                    array[i] = new iSloganConVert(pVal, getString(rnd));
                }
                else if(i % z == 0)
                {
                    array[i] = new repconVert(pVal, getString(rnd));
                }
                else
                {
                    array[i] = new conVerter(getString(rnd));
                }
            }
            return array;
        }

        public static void test_iS(int n, iSlogan[] s)
        {
            Console.WriteLine("\nTesting heterogenous collection for iSlogan");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Message: {0}", s[i].query((uint)i));
            }
        }

        public static void test_iC(int n, IconVerter[] v)
        {
            Console.WriteLine("\nTesting heterogeneous collection for conVert/iSloganConVert...");
            for(int i = 0; i < n; i++)
            {
                printArr(v[i].convertMessage((uint)i+1));
            }
        }

        public static void printArr(int[] arr)
        {
            Console.WriteLine("Array: ");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                Console.Write(", ");
            }
            Console.WriteLine();
        }

    }
}


using System;
using System.Text;

/*
Copyrite (c) 2018
AUTHOR: Lina Chung
FILENAME: conVerter.cs
VERSION: 1.1

DESCRIPTION:    conVerter class takes in a string as a parameter, converts its' first r vaules into 
                its' ASCII number equivalence and returns it to the user as an array. The string 
                message passed in cannot be changed once set in the constructor, but when converted,
                all punctuation will be removed. 

ASSUMPTIONS:    string msg is a value with at least 10 characters, and once set, cannot be changed. 
                The string itself is not altered. r value that is passed into convertMessage must be 
                a postivie int value less than 10. There is no notion of state. Dynamic memory is used
                in convertMessage and ownership is transferred to the user, making user responsible
                for deallocating the memory. 

CLASS INVARIANTS:   conVerter can take in 0 or 1 parameters, the only parameter passed in is a string 
                    value those char length is at least 10. If no parameters are passed in, there is a
                    default message set. convertMessage checks to make sure the pos int r value is 
                    less than the string size with punctuation removed. If r value is greater than the
                    string length, r is changed to the string length % r. 

INTERFACE INVARIANTS:   When converting a message, the value passed in must be a postivie int value 
                        less than 10. convertMessage creates a dynamically allocated array within the
                        function and transfers the ownership to the user. It is the user's 
                        responsibility for proper deallocation of array. The array passed back is an 
                        array of integers corresponding to the first r-value characters of the string.

IMPLEMENTATION INVARIANTS:  convertMessage() is a virtual function and can be overridden in any child 
                            classes. removePun() cannot be overridden since derrived conVerter classes
                            can choose to suppress functionality of removePun() or use it for convertMessage(). 
*/

namespace projectsix
{
    public class conVerter: IconVerter
    {
        private string msg;

    /*
        Description:    converter has a default and 1 param ctor, that takes in a string value.
                        if no parameter is passed in, the string message is preset.

        Post:           msg data member set to the passed in parameter.
    */
    
        public conVerter(string userMsg = "A default message")
        {
            msg = userMsg;
        }

    /*
        Description:    convertMessage takes in an uint r value greater than 9, 
                        will take the first r characters in message and returns/
                        creates an integer array of each characters' corresponding ASCII value.
                        integer array is not a data member, is created within the function and
                        transfers ownership of the integer array to user. 

        Post:           integer array is returned.  
    */

        public int[] convertMessage(uint r)
        {
            int x;
            int[] numArr = new int[r];
            string m = removePun(msg);

            if(r > m.Length)
            {
                r = (uint)m.Length%r;
            }

            for(int i=0; i<r; i++)
            {
                x = m[i];
                numArr[i] = x;
            }

            return numArr;
        }

    /*
        Description:    removePun takes in a string m, removes the punctuation and returns it
                        if the string is solely punctuation, it will return an empty string.

        Pre:            string m has a char length greater than 9
        Post:           returns same string message but with punctuation removed.
    */

        private string removePun(string m)
        {
        var stringB = new StringBuilder();
        for(int i = 0; i < m.Length; i++)
        { 
            if (!char.IsPunctuation(m[i])) 
            { 
                stringB.Append(m[i]); 
            } 
        }
        return stringB.ToString();
        }
    }
}
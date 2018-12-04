using System;

/*
Copyrite (c) 2018
AUTHOR: Lina Chung
FILENAME: iSloganConVert.cs
VERSION: 1.1

DESCRIPTION:    iSloganConVert is an object that is both a iSlogan and a Converter object. Class
                supports functionality of iSlogan and Converter, and can substitute in as an iSlogan
                object or a conVerter object. iSloganConVerter inherits unsigned int p, count, and bool
                on from iSlogan class, and inherits all member functions from iSlogan.
                It also inherits all member functions from the conVerter class. 
                It passes its' message onto its' two parents for the subsiquent classes to use.

ASSUMPTIONS:    It is assumed that iSloganConVerter is initalized to an ON state (on == true),
                once set, the message is not changed. It is also assumed that q is a single digit
                integer value where 0 < q < 10 and userpassed in int p is a pos int greater than 0,
                and that the set message is >= 10 characters. r value must be a postivie int value less 
                than 10. Dynamic memory is used in convertMessage and ownership is 
                transferred to the user, making user responsible for deallocating the memory.

CLASS INVARIANTS:   iSloganconVerter can take in 0, 1 or 2 parameters. The first parameter
                    must be an positive int value greater than 0, the second parameter must be a string
                    exceeding 10 characters (including spaces). If no parameters are passed in, there 
                    are set values for each parameter. If an incorrect q value is queried, than the 
                    standard "Off" message is returned. convertMessage checks to make sure the pos int 
                    r value is less than the string size with punctuation removed. If r value is greater 
                    than the string length, r is changed to the string length % r. 

INTERFACE INVARIANTS:   When quering, the value passed in must also be a positive integer value between 
                        0 and 9. On/Off states will toggle every pth request. When converting a message,
                        the value passed in must be a postivie int vaue less than 10. convertMessage 
                        creates a dynamically allocated array within the function and transfers the 
                        ownership to the user. The array passed back is an array of integers
                        corresponding to the first r-value characters of the string. 

IMPLEMENTATION INVARIANTS:  OnMessage(), OffMessage() and isOn() are virtual functions, any
                            child classes can change what their On, and Off messages are, and can also 
                            change the restrictions on their On/Off state for added extensionability. 
                            Query(int q) cannot be overriden since all iSlogan type objects must have 
                            the same functionality for query. convertMessage() is a virtual function 
                            and can be overridden in any child classes. removePun() cannot be overridden 
                            since derrived conVerter classes can choose to suppress functionality of 
                            removePun() or use it for convertMessage().
*/

namespace projectsix
{
    public class iSloganConVert : iSlogan, IconVerter
    {   
        private conVerter convert;

    /*
        Description:    iSloganConVert takes in 0, 1 or 2 params. 
                        The first parameter is an uint val corresponding to iSlogan's p value.
                        The second parameter is string message whose length is at least 10 characters. 
                        iSloganConVert calls its' parents' constructors and passes in the corresponding
                        data members. 

        Post:           iSlogan and conVerter ctors are called and utilized
    */

        public iSloganConVert(uint input = 1, string m = "A default message") : base(input, m)
        {
            convert = new conVerter(onMessage(input));
        }  

        public int[] convertMessage(uint r)
        {
            return convert.convertMessage(r);
        }  
    }
}
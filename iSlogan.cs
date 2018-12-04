using System;

/*
Copyrite (c) 2018
AUTHOR: Lina Chung
FILENAME: iSlogan.h
VERSION: 1.2

DESCRIPTION:    The iSlogan class has three encapsulated members, a user set string message
                that does not change and is inhereited by its' children, a random or user set 
                value int p, and a private bool on which represents the object's state. If "On", 
                iSlogan will output its' message otherwise it will not output anything, however, 
                no matter what state iSlogan is, if p is the same value as a user queried int q, 
                it will not output any message. iSlogan's state is toggled on/off every pth request. 

ASSUMPTIONS:    It is assumed that iSlogan is initalized to an ON state (on == true),
                once set, the message is not changed. It is also assumed that q is a single digit
                integer value where 0 < q < 10 and userpassed in int p is a pos int greater than 0,
                and that the set message is >= 10 characters.
  
CLASS INVARIANTS:   iSlogan can take in 0, 1 or 2 parameters. The first parameter
                    must be an positive int value greater than 0, the second parameter must be a 
                    string exceeding 10 characters (including spaces). If no parameters are passed 
                    in, there are set values for each parameter. If an incorrect q value is queried,
                    than the standard "Off" message is returned. 

INTERFACE INVARIANTS:   When quering, the value passed in must also be a positive
                        integer value between 0 and 9. On/Off states will toggle every pth request. 

IMPLEMENTATION INVARIANTS:  OnMessage(), OffMessage() and isOn() are virtual functions, any
                            child classes can change what their On, and Off messages are, and can also
                            change the restrictions on their On/Off state for added extensionability.
                            Query(int q) cannot be overriden since all iSlogan type objects must have
                            the same functionality for query.
*/

namespace projectsix
{
    public class iSlogan
    {
        protected string message;
        protected uint p;
        protected bool on;
        protected uint count;

    /*  
        Description:  iSlogan constructor has 0, 1, or 2 arguments. If no parameters are passed in, 
                      a default p value and message is set. If 1 parameter is passed in, only 
                      default message is used. count will be set to 0, and on will be set to true.

        Post:         message is set to passed in/default string value, p is set to some pos int value,
                      count is set to 0, and on == true.
    */

        public iSlogan(uint userInput = 1, string userMes = "A default message")
        {
            message = userMes;
            p = userInput;
            on = true;
            count = 0;
        }

    /*
        Description:    query takes in an int val q, and tests to see if object is on or off.
                        if object is on, then query checks validity of q, if q is valid, then
                        the "on" message is returned. If q is not valid, then the "off" message is
                        returned. Off message is also returned if the object is off. 

        Pre:            q is an uint value where q < 10
    */

        public string query(uint q)
        {
            if(isOn()){
                if(q < 10){
                    return onMessage(q);
                }
                return offMessage();
            }
            return offMessage();
        }

    /*
        Description:    onMessage takes in an uint q variable, if q != p, then function returns the 
                        message, otherwise an empty string is returned.

        Pre:            q is an uint value.
    */

        protected virtual string onMessage(uint q)
        {
            if(q == p)
            {
                return "";
            }
            return message;
        }

    /*
        Description:    offMessage takes in no arguments, and when called, returns an empty string.
    */

        protected virtual string offMessage()
        {
            return "";
        }

    /*
        Description:    isOn() takes in no arguments, if data member count is a multiple of p
                        then it's "on" state is toggeled. Otherwise, the state is left as is.
                        Returns true or false based on if the object is on or off.

        Pre:            p is a pos uint value
        Post:           count is incremented by one, on may be toggled to true or false
   */

        protected virtual bool isOn()
        {
            count++;
            if(count % p == 0)
            {
                on = !on;
            }
            return on;
        }
    }
}
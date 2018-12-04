using System;
/*
Copyrite (c) 2018
AUTHOR: Lina Chung
FILENAME: repconVert.cs
VERSION: 1.1

DESCRIPTION: repconVerter is the child of both repS and conVerter class. Since repS
		is the child class of iSlogan, but only uses its' parents values, and with an additional
		unsigned int cap value set by user. repS overrides both iSlogan's isOn() function and 
		onMessage(int q) function. When off, object acts like an iSlogan object, but has an internal capacity.
    	Like iSlogan, repS's state is toggled on/off every pth request however, once its' capacity
    	has been reached, state is set to off and cannot be turned back on, repS also behaves like an 
		iSlogan when it is off, and will not output any message if off. When on, repS takes the message
		and repeats pth character q times at the qth character. repconVerter has conVerter class functionality 
		and converts its' first r vaules into its' ASCII number equivalence and returns it to the user as
		an array. The string message passed in cannot be changed once set in the constructor, but when 
		converted, all punctuation will be removed. 

ASSUMPTIONS: It is assumed that object is initalized to an ON state (on == true),
    	once set, the message is not changed. It is also assumed that q is a single digit
    	integer value where 0 < q < 10 and userpassed in int p is a pos int greater than 0
    	and that the set message is >= 10 characters.  int cap must be a pos int value greater than
    	0. r value that is passed into convertMessage must be a postivie int value less than
        10. There is no notion of state. Dynamic memory is used in convertMessage and ownership is 
        transferred to the user, making user responsible for deallocating the memory. 

CLASS INVARIANTS: repS constructor takes 0, 1, 2, or 3 parameters. It inherits its' parents p value,
    	and message but has its' own data member on, and count as well as a new data member, cap which
    	denotes how often the object can be turned on or off. After the cap has been reached, object
    	is permanently set to off and cannot be changed. User can also set their own message, different
    	from the parent, but once the message is set, it cannot be changed. convertMessage checks to make
		sure the pos int r value is less than the string size with punctuation removed. If r value is 
		greater than the string length, r is changed to the string length % r. 

INTERFACE INVARIANTS: When quering, the value passed in must also be a positive integer value between
		0 and 9. On/Off states will toggle every pth request. When converting a message, the value 
		passed in must be a postivie int vaue less than 10. convertMessage creates a dynamically 
		allocated array within the function and transfers the ownership to the user. It is the 
		user's responsibility for proper deallocation of array. The array passed back is an array
		of integers corresponding to the first r-value characters of the repeated string. 

IMPLEMENTATION INVARIANTS: convertMessage(unsigned int r) is the only overriden function, however
		repS does override its' parent' onMessage(unsigned int q) method, and isOn() method. isOn() is
    	overridden so object can track how many times it has been toggled on/off, and compares it with 
    	its' data member cap. When object is on, its' overriden onMessage(int q) is called which selects 
    	the qth position of the message, and repeats the pth character in the message, q times.
    	When object is off, object calls parent class' offMessage, and it will return an empty string. 
		convertMessage acts like the conVerter's convertMessage except it calls repS's onMessage() to
		recieve the repeated message, and converts that.

*/

namespace projectsix
{
	public class repconVert: repS, IconVerter
	{
		private conVerter convert;

    	/*
        Description:    repconVert takes in 0, 1, 2 or 3 params. The first parameter is an uint val
                        corresponding to rep's p value. The second parameter is string message whose 
                        length is at least 10 characters. The third parameter is an uint val 
                        corresponding to repS's capacity value. repconVert calls its' parents' 
                        constructors and passes in the corresponding data members. 

						Whatever you set the message to, the converted message will always be the same

        Post:           repS and conVerter ctors are called and utilized
  		*/

		public repconVert(uint p, string m = "A default string", uint c = 2): base(p,m,c)
		{
			convert = new conVerter(onMessage(p));
		}

		/*
		Description:	convertMessage takes in an uint r value greater than 9, 
				   		calls repS's onMessage() and  will take the first r characters in 
				   		repeated message and returns/creates an integer array of each characters'
				   		corresponding ASCII value. integer array is not a data member, is created 
				   		within the function and transfers ownership of the integer array to user.

        Post: 			dynamically allocated integer array is returned.  
    	*/

		public int[] convertMessage(uint r)
        {
            return convert.convertMessage(r);
        }  
	}
}
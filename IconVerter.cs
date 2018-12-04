using System;

/*
Copyrite (c) 2018
AUTHOR: Lina Chung
FILENAME: IconVerter.cs
VERSION: 1.0

DESCRIPTION:    A interface file for conVerter for garbledconVert, iSloganConVert, and repconVert to use.
                Creates an int array of function convertMessage
*/

namespace projectsix
{
    public interface IconVerter
    {
       int[] convertMessage(uint r);
    }
}
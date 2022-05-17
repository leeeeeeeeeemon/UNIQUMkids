// See https://aka.ms/new-console-template for more 
using System.Collections.ObjectModel;

using UNIQUMkidsCore;

List<Parent> parents = new List<Parent>();
parents = GetDataFromDB.GetParent();
foreach(Parent parent in parents)
{
    Console.WriteLine(parent.Name);
}


Console.WriteLine("Hello, World!");

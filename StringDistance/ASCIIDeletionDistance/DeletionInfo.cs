using System;

namespace StringDistances
{
    public class DeletionInfo
    {
        public DeletionInfoStringName StringName;
        public Char Letter;
        public int Index;

        public DeletionInfo(DeletionInfoStringName stringName, Char letter, int index)
        {
            this.StringName = stringName;
            this.Letter = letter;
            this.Index = index;
        }
        public override string ToString()
        {
            return $"in {this.StringName} at {this.Index} char '{this.Letter}'";
        }
        public int GetAsciiValue()
        {
            return (int)this.Letter;
        }
    }
}

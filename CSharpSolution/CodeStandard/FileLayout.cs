using System;

namespace CodeStandard
{
    // Public Delegates
    // Public Enums
    // Static Fields and Constants
    // Fields
    //     Sort By Readonly
    //     Then By Access
    //     Then By Name
    // Constructors
    // Properties, Indexers
    // Interface Implementations
    // All other members
    // Nested Types

    internal class FileLayout
    {
        public readonly int EField = 2;

        protected readonly int fField = 3;

        private readonly int dField = 1;

        public int BField;

        public int HField;

        protected int cField;

        protected int iField;

        private int aField;

        private int gField;

        public void Method()
        {
            aField = BField + cField;
            gField = HField + iField;
            Console.WriteLine(aField + gField + dField + EField + fField);
        }

        #region Raw

        //private int gField;

        //public int HField;

        //protected int iField;

        //private int aField;

        //public int BField;

        //protected int cField;

        //private readonly int dField = 1;

        //public readonly int EField = 2;

        //protected readonly int fField = 3;

        #endregion
    }
}

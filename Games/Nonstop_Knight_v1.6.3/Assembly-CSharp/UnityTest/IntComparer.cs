﻿namespace UnityTest
{
    using System;

    public class IntComparer : ComparerBaseGeneric<int>
    {
        public CompareType compareType;

        protected override bool Compare(int a, int b)
        {
            switch (this.compareType)
            {
                case CompareType.Equal:
                    return (a == b);

                case CompareType.NotEqual:
                    return (a != b);

                case CompareType.Greater:
                    return (a > b);

                case CompareType.GreaterOrEqual:
                    return (a >= b);

                case CompareType.Less:
                    return (a < b);

                case CompareType.LessOrEqual:
                    return (a <= b);
            }
            throw new Exception();
        }

        public enum CompareType
        {
            Equal,
            NotEqual,
            Greater,
            GreaterOrEqual,
            Less,
            LessOrEqual
        }
    }
}


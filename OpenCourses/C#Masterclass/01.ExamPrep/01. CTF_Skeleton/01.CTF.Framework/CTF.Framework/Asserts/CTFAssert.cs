namespace CTF.Framework.Asserts
{
    using CTF.Framework.Exceptions;
    using System;

    // ReSharper disable once InconsistentNaming
    public abstract class CTFAssert
    {
        public static void AreEqual(object a, object b)
        {
            var typeA = a.GetType();
            var typeB = b.GetType();

            if (typeA != typeB)
            {
                throw new TestException();
            }

            if (typeA.IsValueType && typeB.IsValueType)
            {
                if (!a.Equals(b))
                {
                    throw new TestException();
                }
            } 
            else
            {
                if (a != b)
                {
                    throw new TestException();
                }
            }
        }

        public static void AreNotEqual(object a, object b)
        {
            var typeA = a.GetType();
            var typeB = b.GetType();

            if (typeA != typeB)
            {
                throw new TestException();
            }

            if (typeA.IsValueType && typeB.IsValueType)
            {
                if (a.Equals(b))
                {
                    throw new TestException();
                }
            }
            else
            {
                if (a == b)
                {
                    throw new TestException();
                }
            }
        }

        public static void Throws<T>(Func<bool> condition) where T: Exception
        {
            try
            {
                condition.Invoke();
            }
            catch (T)
            {
                return;
            }
            catch(Exception)
            {
                throw new TestException();
            }
        }
    }
}

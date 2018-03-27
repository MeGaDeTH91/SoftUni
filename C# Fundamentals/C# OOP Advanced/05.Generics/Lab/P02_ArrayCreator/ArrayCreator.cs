public static class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        T[] createdArray = new T[length];

        for (int index = 0; index < length; index++)
        {
            createdArray[index] = item;
        }

        return createdArray;
    }
}

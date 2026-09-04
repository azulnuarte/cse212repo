public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
{
    // 1. Create an array with a size equal to the given length.
    // 2. Use a for loop to go through each position of the array.
    // 3. Calculate each multiple by multiplying the number by the current position plus 1.
    // 4. Store each multiple in the corresponding position of the array.
    // 5. Return the completed array.

    double[] mNum = new double[length];

    for (int i = 0; i < length; i++)
    {
        mNum[i] = number * (i + 1);
    }

    return mNum;
}

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
   {
        
// 1. Get the last 'amount' elements from the list and store them in a separate list.
// 2. Remove those elements from the original list.
// 3. Insert the stored elements at the beginning of the original list.
        List<int> lastNumbers = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, lastNumbers);

    }
}

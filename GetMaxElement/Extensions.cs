namespace DelegatesHomework.GetMaxElement
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            ArgumentNullException.ThrowIfNull(collection);
            ArgumentNullException.ThrowIfNull(convertToNumber);

            float maxValue = float.MinValue;
            T maxElement = default;

            foreach (T element in collection)
            {
                float value = convertToNumber(element);
                if (value > maxValue)
                {
                    maxValue = value;
                    maxElement = element;
                }
            }

            return maxElement;
        }
    }
}

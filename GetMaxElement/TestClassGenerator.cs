namespace DelegatesHomework.GetMaxElement
{
    public static class TestClassGenerator
    {
        public static IEnumerable<TestClass> GenerateTestCollection()
        {
            var testCollection = new List<TestClass>();

            for (int i = 0; i < 10; i++)
            {
                var name = $"name {i}";
                var description = string.Join("", Enumerable.Repeat("test", i));

                var testClass = new TestClass(i, name, description);
                testCollection.Add(testClass);
            }

            return testCollection;
        }
    }
}

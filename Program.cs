using DelegatesHomework.FileEvents;
using DelegatesHomework.GetMaxElement;


// Поиск максимального элемента в коллекции
var testCollection = TestClassGenerator.GenerateTestCollection();

static float convertToNumber(TestClass testClass)
{
    return testClass.Description.Length;
};

var maxFromCollection = testCollection.GetMax(convertToNumber);

Console.WriteLine("Max Element (element with the longest Description) was found in collection of TestClasses");
Console.WriteLine($"Description={maxFromCollection.Description}");
Console.WriteLine($"Description.Length={maxFromCollection.Description.Length}");
Console.WriteLine();
Console.WriteLine();


// Поиск файлов и обработка событий
static void FileFound(object sender, FileEventArgs e)
{
    Console.WriteLine($"FileFound {e.File}");
    Console.WriteLine("Stop searching? Y/N");
    
    var answer = Console.ReadLine();
    
    if (answer.ToLower() == "y")
    {
        (sender as FileFinder).Stop();
        Console.WriteLine("You stoped searching for new files");
    }
}

var fileFinder = new FileFinder();
fileFinder.FileFound += FileFound;
fileFinder.FindFiles(@".\..\..\..\FolderToMonitor", true);

fileFinder.FileFound -= FileFound;
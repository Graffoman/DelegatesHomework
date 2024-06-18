namespace DelegatesHomework.FileEvents
{
    public class FileEventArgs(string file) : EventArgs
    {
        public string File { get; } = file;
    }
}

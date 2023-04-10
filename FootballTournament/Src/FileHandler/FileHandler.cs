using System.Text;

namespace ConsoleApp1
{
    public class FileHandler
    {
        public FileHandler()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            Path = Path.Replace("""bin\Debug\net7.0\""", "");
        }

        private string Path;

        public List<string[]> ReadFiles(string pathFromContentRoot)
        {
            List<string[]> stringsList = new List<string[]>();
            string[] filePaths = Directory.GetFiles(Path + pathFromContentRoot);
            foreach (var path in filePaths)
            {
                stringsList.Add(File.ReadAllLines(path, Encoding.UTF8));
            }
            return stringsList;
        }
        
        
        public string[] ReadFile(string pathFromContentRoot)
        {
            return File.ReadAllLines(Path + pathFromContentRoot, Encoding.UTF8);
        }
    }
}
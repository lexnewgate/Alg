using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//todo https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmldocument?view=net-5.0
namespace ChangeProjectTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string exePath = Assembly.GetEntryAssembly().Location;
            string exeDir = Path.GetDirectoryName(exePath);
            string leetCodeCSharpFolder =Path.GetFullPath(Path.Combine(exePath, "..","..","..","..","..", "leetcode_csharp")) ;

          var csProjectFiles=  Directory.GetFiles(leetCodeCSharpFolder, "*.csproj", SearchOption.AllDirectories);

          foreach (var csProjectFile in csProjectFiles)
          {
              Console.WriteLine(csProjectFile);
          }
        }
    }
}

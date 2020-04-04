using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeleteThumbs
{
  internal class Program
  {
    private static void Main()
    {
      Action<string> Display = Console.WriteLine;
      var modele = new List<string> { "thumbs.db" };
      var listeFichierEffaces = new List<string>();
      Display("Searching for all thumbs.db file:");
      int fileCount = 0;
      var directories = CustomSearcher.GetDirectories("c:\\");

      //foreach (var searchFile in SearchFiles(modele))
      //{
      //  fileCount++;
      //  if (searchFile != null)
      //  {
      //    Display(searchFile.ToString());
      //    if (searchFile.DirectoryName != null)
      //    {
      //      Display(Path.Combine(searchFile.DirectoryName, searchFile.Name));
      //      listeFichierEffaces.Add(Path.Combine(searchFile.DirectoryName, searchFile.Name));
      //      try
      //      {
      //        File.Delete(string.Format(Path.Combine(searchFile.DirectoryName, searchFile.Name)));
      //      }
      //      catch (Exception exception)
      //      {
      //        Display($"There was an exception {exception.Message}");
      //      }
      //    }
      //  }
      //}

      //string listDrives = string.Empty;
      //foreach (
      //    DriveInfo drive in
      //        DriveInfo.GetDrives()
      //            .Where(drive => drive.DriveType != DriveType.CDRom)
      //            .Where(drive => drive.DriveType != DriveType.Network)
      //            .Where(drive => drive.DriveType != DriveType.Removable))
      //{
      //  listDrives += $"{drive.Name} ";
      //}

      //Display($"list of drives: {listDrives}");
      Display($"the number of directories found is {directories.Count}");
      Display($"Number of files schecked: {fileCount}");
      Display("Press a key to exit :");
      Console.ReadKey();
    }

    public static List<FileInfo> SearchFiles(List<string> patternsList)
    {
      var files = new List<FileInfo>();
      foreach (DriveInfo drive in DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom).Where(drive => drive.DriveType != DriveType.Network).Where(drive => drive.DriveType != DriveType.Removable))
      {
        var dirs = from dir in drive.RootDirectory.EnumerateDirectories()
                   select new
                   {
                     ProgDir = dir,
                   };

        foreach (var di in dirs)
        {
          try
          {
            foreach (string patternItem in patternsList)
            {
              foreach (var fi in di.ProgDir.EnumerateFiles(patternItem, SearchOption.AllDirectories))
              {
                try
                {
                  files.Add(fi);
                }
                catch (UnauthorizedAccessException)
                {
                  // ignore
                }
              }
            }
          }
          catch (UnauthorizedAccessException)
          {
            // ignore
          }
        }
      }

      return files;
    }
  }
}
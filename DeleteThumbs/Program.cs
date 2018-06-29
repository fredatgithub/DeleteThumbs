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
      var modele = new List<string> { "thumbs.db" };
      var listeFichierEffaces = new List<string>();
      foreach (var searchFile in SearchFiles(modele))
      {
        if (searchFile != null)
        {
          Console.WriteLine(searchFile);
          if (searchFile.DirectoryName != null)
          {
            Console.WriteLine(string.Format(Path.Combine(searchFile.DirectoryName, searchFile.Name)));
            listeFichierEffaces.Add(string.Format(Path.Combine(searchFile.DirectoryName, searchFile.Name)));
            try
            {
              File.Delete(string.Format(Path.Combine(searchFile.DirectoryName, searchFile.Name)));
            }
            catch (Exception exception)
            {
              Console.WriteLine("There was an exception {0}", exception.Message);
            }
          }
        }
      }

      string listDrives = string.Empty;
      foreach (
          DriveInfo drive in
              DriveInfo.GetDrives()
                  .Where(drive => drive.DriveType != DriveType.CDRom)
                  .Where(drive => drive.DriveType != DriveType.Network)
                  .Where(drive => drive.DriveType != DriveType.Removable))
      {
        listDrives += drive.Name + " ";
      }

      Console.WriteLine(listDrives);
      Console.WriteLine("Press a key to exit :");
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

                }
              }
            }
          }
          catch (UnauthorizedAccessException)
          {
          }
        }
      }

      return files;
    }
  }
}
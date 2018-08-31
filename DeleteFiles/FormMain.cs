using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DeleteFiles
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
      // Initialize other variables if needed
    }

    private void ButtonDeleteFiles_Click(object sender, EventArgs e)
    {
      Action<string> Display = Console.WriteLine;
      var modele = new List<string> { "thumbs.db" };
      listBoxFilesDeleted.Items.Clear();
      listBoxDrivesUsed.Items.Clear();
      foreach (var searchFile in SearchFiles(modele))
      {
        if (searchFile != null)
        {
          Display(searchFile.ToString());
          if (searchFile.DirectoryName != null)
          {
            listBoxFilesDeleted.Items.Add(string.Format(Path.Combine(searchFile.DirectoryName, searchFile.Name)));
            try
            {
              File.Delete(string.Format(Path.Combine(searchFile.DirectoryName, searchFile.Name)));
            }
            catch (Exception exception)
            {
              Display(exception.Message);
            }
          }
        }
      }

      foreach (
          DriveInfo drive in
              DriveInfo.GetDrives()
                  .Where(drive => drive.DriveType != DriveType.CDRom)
                  .Where(drive => drive.DriveType != DriveType.Network)
                  .Where(drive => drive.DriveType != DriveType.Removable))
      {
        listBoxDrivesUsed.Items.Add(drive.Name);
      }
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
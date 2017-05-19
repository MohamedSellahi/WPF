using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTreeView {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    #region Constructors 

    public MainWindow() {
      InitializeComponent();
    }
    #endregion


    #region OnLoaded
    /// <summary>
    /// When first the application loaded 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Loaded(object sender, RoutedEventArgs e) {

      // get every logical drive on the machine 
      foreach (var drive in Directory.GetLogicalDrives()) {
        // create a new item that will hold the drive in the tree
        var item = new TreeViewItem();

        // set header and path 
        item.Header = drive;
        item.Tag = drive;

        // add bummy item to get expend icon
        item.Items.Add(null);
        item.Expanded += Folder_Expended;



        // add it to the main tree view 
        FolderView.Items.Add(item);

      }

    }

    #region Folder Expanded 
    private void Folder_Expended(object sender, RoutedEventArgs e) {

      var item = (TreeViewItem)sender;

      // test if the item is a dummy item: if there is data different then the dummy item 
      // return 
      if (item.Items.Count != 1 || item.Items[0] != null)
        return;

      // clear dummy item
      item.Items.Clear();

      //Get the full path 
      var FullPath = (string)item.Tag;

      #region Get Folders
      // empty list that will hold subdirectories if we are able to access them 
      var SubDirs = new List<string>();


      try {
        var dirs = Directory.GetDirectories(FullPath);
        if (dirs.Length > 0) { // we got some subdirectories 
          SubDirs.AddRange(dirs);
        }

      }
      catch (Exception) {

      }

      SubDirs.ForEach(directoryPath => {
        // create a subdirectory item 
        // set its header as the full directory name 
        // and store the current directory in the tag 
        var subItem = new TreeViewItem {
          Tag = directoryPath,
          Header = GetFileFolderName(directoryPath)

        };

        // set dummy subitem as a subdirectory 
        subItem.Items.Add(null);

        //listen to expend event; 
        subItem.Expanded += Folder_Expended;

        // add this folder to the parent 
        item.Items.Add(subItem);
      });

      #endregion


      #region Fet Files

      var files = new List<string>();


      try {
        var fs = Directory.GetFiles(FullPath);
        if (fs.Length > 0) { // we got som 
          files.AddRange(fs);
        }

      }
      catch (Exception) {

      }

      files.ForEach(filePath => {
        // create a file item 
        // set its header as the full file name 
        // and store the current file in the tag 
        var subItem = new TreeViewItem {
          Tag = filePath,
          Header = GetFileFolderName(filePath)

        };

        // set dummy subitem as a subdirectory 
       

        // add this folder to the parent 
        item.Items.Add(subItem);
      });




      #endregion


    }


    #endregion

    public static string GetFileFolderName(string directoryPath) {
      // c:\somthing\folder
      // c:\ somthing\file.png
      if (string.IsNullOrEmpty(directoryPath))
        return string.Empty;

      // we need to remove all caracters from the directory path
      // up to the last backslash (forward slash if not windows )
      // normalize the string 
      var NormalizedPath = directoryPath.Replace('/', '\\');
      int indexofbacklash = NormalizedPath.LastIndexOf('\\');

      // there is no back slash in the string: case where the  
      if (indexofbacklash <= 0)
        return directoryPath;
      return directoryPath.Substring(indexofbacklash + 1);

    }


    #endregion

    private void DataTemplate_Click(object sender, RoutedEventArgs e) {

    }
  }
}

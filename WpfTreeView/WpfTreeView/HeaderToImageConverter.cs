using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView {

  /// <summary>
  /// Converts a full path to a specific image directory, file or folder 
  /// </summary>

  [ValueConversion(typeof(string), typeof(BitmapImage))]
  class HeaderToImageConverter : IValueConverter {

    // get a static instance of this class 
    public static HeaderToImageConverter instance = new HeaderToImageConverter();


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      // get the full path 
      var path = (string)value;

      // if the path is null, just igone 
      if (string.IsNullOrEmpty(path))
        return null;

      // get the name of the file folder 
      var name = MainWindow.GetFileFolderName(path);

      // by default we pressume a file image 
      var image = "Images/File.png";

      // if the name is blank, we assume we have a drive 
      if (string.IsNullOrEmpty(name))
        image = "Images/HDD.png";
      else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
        image = "Images/ClosedFolder.png";

      return new BitmapImage(new Uri($"pack://application:,,,/{image}")); 

    }



    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }



  }
}

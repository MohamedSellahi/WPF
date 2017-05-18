﻿using System;
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

      foreach (var drive in Directory.GetLogicalDrives()) {
        var item = new TreeViewItem();
      
        item.Header = drive;
        FolderView.Items.Add(item);

      }
    }


    #endregion

    private void DataTemplate_Click(object sender, RoutedEventArgs e) {

    }
  }
}

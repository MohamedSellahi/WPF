using System;
using System.Collections.Generic;
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

namespace Wpfbasics {
  /// <summary>
  /// Logique d'interaction pour MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void ApplyButton_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show(this.descriptionText.Text);
    }

    private void Reset_Click(object sender, RoutedEventArgs e) {
      this.WeldCheckbox.IsChecked = this.AssemblyCheckbox.IsChecked = this.PlasmaCheckbox.IsChecked
        = this.LaserCheckbox.IsChecked = this.PuchaseCheckbox.IsChecked = this.LaserCheckbox.IsChecked
        = this.LatheCheckbox.IsChecked = this.FoldCheckbox.IsChecked = this.RollChackbox.IsChecked
        = this.DrillCheckbox.IsChecked = this.SawCheckbox.IsChecked = false;
      this.LengthText.Text = string.Empty;

    }


    private void Checkbox_Checked(object sender, RoutedEventArgs e) {

      this.LengthText.Text += " " +((CheckBox)sender).Content; // a cast may be needed of Content is of different type
    }


    // unchck box handlers 
    private void Checkbox_Unchecked(object sender, RoutedEventArgs e) {
    
    }

    private void FinishDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      if (this.TextNote == null)
        return;
      var combo = (ComboBox)sender;
      var value = (ComboBoxItem)combo.SelectedValue;

      this.TextNote.Text = (string)value.Content;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      FinishDropDown_SelectionChanged(this.FinishDropDown, null);
    }

    private void SupplyerNameText_TextChanged(object sender, TextChangedEventArgs e) {
      this.MassText.Text = this.SupplyerNameText.Text;
    }
  }
}

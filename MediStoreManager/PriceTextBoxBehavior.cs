using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace MediStoreManager
{
    public static class PriceTextBoxBehavior
    {
        private static readonly Regex _priceRegex = new Regex(@"^\d*\.?\d{0,2}$");

        public static bool GetEnablePriceValidation(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnablePriceValidationProperty);
        }

        public static void SetEnablePriceValidation(DependencyObject obj, bool value)
        {
            obj.SetValue(EnablePriceValidationProperty, value);
        }

        public static readonly DependencyProperty EnablePriceValidationProperty =
            DependencyProperty.RegisterAttached(
                "EnablePriceValidation",
                typeof(bool),
                typeof(PriceTextBoxBehavior),
                new UIPropertyMetadata(false, OnEnablePriceValidationChanged));

        private static void OnEnablePriceValidationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.PreviewTextInput += OnPreviewTextInput;
                    DataObject.AddPastingHandler(textBox, OnPaste);
                    textBox.LostFocus += OnLostFocus;
                }
                else
                {
                    textBox.PreviewTextInput -= OnPreviewTextInput;
                    DataObject.RemovePastingHandler(textBox, OnPaste);
                    textBox.LostFocus -= OnLostFocus;
                }
            }
        }

        private static void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
                e.Handled = !_priceRegex.IsMatch(newText);
            }
        }

        private static void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pasteText = (string)e.DataObject.GetData(typeof(string));
                if (sender is TextBox textBox)
                {
                    string newText = textBox.Text.Insert(textBox.SelectionStart, pasteText);
                    if (!_priceRegex.IsMatch(newText))
                    {
                        e.CancelCommand();
                    }
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (decimal.TryParse(textBox.Text, out decimal result))
                {
                    textBox.Text = result.ToString("F2");
                }
            }
        }
    }
}

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
    public static class NumericTextBoxBehavior
    {
        private static readonly Regex _numericRegex = new Regex(@"^\d*$");

        public static bool GetEnableNumericValidation(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableNumericValidationProperty);
        }

        public static void SetEnableNumericValidation(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableNumericValidationProperty, value);
        }

        public static readonly DependencyProperty EnableNumericValidationProperty =
            DependencyProperty.RegisterAttached(
                "EnableNumericValidation",
                typeof(bool),
                typeof(NumericTextBoxBehavior),
                new UIPropertyMetadata(false, OnEnableNumericValidationChanged));

        private static void OnEnableNumericValidationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.PreviewTextInput += OnPreviewTextInput;
                    DataObject.AddPastingHandler(textBox, OnPaste);
                }
                else
                {
                    textBox.PreviewTextInput -= OnPreviewTextInput;
                    DataObject.RemovePastingHandler(textBox, OnPaste);
                }
            }
        }

        private static void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
                e.Handled = !_numericRegex.IsMatch(newText);
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
                    if (!_numericRegex.IsMatch(newText))
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
    }
}

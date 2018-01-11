﻿using Cartif.Util;
using GenericForms.Abstract;
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

namespace GenericForms.Implemented
{
    /// <summary>
    /// Lógica de interacción para PropertyControlTextBoxLarge.xaml
    /// </summary>
    public partial class PropertyControlTextBoxLarge : PropertyControl
    {
        public PropertyControlTextBoxLarge()
        {
            InitializeComponent();
        }

        public override Boolean IsValid
        {
            get { return (Validate?.Invoke(this.innerContent.Text) ?? true) && Validation.GetErrors(innerContent).Count == 0; }
        }

        public override String Label
        {
            get { return this.label.Content.ToString(); }
            set
            {
                if ("".Equals(value))
                {

                }
                else
                    this.label.Content = value + ":";
            }
        }

        public override Boolean? Enabled
        {
            get { return this.innerContent.IsEnabled; }
            set
            {
                if (value != null)
                    this.innerContent.IsEnabled = value ?? true;
            }
        }

        public override Boolean? ReadOnly
        {
            get { return this.innerContent.IsReadOnly; }
            set
            {
                if (value != null)
                    this.innerContent.IsReadOnly = value ?? false;
            }
        }

        public override String ControlToolTipText
        {
            get { return this.innerContent.ToolTip.ToString(); }
            set { this.innerContent.ToolTip = value; }
        }

        public override double HeightMultiline
        {
            get { return panel.Height; }
            set
            {
                if (value != 0)
                {
                    innerContent.TextWrapping = TextWrapping.Wrap;
                    innerContent.AcceptsReturn = true;
                    panel.Height = value;
                }
            }
        }

        public override void SetContentBinding(Object obj)
        {
            BindUtils.Bind(obj, PropertyName, this.innerContent, TextBox.TextProperty, new GenericValidation<PropertyControl>(this, Validate, OnValid, OnInvalid));
        }

        public override void SetContentBinding(Object obj, Object targetNull)
        {
            BindUtils.Bind(obj, PropertyName, this.innerContent, TextBox.TextProperty, new GenericValidation<PropertyControl>(this, Validate, OnValid, OnInvalid), targetNull);
        }

        override public void ShowMessage(String mensaje, Brush color)
        {
            this.mensaje.Content = mensaje;
            this.mensaje.Foreground = color;
            this.mensaje.Visibility = Visibility.Visible;
        }

        override public void HideMessage()
        {
            this.mensaje.Visibility = Visibility.Collapsed;
        }


        public override void SetInnerContent(Object o)
        {
            this.innerContent.Text = o?.ToString();
        }

        //public bool ContentsBiggerThanLabel()
        //{
        //    Typeface typeface = new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, this.FontStretch);
        //    FormattedText ft = new FormattedText(label.Content.ToString(), System.Globalization.CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, typeface, this.FontSize, Brushes.Black);
        //    if (ft.Width > label.ActualWidth)
        //        return true;

        //    return false;
        //}
    }
}

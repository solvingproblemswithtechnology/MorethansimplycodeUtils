﻿using Cartif.Util;
using GenericForms.Abstract;
using LAE.Comun.Persistence;
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
using Xceed.Wpf.Toolkit;

namespace GenericForms.Implemented
{
    /// <summary>
    /// Lógica de interacción para PropertyControlTextBox.xaml
    /// </summary>
    public partial class PropertyControlDateTime : PropertyControl
    {
        public PropertyControlDateTime()
        {
            InitializeComponent();
        }

        public override Boolean IsValid
        {
            get { return Validate?.Invoke(this.innerContent.Text) ?? true; }
        }

        public override String Label
        {
            get { return this.label.Content.ToString(); }
            set
            {
                if ("".Equals(value))
                {
                    FirstColumn.Width = new GridLength(0);
                    FirstColumn.MinWidth = 0;
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
                    this.innerContent.IsReadOnly = value ?? true;
            }
        }

        public override String ControlToolTipText
        {
            get { return this.innerContent.ToolTip.ToString(); }
            set { this.innerContent.ToolTip = value; }
        }


        public override void SetContentBinding(Object obj)
        {
            BindUtils.Bind(obj, PropertyName, this.innerContent, DateTimePicker.ValueProperty, new GenericValidation<PropertyControl>(this, Validate, OnValid, OnInvalid));
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

        public override void AddValueChanged(RoutedPropertyChangedEventHandler<object> handler)
        {
            if (handler != null)
                innerContent.ValueChanged += handler;
        }

    }
}

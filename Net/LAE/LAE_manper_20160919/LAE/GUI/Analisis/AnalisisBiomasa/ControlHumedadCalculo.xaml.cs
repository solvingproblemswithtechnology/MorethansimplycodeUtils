﻿using GenericForms.Abstract;
using GenericForms.Settings;
using LAE.Calculos;
using LAE.Clases;
using LAE.Modelo;
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

namespace GUI.Analisis
{
    /// <summary>
    /// Lógica de interacción para ControlHumedadCalculo.xaml
    /// </summary>
    public partial class ControlHumedadCalculo : UserControl
    {
        private HumedadTotal humedad;
        public HumedadTotal Humedad
        {
            get { return humedad; }
            set
            {
                humedad = value;
                Fill();
            }
        }

        public ControlHumedadCalculo()
        {
            InitializeComponent();
            CargarHumedad();
        }

        private void CargarHumedad()
        {
            panelCalculos.Build(new HumedadTotal(),
                new TypePanelSettings<HumedadTotal>
                {
                    ColumnWidths=new int[] {1,1},
                    Fields = new FieldSettings
                    {
                        ["MediaHumedadTotal2"] = PropertyControlSettingsEnum.TextBoxEmptyToNull
                                .SetLabel("Valor Medio")
                                .SetReadOnly(true)
                                .SetColor((SolidColorBrush)Application.Current.Resources["TextBoxDisabledBrush"]),
                        ["CV2"] = PropertyControlSettingsEnum.TextBoxEmptyToNull
                                .SetLabel("CV")
                                .SetReadOnly(true)
                                .SetColor((SolidColorBrush)Application.Current.Resources["TextBoxDisabledBrush"]),
                    }
                });
        }

        private void Fill()
        {
            panelCalculos["MediaHumedadTotal2"].SetInnerContent(Calcular.VisualizeDecimals(Humedad.MediaHumedadTotal, 2));
            panelCalculos["CV2"].SetInnerContent(Calcular.VisualizeDecimals(Humedad.CV, 2));

            labelAceptacion.Aceptacion(Humedad.Aceptado, Name.Equals("CCIAceptacion"));
        }

        public void Clear()
        {
            panelCalculos.Clear();
            labelAceptacion.Visibility = Visibility.Collapsed;
        }
    }
}

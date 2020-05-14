using GenSci.FM.Core.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GenSci.FM.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        GenSciContext GenSciContext { get; } = new GenSciContext();

        protected override void OnStartup(StartupEventArgs e)
        {
            var genSciFile = new MainWindow { DataContext = GenSciContext };

            genSciFile.ShowDialog();
        }
    }
}
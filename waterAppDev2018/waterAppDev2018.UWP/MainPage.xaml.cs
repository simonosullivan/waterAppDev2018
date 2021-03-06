﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace waterAppDev2018.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string dbName = "Drink-Up_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string fullPath = Path.Combine(folderPath, dbName);

            LoadApplication(new waterAppDev2018.App());
        }
    }
}

﻿using Raamatupood.Models;
using Raamatupood.Views;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raamatupood
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "raamat.db";
        public static RaamatuRepository database;
        public static RaamatuRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new RaamatuRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }

        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

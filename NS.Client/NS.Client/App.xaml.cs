﻿using NS.Client.Modules.ModuleName;
using NS.Client.Services;
using NS.Client.Services.Interfaces;
using NS.Client.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace NS.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
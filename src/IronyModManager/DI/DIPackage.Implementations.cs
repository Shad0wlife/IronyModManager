﻿// ***********************************************************************
// Assembly         : IronyModManager
// Author           : Mario
// Created          : 01-11-2020
//
// Last Modified By : Mario
// Last Modified On : 09-30-2020
// ***********************************************************************
// <copyright file="DIPackage.Implementations.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using IronyModManager.Common;
using IronyModManager.DI.Extensions;
using IronyModManager.Fonts;
using IronyModManager.Implementation;
using IronyModManager.Implementation.Actions;
using IronyModManager.Implementation.AppState;
using IronyModManager.Implementation.MessageBus;
using IronyModManager.Implementation.Updater;
using IronyModManager.Log;
using IronyModManager.Shared;
using Container = SimpleInjector.Container;

namespace IronyModManager.DI
{
    /// <summary>
    /// Class DIPackage.
    /// Implements the <see cref="SimpleInjector.Packaging.IPackage" />
    /// </summary>
    /// <seealso cref="SimpleInjector.Packaging.IPackage" />
    public partial class DIPackage
    {
        #region Methods

        /// <summary>
        /// Registers the implementations.
        /// </summary>
        /// <param name="container">The container.</param>
        private void RegisterImplementations(Container container)
        {
            container.Register<IViewResolver, ViewResolver>();
            container.Register<ILogger, Logger>();
            container.Register<IAppAction, AppAction>();
            container.Register<INotificationAction, NotificationAction>();
            container.Register<IFileDialogAction, FileDialogAction>();
            container.Register<WritingStateOperationHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<ModDefinitionAnalyzeHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<ModDefinitionLoadHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<ModDefinitionPatchLoadHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<ModDefinitionMergeProgressHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<IShutDownState, ShutdownState>(SimpleInjector.Lifestyle.Singleton);
            container.Register<OverlayProgressHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<ModFileMergeProgressHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<ActiveGameRequestHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<IUpdater, Updater>(SimpleInjector.Lifestyle.Singleton);
            container.RemoveMixedLifetimeWarning<IAppAction>();
            container.Register<UpdateUnpackProgressHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<GameUserDirectoryChangedHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Register<ModReportExportHandler>(SimpleInjector.Lifestyle.Singleton);
            container.Collection.Register(typeof(IFontFamily), new List<Type>()
            {
                typeof(NotoSansFontFamily), typeof(NotoSansSCFontFamily)
            }, SimpleInjector.Lifestyle.Singleton);
            container.Register<IFontFamilyManager, FontFamilyManager>(SimpleInjector.Lifestyle.Singleton);
        }

        #endregion Methods
    }
}

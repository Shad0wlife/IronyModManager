﻿// ***********************************************************************
// Assembly         : IronyModManager
// Author           : Mario
// Created          : 01-12-2020
//
// Last Modified By : Mario
// Last Modified On : 10-01-2020
// ***********************************************************************
// <copyright file="DIPackage.Views.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System;
using IronyModManager.Views;
using IronyModManager.Views.Controls;
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
        /// Registers the views.
        /// </summary>
        /// <param name="container">The container.</param>
        private void RegisterViews(Container container)
        {
            container.Register<MainWindow>();
            container.Register<ThemeControlView>();
            container.Register<LanguageControlView>();
            container.Register<MainControlView>();
            container.Register<GameControlView>();
            container.Register<InstalledModsControlView>();
            container.Register<SortOrderControlView>();
            container.Register<ModHolderControlView>();
            container.Register<SearchModsControlView>();
            container.Register<CollectionModsControlView>();
            container.Register<AddNewCollectionControlView>();
            container.Register<ExportModCollectionControlView>();
            container.Register<MainConflictSolverControlView>();
            container.Register<MergeViewerControlView>();
            container.Register<ModCompareSelectorControlView>();
            container.Register<MergeViewerBinaryControlView>();
            container.Register<ModConflictIgnoreControlView>();
            container.Register<ModifyCollectionControlView>();
            container.Register<OptionsControlView>();
            container.Register<ConflictSolverModFilterControlView>();
            container.Register<ConflictSolverResetConflictsControlView>();
            container.Register<ConflictSolverDBSearchControlView>();
            container.Register<ConflictSolverCustomConflictsControlView>();
            container.Register<ShortcutsControlView>();
            container.Register<ModHashReportControlView>();
        }

        #endregion Methods
    }
}

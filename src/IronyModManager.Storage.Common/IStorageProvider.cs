﻿// ***********************************************************************
// Assembly         : IronyModManager.Storage.Common
// Author           : Mario
// Created          : 01-11-2020
//
// Last Modified By : Mario
// Last Modified On : 05-18-2020
// ***********************************************************************
// <copyright file="IStorageProvider.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System;
using IronyModManager.Models.Common;

namespace IronyModManager.Storage.Common
{
    /// <summary>
    /// Interface IStorageProvider
    /// </summary>
    public interface IStorageProvider
    {
        #region Methods

        /// <summary>
        /// Gets the state of the application.
        /// </summary>
        /// <returns>IAppState.</returns>
        IAppState GetAppState();

        /// <summary>
        /// Gets the games.
        /// </summary>
        /// <returns>IEnumerable&lt;IGameType&gt;.</returns>
        IEnumerable<IGameType> GetGames();

        /// <summary>
        /// Gets the mod collections.
        /// </summary>
        /// <returns>IEnumerable&lt;IModCollection&gt;.</returns>
        IEnumerable<IModCollection> GetModCollections();

        /// <summary>
        /// Gets the preferences.
        /// </summary>
        /// <returns>IPreferences.</returns>
        IPreferences GetPreferences();

        /// <summary>
        /// Gets the themes.
        /// </summary>
        /// <returns>IEnumerable&lt;IThemeType&gt;.</returns>
        IEnumerable<IThemeType> GetThemes();

        /// <summary>
        /// Gets the state of the window.
        /// </summary>
        /// <returns>IWindowState.</returns>
        IWindowState GetWindowState();

        /// <summary>
        /// Registers the game.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="appId">The application identifier.</param>
        /// <param name="userDirectory">The user directory.</param>
        /// <param name="workshopDirectory">The workshop directory.</param>
        /// <param name="logLocation">The log location.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool RegisterGame(string name, int appId, string userDirectory, string workshopDirectory, string logLocation);

        /// <summary>
        /// Registers the theme.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="styles">The styles.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool RegisterTheme(string name, IEnumerable<string> styles, bool isDefault = false);

        /// <summary>
        /// Sets the state of the application.
        /// </summary>
        /// <param name="appState">State of the application.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetAppState(IAppState appState);

        /// <summary>
        /// Sets the mod collections.
        /// </summary>
        /// <param name="modCollections">The mod collections.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetModCollections(IEnumerable<IModCollection> modCollections);

        /// <summary>
        /// Sets the preferences.
        /// </summary>
        /// <param name="preferences">The preferences.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetPreferences(IPreferences preferences);

        /// <summary>
        /// Sets the state of the window.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetWindowState(IWindowState state);

        #endregion Methods
    }
}

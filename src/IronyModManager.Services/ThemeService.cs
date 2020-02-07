﻿// ***********************************************************************
// Assembly         : IronyModManager.Services
// Author           : Mario
// Created          : 01-13-2020
//
// Last Modified By : Mario
// Last Modified On : 02-07-2020
// ***********************************************************************
// <copyright file="ThemeService.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IronyModManager.DI;
using IronyModManager.Models.Common;
using IronyModManager.Services.Common;
using IronyModManager.Storage.Common;

namespace IronyModManager.Services
{
    /// <summary>
    /// Class ThemeService.
    /// Implements the <see cref="IronyModManager.Services.IThemeService" />
    /// </summary>
    /// <seealso cref="IronyModManager.Services.IThemeService" />
    public class ThemeService : IThemeService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeService" /> class.
        /// </summary>
        /// <param name="storageProvider">The storage provider.</param>
        /// <param name="preferencesService">The preferences service.</param>
        /// <param name="mapper">The mapper.</param>
        public ThemeService(IStorageProvider storageProvider, IPreferencesService preferencesService, IMapper mapper)
        {
            StorageProvider = storageProvider;
            PreferencesService = preferencesService;
            Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <value>The mapper.</value>
        protected IMapper Mapper { get; private set; }

        /// <summary>
        /// Gets the preferences service.
        /// </summary>
        /// <value>The preferences service.</value>
        protected IPreferencesService PreferencesService { get; private set; }

        /// <summary>
        /// Gets the storage provider.
        /// </summary>
        /// <value>The storage provider.</value>
        protected IStorageProvider StorageProvider { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;ITheme&gt;.</returns>
        public IEnumerable<ITheme> Get()
        {
            var preferences = PreferencesService.Get();

            var registeredThemes = StorageProvider.GetThemes();
            var themes = new List<ITheme>();

            foreach (var item in registeredThemes)
            {
                var theme = InitModel(item, preferences.Theme);
                themes.Add(theme);
            }

            EnsureThemeIsSelected(themes, registeredThemes);

            return themes;
        }

        /// <summary>
        /// Gets the selected.
        /// </summary>
        /// <returns>ITheme.</returns>
        public ITheme GetSelected()
        {
            return Get().FirstOrDefault(p => p.IsSelected);
        }

        /// <summary>
        /// Saves the specified theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="InvalidOperationException">Theme not selected.</exception>
        public bool Save(ITheme theme)
        {
            if (!theme.IsSelected)
            {
                throw new InvalidOperationException("Theme not selected.");
            }
            var preference = PreferencesService.Get();

            return PreferencesService.Save(Mapper.Map(theme, preference));
        }

        /// <summary>
        /// Sets the selected.
        /// </summary>
        /// <param name="themes">The themes.</param>
        /// <param name="selectedTheme">The selected theme.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException">themes or selectedTheme.</exception>
        public bool SetSelected(IEnumerable<ITheme> themes, ITheme selectedTheme)
        {
            if (themes == null || themes.Count() == 0 || selectedTheme == null)
            {
                throw new ArgumentNullException("themes or selectedTheme.");
            }
            var currentlySelected = GetSelected();
            if (currentlySelected.Type == selectedTheme.Type)
            {
                return false;
            }

            foreach (var item in themes)
            {
                if (item.Type != currentlySelected.Type)
                {
                    item.IsSelected = false;
                }
            }

            selectedTheme.IsSelected = true;
            return Save(selectedTheme);
        }

        /// <summary>
        /// Ensures the theme is selected.
        /// </summary>
        /// <param name="themes">The themes.</param>
        /// <param name="themeTypes">The theme types.</param>
        protected virtual void EnsureThemeIsSelected(IEnumerable<ITheme> themes, IEnumerable<IThemeType> themeTypes)
        {
            if (themes.Count() > 0 && !themes.Any(p => p.IsSelected))
            {
                themes.FirstOrDefault(p => p.Type == themeTypes.FirstOrDefault(s => s.IsDefault).Name).IsSelected = true;
            }
        }

        /// <summary>
        /// Initializes the model.
        /// </summary>
        /// <param name="themeItem">The theme item.</param>
        /// <param name="selectedType">Type of the selected.</param>
        /// <returns>ITheme.</returns>
        protected virtual ITheme InitModel(IThemeType themeItem, string selectedType)
        {
            var theme = DIResolver.Get<ITheme>();
            theme.Type = themeItem.Name;
            theme.IsSelected = themeItem.Name == selectedType;
            theme.StyleIncludes = themeItem.Styles;
            theme.Name = themeItem.Name;
            return theme;
        }

        #endregion Methods
    }
}
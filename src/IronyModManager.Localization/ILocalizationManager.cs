﻿// ***********************************************************************
// Assembly         : IronyModManager.Localization
// Author           : Mario
// Created          : 01-18-2020
//
// Last Modified By : Mario
// Last Modified On : 09-30-2020
// ***********************************************************************
// <copyright file="ILocalizationManager.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

namespace IronyModManager.Localization
{
    /// <summary>
    /// Interface ILocalizationManager
    /// </summary>
    public interface ILocalizationManager
    {
        #region Methods

        /// <summary>
        /// Gets the resource.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        string GetResource(string key);

        /// <summary>
        /// Gets the resource.
        /// </summary>
        /// <param name="locale">The locale.</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        string GetResource(string locale, string key);

        #endregion Methods
    }
}

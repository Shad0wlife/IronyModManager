﻿// ***********************************************************************
// Assembly         : IronyModManager.IO.Common
// Author           : Mario
// Created          : 03-31-2020
//
// Last Modified By : Mario
// Last Modified On : 04-09-2020
// ***********************************************************************
// <copyright file="IModWriter.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace IronyModManager.IO.Common.Mods
{
    /// <summary>
    /// Interface IModWriter
    /// </summary>
    public interface IModWriter
    {
        #region Methods

        /// <summary>
        /// Applies the mods asynchronous.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> ApplyModsAsync(ModWriterParameters parameters);

        /// <summary>
        /// Creates the mod directory asynchronous.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CreateModDirectoryAsync(ModWriterParameters parameters);

        /// <summary>
        /// Descriptors the exists asynchronous.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> DescriptorExistsAsync(ModWriterParameters parameters);

        /// <summary>
        /// Purges the mod directory asynchronous.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> PurgeModDirectoryAsync(ModWriterParameters parameters);

        /// <summary>
        /// Writes the descriptor asynchronous.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> WriteDescriptorAsync(ModWriterParameters parameters);

        #endregion Methods
    }
}
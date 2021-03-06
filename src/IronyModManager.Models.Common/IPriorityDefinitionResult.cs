﻿// ***********************************************************************
// Assembly         : IronyModManager.Models.Common
// Author           : Mario
// Created          : 04-27-2020
//
// Last Modified By : Mario
// Last Modified On : 04-27-2020
// ***********************************************************************
// <copyright file="IPriorityDefinitionResult.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System;
using IronyModManager.Parser.Common.Definitions;

namespace IronyModManager.Models.Common
{
    /// <summary>
    /// Interface IPriorityDefinitionResult
    /// Implements the <see cref="IronyModManager.Models.Common.IModel" />
    /// </summary>
    /// <seealso cref="IronyModManager.Models.Common.IModel" />
    public interface IPriorityDefinitionResult : IModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        /// <value>The definition.</value>
        IDefinition Definition { get; set; }

        /// <summary>
        /// Gets or sets the type of the priority.
        /// </summary>
        /// <value>The type of the priority.</value>
        DefinitionPriorityType PriorityType { get; set; }

        #endregion Properties
    }
}

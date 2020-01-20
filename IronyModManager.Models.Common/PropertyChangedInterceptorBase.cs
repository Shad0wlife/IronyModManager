﻿// ***********************************************************************
// Assembly         : IronyModManager.Models.Common
// Author           : Mario
// Created          : 01-20-2020
//
// Last Modified By : Mario
// Last Modified On : 01-20-2020
// ***********************************************************************
// <copyright file="PropertyChangedInterceptorBase.cs" company="Mario">
//     Mario
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using IronyModManager.Shared;

namespace IronyModManager.Models.Common
{
    /// <summary>
    /// Class PropertyChangedInterceptorBase.
    /// Implements the <see cref="Castle.DynamicProxy.IInterceptor" />
    /// </summary>
    /// <seealso cref="Castle.DynamicProxy.IInterceptor" />
    public abstract class PropertyChangedInterceptorBase : IInterceptor
    {
        #region Fields

        /// <summary>
        /// The set method
        /// </summary>
        private const string SetMethod = "set_";

        #endregion Fields

        #region Methods

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="prop">The property.</param>
        public abstract void FireEvent(IInvocation invocation, PropertyInfo prop);

        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public virtual void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name.StartsWith(SetMethod))
            {
                var methodName = invocation.Method.Name.Replace(SetMethod, string.Empty);
                var prop = invocation.TargetType.GetProperty(methodName);
                if (HasValueChanged(invocation, prop) && !ShouldSkipProperty(invocation, prop))
                {
                    FireEvent(invocation, prop);
                }
            }
            invocation.Proceed();
        }

        /// <summary>
        /// Determines whether [has value changed] [the specified invocation].
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="prop">The property.</param>
        /// <returns><c>true</c> if [has value changed] [the specified invocation]; otherwise, <c>false</c>.</returns>
        protected virtual bool HasValueChanged(IInvocation invocation, PropertyInfo prop)
        {
            var newVal = invocation.Arguments?[0];
            var oldVal = prop.GetValue(invocation.InvocationTarget, null);
            return newVal != oldVal;
        }

        /// <summary>
        /// Shoulds the skip property.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="prop">The property.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool ShouldSkipProperty(IInvocation invocation, PropertyInfo prop)
        {
            var classAttr = invocation.TargetType.GetCustomAttributes(typeof(DoNotNotifyAttribute), true);
            if (classAttr?.Count() > 0)
            {
                return true;
            }
            var attr = prop.GetCustomAttributes(typeof(DoNotNotifyAttribute), true);
            if (attr?.Count() > 0)
            {
                return true;
            }
            return false;
        }

        #endregion Methods
    }
}

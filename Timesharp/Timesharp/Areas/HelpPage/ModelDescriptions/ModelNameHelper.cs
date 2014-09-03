// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelNameHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The model name helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Areas.HelpPage.ModelDescriptions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The model name helper.
    /// </summary>
    internal static class ModelNameHelper
    {
        // Modify this to provide custom model name mapping.
        #region Public Methods and Operators

        /// <summary>
        /// The get model name.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetModelName(Type type)
        {
            var modelNameAttribute = type.GetCustomAttribute<ModelNameAttribute>();
            if (modelNameAttribute != null && !string.IsNullOrEmpty(modelNameAttribute.Name))
            {
                return modelNameAttribute.Name;
            }

            string modelName = type.Name;
            if (type.IsGenericType)
            {
                // Format the generic type name to something like: GenericOfAgurment1AndArgument2
                Type genericType = type.GetGenericTypeDefinition();
                Type[] genericArguments = type.GetGenericArguments();
                string genericTypeName = genericType.Name;

                // Trim the generic parameter counts from the name
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                string[] argumentTypeNames = genericArguments.Select(t => GetModelName(t)).ToArray();
                modelName = string.Format(
                    CultureInfo.InvariantCulture, 
                    "{0}Of{1}", 
                    genericTypeName, 
                    string.Join("And", argumentTypeNames));
            }

            return modelName;
        }

        #endregion
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrtgAPI.Helpers
{
    /// <summary>
    /// Defines helper extension methods used for performing reflection.
    /// </summary>
    public static class ReflectionHelpers
    {
        private static BindingFlags internalFlags = BindingFlags.Instance | BindingFlags.NonPublic;

        /// <summary>
        /// Retrieve the value of an internal property of an object.
        /// </summary>
        /// <param name="obj">The object to retrieve the property from.</param>
        /// <param name="name">The name of the property whose value should be retrieved.</param>
        /// <returns>The value of the retrieved property.</returns>
        public static object GetInternalProperty(this object obj, string name)
        {
            return obj.GetInternalPropertyInfo(name).GetValue(obj);
        }

        /// <summary>
        /// Retrieve the property info metadata of an internal property.
        /// </summary>
        /// <param name="obj">The object to retrieve the property from.</param>
        /// <param name="name">The name of the property whose info should be retrieved.</param>
        /// <returns>The property info of the specified property. If the property cannot be found or is not internal, this method returns null.</returns>
        public static PropertyInfo GetInternalPropertyInfo(this object obj, string name)
        {
            var prop = obj.GetType().GetProperty(name, internalFlags);

            return prop;
        }

        /// <summary>
        /// Retrieve the value of an internal field of an object.
        /// </summary>
        /// <param name="obj">The object to retrieve the field from.</param>
        /// <param name="name">The name of the field whose value should be retrieved.</param>
        /// <returns>The value of the retrieved field.</returns>
        public static object GetInternalField(this object obj, string name)
        {
            return obj.GetInternalFieldInfo(name).GetValue(obj);
        }

        /// <summary>
        /// Retrieve the field info metadata of an internal field.
        /// </summary>
        /// <param name="obj">The object to retrieve the field from.</param>
        /// <param name="name">The name of the field whose info should be retrieved.</param>
        /// <returns>The field info of the specified field. If the field cannot be found or is not internal, this method returns null.</returns>
        public static FieldInfo GetInternalFieldInfo(this object obj, string name)
        {
            var field = obj.GetType().GetField(name, internalFlags);

            return field;
        }

        /// <summary>
        /// Retrieve an internal method from an object.
        /// </summary>
        /// <param name="obj">The object to retrieve the method from.</param>
        /// <param name="name">The name of the method to retrieve.</param>
        /// <returns>The method info of the specified method. If the specified method cannot be found or is not internal, this method returns null.<para/>
        /// If more than one method is found with the specified name, this method throws a <see cref="AmbiguousMatchException"/></returns>
        public static MethodInfo GetInternalMethod(this object obj, string name)
        {
            var method = obj.GetType().GetMethod(name, internalFlags);

            return method;
        }
    }
}
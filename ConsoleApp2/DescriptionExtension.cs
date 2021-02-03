﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApp2
{
    public interface IDescription
    {

    }

    public static class DescriptionExtension
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var fi = type.GetField(value.ToString());
            var atrib = fi.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            var str = atrib switch
            {
                null => value.ToString(),
                _ => atrib.Description
            };
            return str;
        }
        public static string GetPropertyDescription<T>(this T value, string propertyName) where T : IDescription
        {
            var type = value.GetType();
            var prop = type.GetProperty(propertyName);
            if (prop is null)
            {
                throw new ArgumentException($"Property \"{propertyName}\" not found in {type}");
            }
            var atrib = prop.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            var str = atrib switch
            {
                null => value.ToString(),
                _ => atrib.Description
            };
            return str;
        }
    }
}

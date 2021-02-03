using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp2
{
    public interface ISettings
    {

    }

    public static class SettingsExtension
    {
        public static void Display<T>(this T settings) where T : ISettings, IDescription
        {
            MyConsole.WriteLineGreen($"Current Settings");
            foreach (var setting in settings.GetType().GetProperties())
            {
                var description = settings.GetPropertyDescription(setting.Name);
                var value = setting.GetValue(settings);
                MyConsole.WriteLine($"{description,-40} {value}");
            }
            MyConsole.WriteLine();
        }

        public static void Save<T>(this T settings) where T : ISettings, IDescription
        {
            var userSettings = new UserSettings();
            foreach (var setting in settings.GetType().GetProperties())
            {
                var name = setting.Name;
                var value = setting.GetValue(settings);
                var userSetting = userSettings.GetType().GetProperty(name);
                if (userSetting is null)
                {
                    throw new Exception($"In '{nameof(UserSettings)}' not found property '{name}'");
                }
                userSetting.SetValue(userSettings, value);
            }
            userSettings.Save();
        }

        public static void Read<T>(this T settings) where T : ISettings, IDescription
        {
            var userSettings = new UserSettings();
            foreach (var setting in settings.GetType().GetProperties())
            {
                var name = setting.Name;
                var userSetting = userSettings.GetType().GetProperty(name);
                if (userSetting is null)
                {
                    throw new Exception($"In '{nameof(UserSettings)}' not found property '{name}'");
                }
                var value = userSetting.GetValue(userSettings);
                setting.SetValue(settings, value);
            }
        }


        public static string SaveToStr<T>(this T settings) where T : ISettings
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            return JsonSerializer.Serialize(settings, jsonOptions);
        }

        public static void ReadFromStr<T>(this T settings, string str) where T : ISettings
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var newSettings = JsonSerializer.Deserialize<T>(str, jsonOptions);
            CopyAllProperty(newSettings, settings);
        }

        public static void SaveToFile<T>(this T settings) where T : ISettings
        {
            MyConsole.WriteNewLineGreen("Введите имя файла для сохранения настроек");
            var fileName = MyConsole.ReadLine() + ".json";
            var dirPath = AppContext.BaseDirectory + "/settings";
            var filePath = $"{dirPath}/{fileName}";
            Directory.CreateDirectory(dirPath);
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string jsonString = JsonSerializer.Serialize(settings, jsonOptions);
            File.WriteAllText(filePath, jsonString);
            MyConsole.WriteNewLineGreen($"Настройки сохранены в файл {fileName}");
        }

        public static void ReadFromFile<T>(this T settings) where T : ISettings
        {
            var dirPath = AppContext.BaseDirectory + "/settings";
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            List<string> fileNames = new List<string>();
            foreach (var file in dir.GetFiles("*.json"))
            {
                fileNames.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
            if (fileNames.Count == 0)
            {
                MyConsole.WriteNewLineRed("Файлы настроек не найдены!");
            }

            var fileName = MyConsole.SelectFromList(fileNames.ToArray(), "Файлы");
            var filePath = $"{dirPath}/{fileName}.json";
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var jsonString = File.ReadAllText(filePath);
            var newSettings = JsonSerializer.Deserialize<T>(jsonString, jsonOptions);
            CopyAllProperty(newSettings, settings);
        }

        private static void CopyAllProperty<T>(T source, T target)
        {
            var type = typeof(T);
            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = type.GetProperty(sourceProperty.Name);
                targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
            }
        }
    }
}

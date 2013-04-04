/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace MyNes.Renderers
{
    public class SettingsManager
    {
        private SettingsData settings = new SettingsData();
        /// <summary>
        /// Get the settings data class
        /// </summary>
        public SettingsData Settings { get { return settings; } }

        /// <summary>
        /// Save the settings at user document using xml serialize
        /// </summary>
        public void SaveSettings()
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\");
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\settings.xml";
            XmlSerializer SER = new XmlSerializer(typeof(SettingsData));
            Stream STR = new FileStream(path, FileMode.Create);
            SER.Serialize(STR, settings);
            STR.Close();
        }
        /// <summary>
        /// Load settings from user documents using xml deserialize
        /// </summary>
        public void LoadSettings()
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\");
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\settings.xml";
            try
            {
                XmlSerializer SER = new XmlSerializer(typeof(SettingsData));
                Stream STR = new FileStream(path, FileMode.Open, FileAccess.Read);
                settings = (SettingsData)SER.Deserialize(STR);
                STR.Close();
            }
            catch
            { RestoreDefaults(); }
        }
        /// <summary>
        /// Restore defaults for all settings data
        /// </summary>
        public void RestoreDefaults()
        {
            settings = new SettingsData();
        }
        /// <summary>
        /// Save settings object
        /// </summary>
        /// <param name="fileName">The settings file name without extension</param>
        /// <param name="settingsObject">The settings object to save</param>
        public static void SaveSettingsObject(string fileName, object settingsObject)
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\");
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\" + fileName + ".xml";
            XmlSerializer SER = new XmlSerializer(settingsObject.GetType());
            Stream STR = new FileStream(path, FileMode.Create);
            SER.Serialize(STR, settingsObject);
            STR.Close();
        }
        /// <summary>
        /// Load settings object
        /// </summary>
        /// <param name="fileName">The settings file name without extension</param>
        /// <param name="objectType">The type of the settings object</param>
        /// <returns>The settings object if load done successfully otherwise null</returns>
        public static object LoadSettingsObject(string fileName, System.Type objectType)
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\");
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyNes\\" + fileName + ".xml";
            object settingsobject;
            try
            {
                XmlSerializer SER = new XmlSerializer(objectType);
                Stream STR = new FileStream(path, FileMode.Open, FileAccess.Read);
                settingsobject = SER.Deserialize(STR);
                STR.Close();
                return settingsobject;
            }
            catch
            { return null; }
        }
    }
}

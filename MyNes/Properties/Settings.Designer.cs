﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyNes.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("800, 600")]
        public global::System.Drawing.Size MainFormSize {
            get {
                return ((global::System.Drawing.Size)(this["MainFormSize"]));
            }
            set {
                this["MainFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\fdb.fl")]
        public string FoldersDatabasePath {
            get {
                return ((string)(this["FoldersDatabasePath"]));
            }
            set {
                this["FoldersDatabasePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10, 10")]
        public global::System.Drawing.Point console_location {
            get {
                return ((global::System.Drawing.Point)(this["console_location"]));
            }
            set {
                this["console_location"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("800, 600")]
        public global::System.Drawing.Size console_size {
            get {
                return ((global::System.Drawing.Size)(this["console_size"]));
            }
            set {
                this["console_size"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SlimDX")]
        public global::MyNes.SupportedRenderers CurrentRenderer {
            get {
                return ((global::MyNes.SupportedRenderers)(this["CurrentRenderer"]));
            }
            set {
                this["CurrentRenderer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\StateSaves")]
        public string StateFolder {
            get {
                return ((string)(this["StateFolder"]));
            }
            set {
                this["StateFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ControlProfileIndex {
            get {
                return ((int)(this["ControlProfileIndex"]));
            }
            set {
                this["ControlProfileIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\Snapshots")]
        public string SnapshotsFolder {
            get {
                return ((string)(this["SnapshotsFolder"]));
            }
            set {
                this["SnapshotsFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int Volume {
            get {
                return ((int)(this["Volume"]));
            }
            set {
                this["Volume"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("44100")]
        public int SoundPlaybackFreq {
            get {
                return ((int)(this["SoundPlaybackFreq"]));
            }
            set {
                this["SoundPlaybackFreq"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SoundEnabled {
            get {
                return ((bool)(this["SoundEnabled"]));
            }
            set {
                this["SoundEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AUTO")]
        public global::MyNes.Core.Types.EmulationSystem EmuSystem {
            get {
                return ((global::MyNes.Core.Types.EmulationSystem)(this["EmuSystem"]));
            }
            set {
                this["EmuSystem"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("283, 64")]
        public global::System.Drawing.Point MainFormLocation {
            get {
                return ((global::System.Drawing.Point)(this["MainFormLocation"]));
            }
            set {
                this["MainFormLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("205")]
        public int SplitContainer1 {
            get {
                return ((int)(this["SplitContainer1"]));
            }
            set {
                this["SplitContainer1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("248")]
        public int SplitContainer2 {
            get {
                return ((int)(this["SplitContainer2"]));
            }
            set {
                this["SplitContainer2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int VideoResIndex {
            get {
                return ((int)(this["VideoResIndex"]));
            }
            set {
                this["VideoResIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool VideoImmediateMode {
            get {
                return ((bool)(this["VideoImmediateMode"]));
            }
            set {
                this["VideoImmediateMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool VideoHideLines {
            get {
                return ((bool)(this["VideoHideLines"]));
            }
            set {
                this["VideoHideLines"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::MyNes.PaletteSettings PaletteSettings {
            get {
                return ((global::MyNes.PaletteSettings)(this["PaletteSettings"]));
            }
            set {
                this["PaletteSettings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool VideoFullscreen {
            get {
                return ((bool)(this["VideoFullscreen"]));
            }
            set {
                this["VideoFullscreen"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".png")]
        public string SnapshotFormat {
            get {
                return ((string)(this["SnapshotFormat"]));
            }
            set {
                this["SnapshotFormat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int VideoAdapterIndex {
            get {
                return ((int)(this["VideoAdapterIndex"]));
            }
            set {
                this["VideoAdapterIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int VideoStretchMultiply {
            get {
                return ((int)(this["VideoStretchMultiply"]));
            }
            set {
                this["VideoStretchMultiply"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::MyNes.ColumnWidthsCollection ColumnWidths {
            get {
                return ((global::MyNes.ColumnWidthsCollection)(this["ColumnWidths"]));
            }
            set {
                this["ColumnWidths"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::MyNes.ControlProfilesCollection ControlProfiles {
            get {
                return ((global::MyNes.ControlProfilesCollection)(this["ControlProfiles"]));
            }
            set {
                this["ControlProfiles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection RecentFiles {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["RecentFiles"]));
            }
            set {
                this["RecentFiles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public int SoundLatency {
            get {
                return ((int)(this["SoundLatency"]));
            }
            set {
                this["SoundLatency"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int FilterIndex {
            get {
                return ((int)(this["FilterIndex"]));
            }
            set {
                this["FilterIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection FilterLatestItems {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FilterLatestItems"]));
            }
            set {
                this["FilterLatestItems"] = value;
            }
        }
    }
}

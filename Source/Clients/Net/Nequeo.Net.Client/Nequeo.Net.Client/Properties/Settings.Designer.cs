﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.Net.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("67108864")]
        public long TransferClientMaxReceivedMessageSize {
            get {
                return ((long)(this["TransferClientMaxReceivedMessageSize"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("67108864")]
        public long TransferClientByteMaxReceivedMessageSize {
            get {
                return ((long)(this["TransferClientByteMaxReceivedMessageSize"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("67108864")]
        public long MessageClientMaxReceivedMessageSize {
            get {
                return ((long)(this["MessageClientMaxReceivedMessageSize"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("net.tcp://wcf.nequeo.net.au:8713/ServiceTransfer/Stream/secureBasicWcf")]
        public string TransferClientBaseAddress {
            get {
                return ((string)(this["TransferClientBaseAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("net.tcp://wcf.nequeo.net.au:8718/ServiceTransfer/ByteStream/secureBasicWcf")]
        public string TransferClientByteBaseAddress {
            get {
                return ((string)(this["TransferClientByteBaseAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://wcf.nequeo.net.au/transfer/Stream/StreamHandler.ashx")]
        public string TransferHandlerBaseAddress {
            get {
                return ((string)(this["TransferHandlerBaseAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://wcf.nequeo.net.au/transfer/Stream/StreamQueryHandler.ashx")]
        public string TransferQueryHandlerBaseAddress {
            get {
                return ((string)(this["TransferQueryHandlerBaseAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("net.tcp://wcf.nequeo.net.au:8723/ServiceMessage/Stream/secureBasicWcf")]
        public string MessageClientBaseAddress {
            get {
                return ((string)(this["MessageClientBaseAddress"]));
            }
        }
    }
}
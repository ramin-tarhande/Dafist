﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainApp1 {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Da1Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Da1Settings defaultInstance = ((Da1Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Da1Settings())));
        
        public static Da1Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string RabbitMq_Host {
            get {
                return ((string)(this["RabbitMq_Host"]));
            }
            set {
                this["RabbitMq_Host"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D1Updates")]
        public string RabbitMq_ReceiveExchange {
            get {
                return ((string)(this["RabbitMq_ReceiveExchange"]));
            }
            set {
                this["RabbitMq_ReceiveExchange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ImportantComments")]
        public string RabbitMq_SendExchange {
            get {
                return ((string)(this["RabbitMq_SendExchange"]));
            }
            set {
                this["RabbitMq_SendExchange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Commentm.#")]
        public string RabbitMq_Topic {
            get {
                return ((string)(this["RabbitMq_Topic"]));
            }
            set {
                this["RabbitMq_Topic"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RabbitMq_AutoDeleteQueue {
            get {
                return ((bool)(this["RabbitMq_AutoDeleteQueue"]));
            }
            set {
                this["RabbitMq_AutoDeleteQueue"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MoodThreshold {
            get {
                return ((int)(this["MoodThreshold"]));
            }
            set {
                this["MoodThreshold"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("70")]
        public int AuthorScoreThreshold {
            get {
                return ((int)(this["AuthorScoreThreshold"]));
            }
            set {
                this["AuthorScoreThreshold"] = value;
            }
        }
    }
}

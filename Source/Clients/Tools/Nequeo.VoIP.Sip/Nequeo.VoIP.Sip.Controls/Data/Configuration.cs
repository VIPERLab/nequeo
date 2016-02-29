﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace Nequeo.VoIP.Sip.Data
{
    // 
    // This source code was auto-generated by xsd, Version=4.6.81.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class configuration
    {

        private string accountNameField;

        private string sipHostField;

        private string sipUsernameField;

        private string sipPasswordField;

        private int captureAudioDeviceIndexField;

        private int playbackAudioDeviceIndexField;

        private bool outgoingCallAudioRecordingEnabledField;

        private bool incomingCallAudioRecordingEnabledField;

        private string outgoingCallPathAudioRecordingField;

        private string incomingCallPathAudioRecordingField;

        private string contactFilePathField;

        private int accountPortField;

        private bool accountIsDefaultField;

        private int accountPriorityField;

        private bool accountUseIPv6Field;

        private bool accountUseSrtpField;

        private bool accountSrtpSecureSignalingField;

        private bool accountDropCallsOnFailField;

        private bool accountRegisterOnAddField;

        private bool accountNoIceRtcpField;

        private bool accountIceEnabledField;

        private bool accountAutoAnswerEnabledField;

        private int accountAutoAnswerWaitField;

        private int accountMessageBankWaitField;

        private uint timeRetryIntervalField;

        private uint timeFirstRetryIntervalField;

        private uint timeDelayBeforeRefreshField;

        private uint timeTimeoutField;

        private uint timeUnregisterWaitField;

        private uint timerMinimumSessionField;

        private uint timerSessionExpiresField;

        private bool publishEnabledField;

        private bool publishQueueField;

        private uint publishShutdownWaitField;

        private bool mwiEnabledField;

        private uint mwiExpirationField;

        private uint mediaTransportPortField;

        private uint mediaTransportPortRangeField;

        private int soundAudioDeviceIndexField;

        private string soundIncomingCallFilePathField;

        private string soundInstantMessageFilePathField;

        private string soundAutoAnswerFilePathField;

        private bool codecVideoEnabledField;

        private int codecVideoCaptureDeviceIndexField;

        private int codecVideoRenderDeviceIndexField;

        private bool featureRedirectCallEnabledField;

        private string featureRedirectCallNumberField;

        private int featureRedirectCallAfterField;

        /// <remarks/>
        public string accountName
        {
            get
            {
                return this.accountNameField;
            }
            set
            {
                this.accountNameField = value;
            }
        }

        /// <remarks/>
        public string sipHost
        {
            get
            {
                return this.sipHostField;
            }
            set
            {
                this.sipHostField = value;
            }
        }

        /// <remarks/>
        public string sipUsername
        {
            get
            {
                return this.sipUsernameField;
            }
            set
            {
                this.sipUsernameField = value;
            }
        }

        /// <remarks/>
        public string sipPassword
        {
            get
            {
                return this.sipPasswordField;
            }
            set
            {
                this.sipPasswordField = value;
            }
        }

        /// <remarks/>
        public int captureAudioDeviceIndex
        {
            get
            {
                return this.captureAudioDeviceIndexField;
            }
            set
            {
                this.captureAudioDeviceIndexField = value;
            }
        }

        /// <remarks/>
        public int playbackAudioDeviceIndex
        {
            get
            {
                return this.playbackAudioDeviceIndexField;
            }
            set
            {
                this.playbackAudioDeviceIndexField = value;
            }
        }

        /// <remarks/>
        public bool outgoingCallAudioRecordingEnabled
        {
            get
            {
                return this.outgoingCallAudioRecordingEnabledField;
            }
            set
            {
                this.outgoingCallAudioRecordingEnabledField = value;
            }
        }

        /// <remarks/>
        public bool incomingCallAudioRecordingEnabled
        {
            get
            {
                return this.incomingCallAudioRecordingEnabledField;
            }
            set
            {
                this.incomingCallAudioRecordingEnabledField = value;
            }
        }

        /// <remarks/>
        public string outgoingCallPathAudioRecording
        {
            get
            {
                return this.outgoingCallPathAudioRecordingField;
            }
            set
            {
                this.outgoingCallPathAudioRecordingField = value;
            }
        }

        /// <remarks/>
        public string incomingCallPathAudioRecording
        {
            get
            {
                return this.incomingCallPathAudioRecordingField;
            }
            set
            {
                this.incomingCallPathAudioRecordingField = value;
            }
        }

        /// <remarks/>
        public string contactFilePath
        {
            get
            {
                return this.contactFilePathField;
            }
            set
            {
                this.contactFilePathField = value;
            }
        }

        /// <remarks/>
        public int accountPort
        {
            get
            {
                return this.accountPortField;
            }
            set
            {
                this.accountPortField = value;
            }
        }

        /// <remarks/>
        public bool accountIsDefault
        {
            get
            {
                return this.accountIsDefaultField;
            }
            set
            {
                this.accountIsDefaultField = value;
            }
        }

        /// <remarks/>
        public int accountPriority
        {
            get
            {
                return this.accountPriorityField;
            }
            set
            {
                this.accountPriorityField = value;
            }
        }

        /// <remarks/>
        public bool accountUseIPv6
        {
            get
            {
                return this.accountUseIPv6Field;
            }
            set
            {
                this.accountUseIPv6Field = value;
            }
        }

        /// <remarks/>
        public bool accountUseSrtp
        {
            get
            {
                return this.accountUseSrtpField;
            }
            set
            {
                this.accountUseSrtpField = value;
            }
        }

        /// <remarks/>
        public bool accountSrtpSecureSignaling
        {
            get
            {
                return this.accountSrtpSecureSignalingField;
            }
            set
            {
                this.accountSrtpSecureSignalingField = value;
            }
        }

        /// <remarks/>
        public bool accountDropCallsOnFail
        {
            get
            {
                return this.accountDropCallsOnFailField;
            }
            set
            {
                this.accountDropCallsOnFailField = value;
            }
        }

        /// <remarks/>
        public bool accountRegisterOnAdd
        {
            get
            {
                return this.accountRegisterOnAddField;
            }
            set
            {
                this.accountRegisterOnAddField = value;
            }
        }

        /// <remarks/>
        public bool accountNoIceRtcp
        {
            get
            {
                return this.accountNoIceRtcpField;
            }
            set
            {
                this.accountNoIceRtcpField = value;
            }
        }

        /// <remarks/>
        public bool accountIceEnabled
        {
            get
            {
                return this.accountIceEnabledField;
            }
            set
            {
                this.accountIceEnabledField = value;
            }
        }

        /// <remarks/>
        public bool accountAutoAnswerEnabled
        {
            get
            {
                return this.accountAutoAnswerEnabledField;
            }
            set
            {
                this.accountAutoAnswerEnabledField = value;
            }
        }

        /// <remarks/>
        public int accountAutoAnswerWait
        {
            get
            {
                return this.accountAutoAnswerWaitField;
            }
            set
            {
                this.accountAutoAnswerWaitField = value;
            }
        }

        /// <remarks/>
        public int accountMessageBankWait
        {
            get
            {
                return this.accountMessageBankWaitField;
            }
            set
            {
                this.accountMessageBankWaitField = value;
            }
        }

        /// <remarks/>
        public uint timeRetryInterval
        {
            get
            {
                return this.timeRetryIntervalField;
            }
            set
            {
                this.timeRetryIntervalField = value;
            }
        }

        /// <remarks/>
        public uint timeFirstRetryInterval
        {
            get
            {
                return this.timeFirstRetryIntervalField;
            }
            set
            {
                this.timeFirstRetryIntervalField = value;
            }
        }

        /// <remarks/>
        public uint timeDelayBeforeRefresh
        {
            get
            {
                return this.timeDelayBeforeRefreshField;
            }
            set
            {
                this.timeDelayBeforeRefreshField = value;
            }
        }

        /// <remarks/>
        public uint timeTimeout
        {
            get
            {
                return this.timeTimeoutField;
            }
            set
            {
                this.timeTimeoutField = value;
            }
        }

        /// <remarks/>
        public uint timeUnregisterWait
        {
            get
            {
                return this.timeUnregisterWaitField;
            }
            set
            {
                this.timeUnregisterWaitField = value;
            }
        }

        /// <remarks/>
        public uint timerMinimumSession
        {
            get
            {
                return this.timerMinimumSessionField;
            }
            set
            {
                this.timerMinimumSessionField = value;
            }
        }

        /// <remarks/>
        public uint timerSessionExpires
        {
            get
            {
                return this.timerSessionExpiresField;
            }
            set
            {
                this.timerSessionExpiresField = value;
            }
        }

        /// <remarks/>
        public bool publishEnabled
        {
            get
            {
                return this.publishEnabledField;
            }
            set
            {
                this.publishEnabledField = value;
            }
        }

        /// <remarks/>
        public bool publishQueue
        {
            get
            {
                return this.publishQueueField;
            }
            set
            {
                this.publishQueueField = value;
            }
        }

        /// <remarks/>
        public uint publishShutdownWait
        {
            get
            {
                return this.publishShutdownWaitField;
            }
            set
            {
                this.publishShutdownWaitField = value;
            }
        }

        /// <remarks/>
        public bool mwiEnabled
        {
            get
            {
                return this.mwiEnabledField;
            }
            set
            {
                this.mwiEnabledField = value;
            }
        }

        /// <remarks/>
        public uint mwiExpiration
        {
            get
            {
                return this.mwiExpirationField;
            }
            set
            {
                this.mwiExpirationField = value;
            }
        }

        /// <remarks/>
        public uint mediaTransportPort
        {
            get
            {
                return this.mediaTransportPortField;
            }
            set
            {
                this.mediaTransportPortField = value;
            }
        }

        /// <remarks/>
        public uint mediaTransportPortRange
        {
            get
            {
                return this.mediaTransportPortRangeField;
            }
            set
            {
                this.mediaTransportPortRangeField = value;
            }
        }

        /// <remarks/>
        public int soundAudioDeviceIndex
        {
            get
            {
                return this.soundAudioDeviceIndexField;
            }
            set
            {
                this.soundAudioDeviceIndexField = value;
            }
        }

        /// <remarks/>
        public string soundIncomingCallFilePath
        {
            get
            {
                return this.soundIncomingCallFilePathField;
            }
            set
            {
                this.soundIncomingCallFilePathField = value;
            }
        }

        /// <remarks/>
        public string soundInstantMessageFilePath
        {
            get
            {
                return this.soundInstantMessageFilePathField;
            }
            set
            {
                this.soundInstantMessageFilePathField = value;
            }
        }

        /// <remarks/>
        public string soundAutoAnswerFilePath
        {
            get
            {
                return this.soundAutoAnswerFilePathField;
            }
            set
            {
                this.soundAutoAnswerFilePathField = value;
            }
        }

        /// <remarks/>
        public bool codecVideoEnabled
        {
            get
            {
                return this.codecVideoEnabledField;
            }
            set
            {
                this.codecVideoEnabledField = value;
            }
        }

        /// <remarks/>
        public int codecVideoCaptureDeviceIndex
        {
            get
            {
                return this.codecVideoCaptureDeviceIndexField;
            }
            set
            {
                this.codecVideoCaptureDeviceIndexField = value;
            }
        }

        /// <remarks/>
        public int codecVideoRenderDeviceIndex
        {
            get
            {
                return this.codecVideoRenderDeviceIndexField;
            }
            set
            {
                this.codecVideoRenderDeviceIndexField = value;
            }
        }

        /// <remarks/>
        public bool featureRedirectCallEnabled
        {
            get
            {
                return this.featureRedirectCallEnabledField;
            }
            set
            {
                this.featureRedirectCallEnabledField = value;
            }
        }

        /// <remarks/>
        public string featureRedirectCallNumber
        {
            get
            {
                return this.featureRedirectCallNumberField;
            }
            set
            {
                this.featureRedirectCallNumberField = value;
            }
        }

        /// <remarks/>
        public int featureRedirectCallAfter
        {
            get
            {
                return this.featureRedirectCallAfterField;
            }
            set
            {
                this.featureRedirectCallAfterField = value;
            }
        }
    }
}
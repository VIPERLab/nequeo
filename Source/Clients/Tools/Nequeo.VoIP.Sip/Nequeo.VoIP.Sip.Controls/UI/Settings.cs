﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
 * 
 *  File :          
 *  Purpose :       
 * 
 */

#region Nequeo Pty Ltd License
/*
    Permission is hereby granted, free of charge, to any person
    obtaining a copy of this software and associated documentation
    files (the "Software"), to deal in the Software without
    restriction, including without limitation the rights to use,
    copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the
    Software is furnished to do so, subject to the following
    conditions:

    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nequeo.VoIP.Sip.UI
{
    /// <summary>
    /// Settings.
    /// </summary>
    public partial class Settings : Form
    {
        /// <summary>
        /// Settings.
        /// </summary>
        /// <param name="voipCall">VoIP call.</param>
        public Settings(Nequeo.VoIP.Sip.VoIPCall voipCall)
        {
            InitializeComponent();
            _voipCall = voipCall;
        }

        private Nequeo.VoIP.Sip.VoIPCall _voipCall = null;

        /// <summary>
        /// Load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_Load(object sender, EventArgs e)
        {
            // Get the audio devices.
            Nequeo.Net.Sip.AudioDeviceInfo[] audioDevices = _voipCall.VoIPManager.MediaManager.GetAllAudioDevices();

            // For each audio device
            foreach (Nequeo.Net.Sip.AudioDeviceInfo audieDevice in audioDevices)
            {
                comboBoxAudioCaptureDevice.Items.Add(audieDevice.Name + " | " + audieDevice.Driver);
                comboBoxAudioPlaybackDevice.Items.Add(audieDevice.Name + " | " + audieDevice.Driver);
            }
        }
    }
}
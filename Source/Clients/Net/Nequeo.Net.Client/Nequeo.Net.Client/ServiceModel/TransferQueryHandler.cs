﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2010 http://www.nequeo.com.au/
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
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

using Nequeo.IO.Stream.Extension;

namespace Nequeo.Net.ServiceModel
{
    /// <summary>
    /// Transfer stream handler.
    /// </summary>
    public class TransferQueryHandler
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public TransferQueryHandler()
        {
            // Create a new instance of the async execute handler
            _asyncExecute = new Threading.AsyncExecution<TransferQueryHandler>(this);
            _asyncExecute.AsyncExecuteComplete += new Threading.EventHandler<object, bool, System.Exception>(TransferHandler_AsyncExecuteComplete);

            // Get the reomte URI
            _remoteUri = Nequeo.Net.Properties.Settings.Default.TransferQueryHandlerBaseAddress;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="networkCredential">The user network credential</param>
        public TransferQueryHandler(NetworkCredential networkCredential)
        {
            // Create a new instance of the async execute handler
            _asyncExecute = new Threading.AsyncExecution<TransferQueryHandler>(this);
            _asyncExecute.AsyncExecuteComplete += new Threading.EventHandler<object, bool, System.Exception>(TransferHandler_AsyncExecuteComplete);

            // Get the reomte URI
            _remoteUri = Nequeo.Net.Properties.Settings.Default.TransferQueryHandlerBaseAddress;
            _networkCredential = networkCredential;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="endPointAddress">The endpoint address to connect to.</param>
        /// <param name="networkCredential">The user network credential</param>
        public TransferQueryHandler(string endPointAddress, NetworkCredential networkCredential = null)
        {
            // Create a new instance of the async execute handler
            _asyncExecute = new Threading.AsyncExecution<TransferQueryHandler>(this);
            _asyncExecute.AsyncExecuteComplete += new Threading.EventHandler<object, bool, System.Exception>(TransferHandler_AsyncExecuteComplete);
            
            // Get the reomte URI
            _remoteUri = endPointAddress;
            _networkCredential = networkCredential;
        }

        private Nequeo.Threading.AsyncExecution<TransferQueryHandler> _asyncExecute = null;
        private NetworkCredential _networkCredential = null;

        private System.IO.Stream _localSourceUpload = null;
        private System.IO.Stream _localDestinationDownload = null;
        private FileStream _localSource = null;
        private string _localDestinationPathDownload = string.Empty;

        private System.Net.WebRequest _requestDownload = null;
        private System.Net.WebResponse _responseDownload = null;
        private System.Net.WebRequest _requestUpload = null;
        private System.Net.WebResponse _responseUpload = null;

        private string _remoteUri = null;
        private int _timeout = 30000;

        /// <summary>
        /// Gets or sets the transfer time.
        /// </summary>
        public int Timeout { get { return _timeout; } set { _timeout = value; } }

        /// <summary>
        /// Upload asynchronous complete event handler
        /// </summary>
        public event EventHandler<Nequeo.Custom.AsyncGenericResultArgs<bool>> AsyncUploadComplete;

        /// <summary>
        /// Download asynchronous complete event handler
        /// </summary>
        public event EventHandler<Nequeo.Custom.AsyncGenericResultArgs<bool>> AsyncDownloadComplete;

        /// <summary>
        /// Asynchronous error event handler
        /// </summary>
        public event EventHandler<Nequeo.Custom.AsyncArgs> AsyncError;

        /// <summary>
        /// Async execution complete handler,
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e1">The unique async name reference</param>
        /// <param name="e2">The operation result</param>
        /// <param name="e3">The event argument</param>
        private void TransferHandler_AsyncExecuteComplete(object sender, object e1, bool e2, System.Exception e3)
        {
            try
            {
                // If the e1 is of type string
                if (e1 is string)
                {
                    // Get the e1
                    switch (e1.ToString().ToLower())
                    {
                        case "uploadfile":
                            // Upload the data asynchronously
                            bool uploadResult = _asyncExecute.GetExecuteAsyncResult<bool>(e1.ToString());

                            if (!uploadResult)
                                // A remote stream instance could not be established
                                throw new Exception("A remote upload stream instance could not be established.");
                            else
                                OnAsyncUploadComplete(uploadResult);
                            break;

                        case "downloadfile":
                            // Download the data asynchronously
                            bool downloadResult = _asyncExecute.GetExecuteAsyncResult<bool>(e1.ToString());

                            if (!downloadResult)
                                // A remote stream instance could not be established
                                throw new Exception("A remote download stream instance could not be established.");
                            else
                                OnAsyncDownloadComplete(downloadResult);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Clean-up
                if (_localSource != null)
                    _localSource.Close();

                // Clean-up
                if (_localSourceUpload != null)
                    _localSourceUpload.Close();

                // Clean-up
                if (_responseUpload != null)
                    _responseUpload.Close();

                // Clean-up
                if (_responseDownload != null)
                    _responseDownload.Close();

                // Clean-up
                if (_localDestinationDownload != null)
                    _localDestinationDownload.Close();

                try
                {
                    // Clean-up delete the download local file.
                    File.Delete(_localDestinationPathDownload);
                }
                catch { }

                // Send the error message to the client
                // from the async call.
                if (AsyncError != null)
                    AsyncError(this,
                        new Nequeo.Custom.AsyncArgs(
                            new Nequeo.Exceptions.AsyncException(ex.Message, _asyncExecute.GetExecuteAsyncException(e1.ToString()))));
            }
        }

        /// <summary>
        /// On async upload complete
        /// </summary>
        /// <param name="result">The result of the async operation</param>
        private void OnAsyncUploadComplete(bool result)
        {
            // Clean-up
            if (_localSource != null)
                _localSource.Close();

            // Clean-up
            if (_localSourceUpload != null)
                _localSourceUpload.Close();

            // Send the event to the connected client
            if (AsyncUploadComplete != null)
                AsyncUploadComplete(this, new Custom.AsyncGenericResultArgs<bool>(result));
        }

        /// <summary>
        /// On async download complete
        /// </summary>
        /// <param name="result">The result of the async operation</param>
        private void OnAsyncDownloadComplete(bool result)
        {
            // Clean-up
            if (_responseDownload != null)
                _responseDownload.Close();

            // Clean-up
            if (_localDestinationDownload != null)
                _localDestinationDownload.Close();

            // Send the event to the connected client
            if (AsyncDownloadComplete != null)
                AsyncDownloadComplete(this, new Custom.AsyncGenericResultArgs<bool>(result));
        }

        /// <summary>
        /// Transfer the stream data from the source to the destination.
        /// </summary>
        /// <param name="source">The source stream to read from.</param>
        /// <param name="destination">The destination stream to write to.</param>
        /// <param name="byteLength">The total number of bytes that need to be read 
        /// (must be the same as the number of source bytes). Waits until all bytes are read.</param>
        /// <param name="timeout">The maximum time in milliseconds to wait for the end of the header data; -1 wait Indefinitely.</param>
        /// <returns>True if all data has been copied; else false.</returns>
        private bool TransferData(System.IO.Stream source, System.IO.Stream destination, long byteLength, long timeout = -1)
        {
            return Nequeo.IO.Stream.Operation.CopyStream(source, destination, byteLength, timeout);
        }

        /// <summary>
        /// Upload a file to the remote server.
        /// </summary>
        /// <param name="localSourcePath">The local source file and path to read data from.</param>
        /// <param name="position">The position to start writing from.</param>
        /// <param name="asyncOperation">Should the download be execute asynchronously.</param>
        /// <returns>True if the operation was successful; else false.</returns>
        public bool UploadFile(string localSourcePath, long position = 0, bool asyncOperation = false)
        {
            try
            {
                // If no async operation is requested.
                if (!asyncOperation)
                {
                    // Open the local source file where
                    // the data will be read from.
                    _localSource = new FileStream(localSourcePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

                    // If an upload position exists.
                    if (position > 0)
                        _localSource.Position = position;

                    // Get the source file name
                    string fileName = Path.GetFileName(localSourcePath);
                    string iniPosition = (position > 0 ? "&P=" + position.ToString() : "");

                    // Create a new request
                    _requestUpload = System.Net.WebRequest.Create(new Uri(_remoteUri + "?O=UP&F=" + fileName + "&S=" + _localSource.Length.ToString() + iniPosition));
                    _requestUpload.Method = "POST";
                    _requestUpload.ContentLength = _localSource.Length;
                    _requestUpload.Credentials = _networkCredential;

                    // Transfer the data from the server to the loacl source.
                    // At this point the transfer is initiated. 
                    // Initiate the request, create the communication connection
                    TransferData(_localSource, _requestUpload.GetRequestStream(), _requestUpload.ContentLength, _timeout);

                    // Initiate the request, create the communication connection.
                    _responseUpload = _requestUpload.GetResponse();
                }
                else
                    // Start a new async upload.
                    _asyncExecute.Execute<bool>(u => u.UploadFile(localSourcePath), "UploadFile");

                // return true.
                return true;
            }
            catch (Exception ex)
            {
                // Clean-up
                if (_localSource != null)
                    _localSource.Close();

                // Clean-up
                if (_localSourceUpload != null)
                    _localSourceUpload.Close();

                // Clean-up
                if (_responseUpload != null)
                    _responseUpload.Close();

                if (_asyncExecute.Exception != null)
                    throw new Exception(ex.Message, new Exception(_asyncExecute.Exception.Message));
                else
                    throw ex;
            }
            finally
            {
                // Clean-up
                if (!asyncOperation)
                    if (_localSource != null)
                        _localSource.Close();

                // Clean-up
                if (!asyncOperation)
                    if (_localSourceUpload != null)
                        _localSourceUpload.Close();
            }
        }

        /// <summary>
        /// Download a file from a remote server.
        /// </summary>
        /// <param name="localDestinationPath">The local destination file and path to write data to.</param>
        /// <param name="remoteSourceFilename">The remote source file name to read data from.</param>
        /// <param name="position">The position to start reading from.</param>
        /// <param name="asyncOperation">Should the download be execute asynchronously.</param>
        /// <returns>True if the operation was successful; else false.</returns>
        public bool DownloadFile(string localDestinationPath, string remoteSourceFilename, long position = 0, bool asyncOperation = false)
        {
            try
            {
                _localDestinationPathDownload = localDestinationPath;

                // If no async operation is requested.
                if (!asyncOperation)
                {
                    // Create the local destination file where
                    // the data will be written to.
                    _localDestinationDownload = new FileStream(localDestinationPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

                    // If a download position exists.
                    if (position > 0)
                        _localDestinationDownload.Position = position;

                    // Get the file size
                    long size = GetFileSize(remoteSourceFilename);
                    string iniPosition = (position > 0 ? "&P=" + position.ToString() : "");

                    // Create a new request
                    _requestDownload = System.Net.WebRequest.Create(new Uri(_remoteUri + "?O=DN&F=" + remoteSourceFilename + "&S=" + size.ToString() + iniPosition));
                    _requestDownload.Method = "POST";
                    _requestDownload.ContentLength = 0;
                    _requestDownload.Credentials = _networkCredential;

                    // Initiate the request, create the communication connection
                    _responseDownload = _requestDownload.GetResponse();

                    // Transfer the data from the server to the loacl source.
                    TransferData(_responseDownload.GetResponseStream(), _localDestinationDownload, size, _timeout);

                    // Close the local stream file.
                    _localDestinationDownload.Flush();
                    _localDestinationDownload.Close();

                    // Open the file that was downloaded and determine if
                    // the file contains the corrent text, if the file contains
                    // the error text then delete the file and report the error.
                    _localDestinationDownload = new FileStream(localDestinationPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    TextReader textReader = new StreamReader(_localDestinationDownload);

                    // Get the first line. Does the first line
                    // contin the 'ERROR' text
                    string error = textReader.ReadLine();
                    if (error.StartsWith("ERROR:"))
                    {
                        // Go the the top of the file and
                        // get the complete error text.
                        _localDestinationDownload.Seek(0, SeekOrigin.Begin);
                        error = textReader.ReadToEnd();

                        // Close the stream
                        textReader.Close();
                        _localDestinationDownload.Close();

                        // Throw the current error.
                        throw new Exception(error);
                    }
                }
                else
                    // Start a new async download.
                    _asyncExecute.Execute<bool>(u => u.DownloadFile(localDestinationPath, remoteSourceFilename), "DownloadFile");

                // return true.
                return true;
            }
            catch (Exception ex)
            {
                // Clean-up
                if (_responseDownload != null)
                    _responseDownload.Close();

                // Clean-up
                if (_localDestinationDownload != null)
                    _localDestinationDownload.Close();

                try
                {
                    // Clean-up delete the download local file.
                    File.Delete(_localDestinationPathDownload);
                }
                catch { }

                if (_asyncExecute.Exception != null)
                    throw new Exception(ex.Message, new Exception(_asyncExecute.Exception.Message));
                else
                    throw ex;
            }
            finally
            {
                // Clean-up
                if (!asyncOperation)
                    if (_responseDownload != null)
                        _responseDownload.Close();

                // Clean-up
                if (!asyncOperation)
                    if (_localDestinationDownload != null)
                        _localDestinationDownload.Close();
            }
        }

        /// <summary>
        /// Get the requested file size.
        /// </summary>
        /// <param name="remoteSourceFilename">The remote source file name to read data from.</param>
        /// <returns>The size of the file</returns>
        private long GetFileSize(string remoteSourceFilename)
        {
            System.Net.WebRequest request = null;
            System.Net.WebResponse response = null;

            try
            {
                // Create request.
                request = System.Net.WebRequest.Create(new Uri(_remoteUri + "?O=SZ&F=" + remoteSourceFilename + "&S=0"));
                request.Method = "POST";
                request.ContentLength = 0;
                request.Credentials = _networkCredential;

                // Get the response, initiate the communication
                response = request.GetResponse();

                // Get the response data from the stream
                byte[] data = new byte[response.ContentLength];
                int ret = response.GetResponseStream().Read(data, 0, (int)response.ContentLength);

                // If data has been returned
                if (ret > -1)
                    return Convert.ToInt64(Encoding.UTF8.GetString(data));
                else
                    return (-1);
            }
            catch (Exception)
            {
                return (-1);
            }
            finally
            {
                // Clean-up
                if (response != null)
                    response.Close();
            }
        }
    }
}

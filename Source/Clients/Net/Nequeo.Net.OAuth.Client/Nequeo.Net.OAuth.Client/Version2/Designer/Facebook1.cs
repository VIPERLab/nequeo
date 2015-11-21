﻿// Warning 169 (Disables the 'Never used' warning)
#pragma warning disable 169
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.Net.OAuth.Client.Version2
{
    using System;
    using System.Text;
    using System.Data;
    using System.Threading;
    using System.Diagnostics;
    using System.Data.SqlClient;
    using System.Data.OleDb;
    using System.Data.Odbc;
    using System.Collections;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    
    #region Facebook Extension Type
    /// <summary>
    /// The Facebook object class.
    /// </summary>
    public partial class Facebook
    {
        private Exception _exception = null;
		private FacebookThread _threadFacebookContext = null;

		/// <summary>
        /// Gets the current async exception; else null;
        /// </summary>
        public Exception ExceptionFacebook
        {
            get { return _exception; }
        }

		/// <summary>
        /// Gets the Facebook threading context.
        /// </summary>
        public FacebookThread FacebookThreadContext
        {
            get { return _threadFacebookContext; }
        }

		/// <summary>
        /// On create.
        /// </summary>
        partial void OnCreated();

		/// <summary>
        /// On create instance of Facebook
        /// </summary>
		partial void OnCreated()
		{
			// Start the async control.
			_threadFacebookContext = new FacebookThread(this);
			_threadFacebookContext.AsyncError += new Threading.EventHandler<Exception>(_asyncAccount_AsyncError);
		}

		/// <summary>
        /// Async error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e1"></param>
        private void _asyncAccount_AsyncError(object sender, Exception e1)
        {
            _exception = e1;
        }

		/// <summary>
        /// Facebook threading handler.
        /// </summary>
        public class FacebookThread : Nequeo.Threading.AsyncExecutionHandler<Facebook>
        {
            /// <summary>
            /// Facebook threading handler.
            /// </summary>
            /// <param name="service">The Facebook type.</param>
            public FacebookThread(Facebook service)
                : base(service) { }
        }
    }
    #endregion
}

#pragma warning restore 169
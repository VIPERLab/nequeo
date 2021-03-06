﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.488
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.Wpf.NequeoCompany.Controls
{
	using System;

	using Nequeo.Threading;

	/// <summary>
	/// The AsyncAsset class.
	/// </summary>
	public partial class AsyncAsset
	{
    
		private Nequeo.Threading.AsyncExecution<Nequeo.Wpf.NequeoCompany.Controls.Asset> _asyncExecuteAsset = null;
    
		/// <summary>
		/// Default constructor.
		/// </summary>
		public AsyncAsset()
		{
		}
    
		/// <summary>
		/// Async error event handler
		/// </summary>
		public event Nequeo.Threading.EventHandler<System.Exception> AsyncError;
    
		/// <summary>
		/// Async complete event handler, with result and unique execution name
		/// </summary>
		public event Nequeo.Threading.EventHandler<System.Object, System.String> AsyncComplete;
    
		/// <summary>
		/// Initilise Async Instance
		/// </summary>
		/// <param name="instance">The type instance.</param>
		public virtual void InitiliseAsyncInstance(Nequeo.Wpf.NequeoCompany.Controls.Asset instance)
		{
			if (instance == null) throw new ArgumentNullException("instance");
			_asyncExecuteAsset = new Nequeo.Threading.AsyncExecution<Nequeo.Wpf.NequeoCompany.Controls.Asset>(instance);
			_asyncExecuteAsset.AsyncExecuteComplete += new Nequeo.Threading.EventHandler<object, bool, System.Exception>(AsyncHandler_AsyncExecuteComplete);
		}
    
		/// <summary>
		/// Execute the asynchronous action.
		/// </summary>
		/// <param name="action">The action handler.</param>
		/// <param name="actionName">The unique action name.</param>
		public virtual void Execute(System.Action<Nequeo.Wpf.NequeoCompany.Controls.Asset> action, string actionName)
		{
			if (action == null) throw new ArgumentNullException("action");
			if (String.IsNullOrEmpty(actionName)) throw new ArgumentNullException("actionName");
			_asyncExecuteAsset.Execute(action, actionName);
		}
    
		/// <summary>
		/// Execute the asynchronous action.
		/// </summary>
		/// <param name="action">The action handler.</param>
		/// <param name="actionName">The unique action name.</param>
		public virtual void Execute<TResult>(System.Func<Nequeo.Wpf.NequeoCompany.Controls.Asset, TResult> action, string actionName)
		{
			if (action == null) throw new ArgumentNullException("action");
			if (String.IsNullOrEmpty(actionName)) throw new ArgumentNullException("actionName");
			_asyncExecuteAsset.Execute<TResult>(action, actionName);
		}
    
		/// <summary>
		/// Asynchronous Execution Complete
		/// </summary>
		/// <param name="sender">The event sender.</param>
		/// <param name="e1">The unique async name reference.</param>
		/// <param name="e2">The operation result.</param>
		/// <param name="e3">The current async exception.</param>
		private void AsyncHandler_AsyncExecuteComplete(object sender, object e1, bool e2, System.Exception e3)
		{
			try
			{
				if (e1 is string)
				{
					object result = _asyncExecuteAsset.GetExecuteAsyncResult<object>(e1.ToString());
					if (AsyncComplete != null)
					{
						AsyncComplete(this, result, e1.ToString());
					}
				}
			}
			catch (System.Exception ex)
			{
				if (AsyncError != null)
				{
					AsyncError(this, new System.Exception(ex.Message, _asyncExecuteAsset.GetExecuteAsyncException(e1.ToString())));
				}
			}
		}
	}
}

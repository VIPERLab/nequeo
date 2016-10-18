/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
*
*  File :          FileCloudClient.h
*  Purpose :       Cloud client provider class.
*
*/

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

#pragma once

#include "stdafx.h"

#include "Global.h"
#include "AzureAccount.h"

#include <was\file.h>

namespace Nequeo {
	namespace Azure {
		namespace Storage
		{
			///	<summary>
			///	Cloud client provider.
			///	</summary>
			class EXPORT_NEQUEO_AZURE_STORAGE_API FileCloudClient
			{
			public:
				///	<summary>
				///	Cloud client provider.
				///	</summary>
				/// <param name="account">The Azure account.</param>
				FileCloudClient(const AzureAccount& account);

				///	<summary>
				///	Cloud client provider destructor.
				///	</summary>
				~FileCloudClient();

				/// <summary>
				/// Has the client been initialised.
				/// </summary>
				/// <returns>True if is initialised; else false.</returns>
				inline bool IsInitialised() const
				{
					return _isInitialised;
				}

				///	<summary>
				///	Get the file client.
				///	</summary>
				/// <returns>The file client.</returns>
				const azure::storage::cloud_file_client& FileClient() const;

				///	<summary>
				///	Initialise the File client.
				///	</summary>
				void Initialise();

				///	<summary>
				///	Initialise the File client.
				///	</summary>
				/// <param name="default_request_options">Default file request options.</param>
				void Initialise(const azure::storage::file_request_options& default_request_options);

			private:
				bool _disposed;
				bool _isInitialised;

				AzureAccount _account;
				azure::storage::cloud_file_client _client;
			};
		}
	}
}
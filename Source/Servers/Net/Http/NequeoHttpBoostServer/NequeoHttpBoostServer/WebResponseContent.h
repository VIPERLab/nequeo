/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
*
*  File :          WebResponseContent.h
*  Purpose :       Http web response content class.
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

namespace Nequeo {
	namespace Net {
		namespace Http
		{
			/// <summary>
			/// Http web response content.
			/// </summary>
			class EXPORT_NEQUEO_NET_BOOST_SERVER_API WebResponseContent
			{
			public:
				/// <summary>
				/// Http web response content.
				/// </summary>
				WebResponseContent() : _protocolVersion("HTTP/1.1"), _statusDescription("OK"), _statusCode(200), _statusSubCode(0) {}

				/// <summary>
				/// Http web response content.
				/// </summary>
				~WebResponseContent() {}

				///	<summary>
				///	Add a new header or assign the value to existing key.
				///	</summary>
				/// <param name="key">The header key.</param>
				/// <param name="value">The header value.</param>
				void AddHeader(const std::string& key, const std::string& value);

				/// <summary>
				/// Get the headers.
				/// </summary>
				/// <return>The headers.</return>
				inline std::map<std::string, std::string>& GetHeaders()
				{
					return _headers;
				}

				/// <summary>
				/// Get the protocol version.
				/// </summary>
				/// <return>The protocol version.</return>
				inline std::string GetProtocolVersion() const
				{
					return _protocolVersion;
				}

				/// <summary>
				/// Set the protocol version.
				/// </summary>
				/// <param name="protocolVersion">The protocol version.</param>
				inline void SetProtocolVersion(std::string protocolVersion)
				{
					_protocolVersion = protocolVersion;
				}

				/// <summary>
				/// Get the status description.
				/// </summary>
				/// <return>The status description.</return>
				inline std::string GetStatusDescription() const
				{
					return _statusDescription;
				}

				/// <summary>
				/// Set the status description.
				/// </summary>
				/// <param name="statusDescription">The status description.</param>
				inline void SetStatusDescription(std::string statusDescription)
				{
					_statusDescription = statusDescription;
				}

				/// <summary>
				/// Get the status code.
				/// </summary>
				/// <return>The status code.</return>
				inline int GetStatusCode() const
				{
					return _statusCode;
				}

				/// <summary>
				/// Set the status code.
				/// </summary>
				/// <param name="statusCode">The status code.</param>
				inline void SetStatusCode(int statusCode)
				{
					_statusCode = statusCode;
				}

				/// <summary>
				/// Get the status code.
				/// </summary>
				/// <return>The status code.</return>
				inline int GetStatusSubCode() const
				{
					return _statusSubCode;
				}

				/// <summary>
				/// Set the status code.
				/// </summary>
				/// <param name="statusSubCode">The status code.</param>
				inline void SetStatusSubCode(int statusSubCode)
				{
					_statusSubCode = statusSubCode;
				}

				/// <summary>
				/// Get the content length.
				/// </summary>
				/// <return>The content length.</return>
				inline unsigned long long GetContentLength() const
				{
					return _contentLength;
				}

				/// <summary>
				/// Set the content length.
				/// </summary>
				/// <param name="contentLength">The content length.</param>
				inline void SetContentLength(unsigned long long contentLength)
				{
					_contentLength = contentLength;
				}

				/// <summary>
				/// Get the content type.
				/// </summary>
				/// <return>The content type.</return>
				inline std::string GetContentType() const
				{
					return _contentType;
				}

				/// <summary>
				/// Set the content type.
				/// </summary>
				/// <param name="contentType">The content type.</param>
				inline void SetContentType(std::string contentType)
				{
					_contentType = contentType;
				}

				/// <summary>
				/// Get the content encoding.
				/// </summary>
				/// <return>The content encoding.</return>
				inline std::string GetContentEncoding() const
				{
					return _contentEncoding;
				}

				/// <summary>
				/// Set the content encoding.
				/// </summary>
				/// <param name="contentEncoding">The content encoding.</param>
				inline void SetContentEncoding(std::string contentEncoding)
				{
					_contentEncoding = contentEncoding;
				}

			private:
				std::map<std::string, std::string> _headers;
				std::string _protocolVersion;
				std::string _statusDescription;
				int _statusCode;
				int _statusSubCode;
				unsigned long long _contentLength;
				std::string _contentType;
				std::string _contentEncoding;
			};
		}
	}
}
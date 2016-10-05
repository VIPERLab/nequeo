/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
*
*  File :          ElasticBeanstalkCloudAccount.cpp
*  Purpose :       Elastic Beanstalk Cloud account provider class.
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

#include "stdafx.h"

#include "ElasticBeanstalkCloudAccount.h"

using namespace Nequeo::AWS::Services;

static const char* ELASTICBEANSTALK_CLIENT_TAG = "NequeoElasticBeanstalkClient";

///	<summary>
///	Cloud account provider.
///	</summary>
/// <param name="account">The AWS services account.</param>
ElasticBeanstalkCloudAccount::ElasticBeanstalkCloudAccount(const AwsAccount& account) : _disposed(false), _account(account)
{
	// Create the client.
	_client = Aws::MakeUnique<Aws::ElasticBeanstalk::ElasticBeanstalkClient>(ELASTICBEANSTALK_CLIENT_TAG, _account._credentials, _account._clientConfiguration);
}

///	<summary>
///	Cloud account provider.
///	</summary>
ElasticBeanstalkCloudAccount::~ElasticBeanstalkCloudAccount()
{
	if (!_disposed)
	{
		_disposed = true;
	}
}

/// <summary>
/// Gets the Elastic Beanstalk client.
/// </summary>
/// <return>The Elastic Beanstalk client.</return>
const Aws::ElasticBeanstalk::ElasticBeanstalkClient& ElasticBeanstalkCloudAccount::GetClient() const
{
	return *(_client.get());
}

///	<summary>
///	Get the service URI.
///	</summary>
///	<return>The service URI.</return>
std::string ElasticBeanstalkCloudAccount::GetServiceUri()
{
	return std::string(Aws::ElasticBeanstalk::ElasticBeanstalkEndpoint::ForRegion(_account._clientConfiguration.region).c_str());
}
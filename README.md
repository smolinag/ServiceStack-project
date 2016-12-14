# ServiceStack-project
Dummy servicestack project, with a .net client and a java client


<center><img src="https://github.com/smolinag/ServiceStack-project/blob/master/images/readme.png" width="600"></center>

##Server configuration
The web developer tools of VS allow to create a [IIS express server](https://www.iis.net/learn/extensions/introduction-to-iis-express/iis-express-overview). Following are the steps to create Servicestack server in VS2015 and expose it to extern URL. See this [link](http://johan.driessen.se/posts/Accessing-an-IIS-Express-site-from-a-remote-computer) for more information.


1. If no installed, install VS2015 web developer tools. Go to control panel / programs and features / VS2015 -> modify/ select to install web developer tools (2-3gb aprox)

2. Install Servicestack extension. In VS go to tools / Extensions and updates / search for Servicestack and install.

3. Expose IIS express server to extern URL:

  1. Bind application to public IP address. In the project folder go to vs (hidden folder)/config/ open applicationhost.config
  
  2. In  &lt;bindings> for the current solution add a new binding with the public ip and the port
  
  3. Allow incoming connections to the port. Open cmd as administrator and run: netsh http add urlacl url=http://&lt;ip>:&lt;port>/  user=everyone
  
  4. Set firewall excpetion to port. Open cmd as administrator and run: netsh advfirewall firewall add rule name="IISExpressWeb" dir=in protocol=tcp localport=&lt;port> profile=private remoteip=localsubnet action=allow

##.Net Client configuration

1.  install the NuGet package ServiceStack.Client in your client project, e.g. with the following command in the package manager console:<br>
    `PM> Install-Package ServiceStack.Client`
2.  Create client via:
<br>
        `static string uri = "http://&lt;ip>:&lt;port>";`
<br>
        `static JsonServiceClient client = new JsonServiceClient(uri);`
        
##Java Client configuration
There is a Java client API [here](https://github.com/ServiceStack/ServiceStack.Java), which can be easily integrated with IntelliJ, Eclipse and Android Studio. For IDEs like NetBeans where the API is not supported, the following external jars must be included in the project:

1.  the ServiceStack java Client provided here. Currently, it is used the version 1.0.2.7.
2.  Also, ServiceStack employs Gson to parse Json. That jar can be download here Currently, it is used the version 2.8.0.
3.  Finally, to get the DTOs, use eclipse servicestack API.



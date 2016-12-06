# ServiceStack-project
Dummy servicestack project, with a .net client and a java client


<center><img src="https://github.com/smolinag/ServiceStack-project/blob/master/images/readme.png" width="600"></center><br>

##Server configuration
The web developer tools of VS allow to create a IIS express server. Following are the steps to create Servicestack server in VS2015 and expose it to extern URL. 


1. If no installed, install VS2015 web developer tools. Go to control panel / programs and features / VS2015 -> modify/ select to install web developer tools (2-3gb aprox)

2. Install Servicestack extension. In VS go to tools / Extensions and updates / search for Servicestack and install.

3. Expose IIS express server to extern URL:

  1. Bind application to public IP address. In the project folder go to vs (hidden folder)/config/ open applicationhost.config
  
  2. In <bindings> for the current solution add a new binding with the public ip and the port
  
  3. Allow incoming connections to the port. Open cmd as administrator and run: netsh http add urlacl url=http://<ip>:<port>/ user=everyone
  
  4. Set firewall excpetion to port. Open cmd as administrator and run: netsh advfirewall firewall add rule name="IISExpressWeb" dir=in protocol=tcp localport=<port> profile=private remoteip=localsubnet action=allow




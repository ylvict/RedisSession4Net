# RedisSession4Net

A demo for use redis as Session for ASP.NET web application

## Installation

## Dependence
* Require "Microsoft.AspNet.Mvc" by (```Install-Package Microsoft.AspNet.Mvc```)
* Require "Microsoft.AspNet.WebApi" by (```Install-Package Microsoft.AspNet.WebApi```)
* Require "ServiceStack.Redis" by (```Install-Package ServiceStack.Redis```)

## Usage
1.  Add "RedisSession4Net.Core.dll" reference to your ASP.NET web project.
2.  In Web.Config add RedisConfig section as below:
```xml
  <configSections>
    <section name="RedisConfig" type="RedisSession4Net.Core.Cache.RedisConfig" />
  </configSections>
```

3.	Before the end or 'configuration' section in Web.config, add your redis service info as below:
```xml
  <RedisConfig 
  	ReadWriteServerStr="127.0.0.1:6379" 
    ReadOnlyServerStr="127.0.0.1:6379" 
    LocalCacheTime="1800" />
```

* Note: if your redis service require password authentication, just set ```ReadWriteServerStr``` \ ```ReadOnlyServerStr``` as  ```password@host:6379```.
  
4.	Add a ```SessionModel``` class as [demo](demo/RedisSession4Net.Web/Models/SessionModel.cs).
5.	Make your WebApi Controller inherit ```RedisSession4Net.Core.Components.BaseApiController```, and use ```SessionModel```(in Step:#4) as generic base type.
6.	Now, you can use redis as session for WebApi as below:
```c#
this.Session.SampleString += id.ToString() + ";";
```

## Contributing

## History

## Credits

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

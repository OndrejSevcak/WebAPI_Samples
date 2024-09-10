.NET 6 WebAPI project with implemented BackgroudService that can be started and stopped and also the Execution of the contained service can be enabled or disabled. 

<b>BackgroundService</b> in ASP.NET CORE API is base class that enables you to implement long-running background tasks.
When you inherit from this base class, you need implement <b>ExecuteAsync()</b> method, which will contain your logic to be executed in the background task.

<b>ExecuteAsync()</b> is called when the application starts, or when the Background service is started manually by StartAsync() method.

BackgroundService is registered to DI in Program.cs as a <b>Hostedservice</b> 
<code>
  builder.Services.AddHostedService(provider => provider.GetRequiredService<MyCustomBackgroundService>());
</code>

Swagger:
<img width="1108" alt="image" src="https://user-images.githubusercontent.com/103595589/230391892-2e1ac140-de69-4b30-9b5b-d14b056f2156.png">

So the API can have 4 states:
<ul>
  <li>Backround service is running, but the execution of contained service is disabled</li>
  <li>Backround service is running and execution of contained service is enabled</li>
  <li>Backround service is not running</li>
</ul>

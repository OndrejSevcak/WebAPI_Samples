.NET 6 WebAPI project with implemented BackgroudService that can be started and stopped and also the Execution of the contained service can be enabled or disabled. 
<img width="1108" alt="image" src="https://user-images.githubusercontent.com/103595589/230391892-2e1ac140-de69-4b30-9b5b-d14b056f2156.png">

So the API can have 4 states:
<ul>
  <li>Backround service is running, but the execution of contained service is disabled</li>
  <li>Backround service is running and execution of contained service is enabled</li>
  <li>Backround service is stopped using StopAsync()</li>
  <li>Backround service is started using StartAsync()</li>
</ul>

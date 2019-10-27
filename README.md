CacheAspect class allows to cache your return data. You can use only at 10 class of same project because of Postsharp licence.
you can see  results of  Sql Server and Redis Cache at below lines.

Redis Result<br>
Request Count:200 <br>
Average:<b>38ms</b><br>

Sql Result<br>
Request Count:200<br>
Average:<b>290ms</b><br>

If your data is not changed frequently ,you can use this method. Even if your data is changed ,maybe you must trace some 
change events and change your redis data.

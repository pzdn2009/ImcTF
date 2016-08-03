# ImcTF

## 1.ImcTF是什么？

　　**Imc** , the company.

　　**TF** , the Timer Framework.

　　ImcTF基于Quartz.net，Log4net，Common.Logging，MQ,Autofac等的一个Window Service定时框架。

　　更多架构信息[见此处](https://github.com/pzdn2009/ImcTF/blob/master/ImcTF%20architecture.md)。

## 2.ImcTF能做什么？

### 2.1 以往我们都在烦恼什么？


- 管理Window服务，安装，卸载，停止，覆盖程序集，不断循环......

- 新做了功能，怎么设置定时,要求每天每小时的5分和35分各跑一次，Timer + Thread？

- 我怎么才能方便地记录各个用户，各个级别的日志呢？

- 我的服务运行到什么程度了？


### 2.2 ImcTF的能力

　1.Window服务的管理
   
  ![None](/doc/images/01windowservicestart.png) 

　2.多Jobs

  ![None](/doc/images/02MutilBusinessService.png)

　3.多用户，多级别日志

![None](/doc/images/03Log1.png)

ImcTFSample文件夹：

![None](/doc/images/03Log2.png)

　4.基于wcf双工的客户端管理

![None](/doc/images/04Client.png)

　5.实时进度通知

![None](/doc/images/05ProgressInfo.png)

　6.隔离域作业（Isolated AppDomain Job），不用重启服务即可更新程序

![None](/doc/images/06IsJobs.png)


## 3.怎么使用？
 
 
安装核心服务：

```
Install-Package ImcFramework.Core
```

安装Window服务库：

```
Install-Package ImcFramework.WinServiceLib
```

安装Winform

```
Install-Package ImcFramework.Winform
```

更多，[详见](https://github.com/pzdn2009/ImcTF/blob/master/Getting%20Start.md)


## 4.其他

 
  感谢jel开放的精神，可以将此代码开源，我作为一个拿来主义者，也希望以此作为一个开始，奉献自己的一点点力。

  感谢Kong.Wang，给出了代码中的一些意见，在我能力范围外需要更多人的精华。

  感谢Kris.Dai，提供的一些服务空间能力，虽然还在完善中。

  最终，还是感谢自己如此热爱，一人不断地提交100+次，虽然大部分都是重构，但不断逼近目标的feel还是不错的！
  
  QQ群：564815549，另外，希望把此框架做得越来越强大，让更多的人受益。


## 5.当前版本

code version：1.1.0.5

nuget version: 1.1.0.4


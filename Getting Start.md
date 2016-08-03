#Getting Start

#1.	项目结构


我们约定三层，以以下项目为例（Newegg为一个电商平台，这里演示其Api对接）

Eg：

 ![None](/doc/gettingstart/01project.png)

##Newegg层

放置核心的业务逻辑（本项目中主要是Api的相关业务），为一个类库项目。

##Newegg.WinService层

建立一个WinService项目，承载核心业务的运行

##Newegg.Winform层

建立一个窗体项目，客户端管理
 
#2.	安装(或升级)

## 2.1 Newegg

###2.1.1 安装

```
Install-Package ImcFramework.Core
```

 ![None](/doc/gettingstart/02installnewegg.jpg)


**确保**此处的安装为特定的版本

Log4Net1213 :Version3.3.1
log4net :Version2.0.3
 
![None](/doc/gettingstart/03ensureversion.png)


如果不是，则需要重新安装；否则，会引起版本冲突。

**写业务服务:**

Eg:

![None](/doc/gettingstart/10samplecode.png)

### 2.1.2升级

如果是升级，则直接执行这条命令

```
Update-Package ImcFramework.Core
```

## 2.2 Newegg.WinService

### 2.2.1 安装

```
Install-Package ImcFramework.WinServiceLib
```

执行了命令之后，按照一下步骤操作：


**1)** 添加安装程序，生成ProjectInstall类。
   
   ![None](/doc/gettingstart/04AddInstaller.png)

**2)** 删除Service1
  
   ![None](/doc/gettingstart/05DeleteService.png)

**3)** 修改ProjectInstall

```
namespace Newegg.WinService
{
    [RunInstaller(true)]
    public class ProjectInstaller : ImcFramework.WinServiceLib.ImcSvcInstallerBase
    {
        protected override string GetSerivceName()
        {
            return "Newegg.WinService";
        }

        protected override string GetDescription()
        {
            return "Newegg Window 服务";
        }

        protected override System.ServiceProcess.ServiceStartMode GetServiceStartMode()
        {
            return System.ServiceProcess.ServiceStartMode.Automatic;
        }
    }
}
```


**4)** 修改Program
 
```
namespace Newegg.WinService
{
    static class Program
    {
        static void Main()
        {
            ImcFramework.WinServiceLib.WinServiceRunHelper.**RunImcFrameworkWinService**();
        }
    }
}

```
 
### 2.2.2 升级

```
Update-Package ImcFramework.WinServiceLib
```


## 2.3 Newegg.Winform

### 2.3.1 安装

```
Install-Package ImcFramework.Winform
```
 
修改Program

```
namespace Newegg.Winform
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ImcFramework.Winform.WinformRunHelper.Run();
        }
    }
}
```


### 2.3.2 升级

Update-Package ImcFramework.Winform



## 3.配置程序
## 3.1 Newegg.Winform

**1）** 如图，去掉后缀：_Sample。

![None](/doc/gettingstart/06WinformConfig.png)


**2）**修改复制选项WinService.xml
 
 ![None](/doc/gettingstart/07configcopy.png)

**3）**配置

 ![None](/doc/gettingstart/08config.png)
 

## 3.2 Newegg.WinService

同上一个步骤，去掉项目中的后缀_Sample，并且设置quartz_jobs.xml，始终复制（也可以改为较新复制，按需设置）。

**1)**配置App.Config：

```
<add key="IsIsolatedJob" value="true" />
```

同时需要安装Msmq，在Window程序处安装。

wcf:

```
	<services>
      <!--服务-->
      <service name="ImcFramework.Core.ClientConnectorReal">
        <endpoint address="" binding="wsDualHttpBinding" bindingConfiguration="NoneSecurity" contract="ImcFramework.WcfInterface.IClientConnector">
          <identity>
            <dns value="localhost" />
          </identity>
        </endpoint>
        <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
        <host>
          <baseAddresses>
            <add baseAddress="http://localhost:18913/Imcframework/connector/" />
          </baseAddresses>
        </host>
      </service>
    </services>
```


**2)**配置quartz.config的基础信息

片段
```
# export this server to remoting context
quartz.scheduler.exporter.type = Quartz.Simpl.RemotingSchedulerExporter, Quartz
quartz.scheduler.exporter.port = 1888
quartz.scheduler.exporter.bindName = QuartzScheduler
quartz.scheduler.exporter.channelType = tcp
quartz.scheduler.exporter.channelName = httpQuartz
```
 

**3）**在quartz_jobs.xml中配置服务。

![None](/doc/gettingstart/09Quartzjob.png)


#4.	运行

将Newegg所需的程序集全部拷贝到Newegg.WinService的Debug目录下，

启动Winform，

安装Newegg.WinService。


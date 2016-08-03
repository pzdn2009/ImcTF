
#ImcTF 架构


#1. 结构组成

##1.1 开源组件

log4net——记录日志

Quart.net——定时

Autofac——IOC容器

##1.2 内部组件

LogPool——多用户日志池

ProgressInfo——进度管理

Wcf ——通信基础

#2.设计思想

## 2.1 模块化组织

核心：模块化设计思想，来源为Abp模块化思想。

内部模块：

WcfService Module： 提供wcf相关的功能。

Quartz Module：提供 Quartz相关的功能。

MutilUserProgress Module：提供进度管理功能。

MQ Module ： 用于消息交换。

## 2.2 模块化扩展

如果需要实现一个新的模块，继承ServiceModuleBase，并实现IModuleExtension即可。
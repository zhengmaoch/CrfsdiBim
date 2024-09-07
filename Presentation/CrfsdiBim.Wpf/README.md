# CrfsdiBim

该项目是一个基于.net Framework 4.8的CAD二次开发单机版WPF Mvvm项目
该项目需要通过SQLite模版数据库来初始化项目，同时多项目之间可以通过模版数据库共享数据参数

# 技术
##### Mvvm框架：CommunityToolkit.Mvvm
##### 依赖注入：Microsoft.Extensions.DependencyInjection
##### 数据访问：EF6.0 + SQLite CodeFirst + AutoMapper
##### UI组件：HandyControl
##### 依赖注入：Microsoft.Extensions.Hosting
##### 日志：Serilog
##### AutoCAD: IFoxCAD.Cad

# EF CordFirst
Enable-Migrations
Add-Migration AddTable
Update-Database
使用方式：

1、在需要自动编译Git版本号的项目添加一个guid.txt, 内容为该COM组件的GUID
2、在项目的生成前事件命令行添加如下内容：
```
powershell -ExecutionPolicy ByPass -File "$(SolutionDir)\tools\BuildScripts\InjectGitVersion.ps1" "$(SolutionDir)\tools\BuildScripts" "$(ProjectDir)" "$(TargetName)"
```
2、需要更新版本号的时候，使用```git tag x.y.z```打标签，x,y,z分别为纯数字，例如git tag 1.2.3
则编译文件的时候会自动添加版本号x.y.z.c 其中c为当前提交距离上一个版本号的提交数
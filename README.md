# AliceToolsGui
The GUI Client for alice-tools.

用于 [alice-tools](https://github.com/nunuhara/alice-tools) 的 GUI 客户端。

最新版：[1.1.0](https://github.com/differentrain/AliceToolsGui/releases/download/1.1.0/AliceToolsGui1.1.0.zip)

**注：`1.0.5` 之前的版本有自动更新的BUG，本体无法自动更新，需要手动下载。**

## 使用说明

解压缩后将 `AliceToolsGui.exe` 放到 [alice-tools](https://github.com/nunuhara/alice-tools) 的目录下运行即可。

也可以如下图所示，放在文件夹中直接点击“更新”，此客户端将自行下载最新版本的 [alice-tools](https://github.com/nunuhara/alice-tools)。

![ScreenShot](https://raw.githubusercontent.com/differentrain/AliceToolsGui/main/Resources/ScreenShot.png)

[alice-tools](https://github.com/nunuhara/alice-tools) 提供的功能和选项很多，但我实在懒得写GUI，所以这里酌情的尽情了删减。

目前仅支持 `Ain`, `Ex`, `Acx`, `Afa`, `Ald`的基本操作，比如提取和打包是都加上了，只是选项有限。

不过作为强迫症，我完整的做好了 [alice-tools](https://github.com/nunuhara/alice-tools) 的C#封装，如果有烈士想要接手，可以直接拿来用。

具体的说明可以参考 [此文档](https://github.com/differentrain/AliceToolsProxies/blob/master/docs/AliceToolsProxies/AliceToolsProxy.md)。

## 注意事项

### 通用

使用 [alice-tools](https://github.com/nunuhara/alice-tools)，编码很重要。

遇到问题，90%都是输入/输出的编码选择不对，多切换试试就好了。

另外 [alice-tools](https://github.com/nunuhara/alice-tools) 目前不支持中文路径，应该使用英文(ASCII)路径。

### 打包档案用的清单文件

首先文件编码要搞好，与设置的输入选项相一致。注意不要带BOM头，也就是说windows自带的记事本是不推荐的。

然后文件整体是不支持空格的，当然路径中有空格是可以，但其他位置出现空格会导致解析问题。

最后，[alice-tools](https://github.com/nunuhara/alice-tools) 对于清单文件的解析是以且只以`CRLF`为标识，**也就是说，最后一行的结尾也要按一次回车**，否则还是报错。

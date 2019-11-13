# CodeStandard
用ReSharper配置的C#代码规范

## 通用的C#配置
### Naming Style
### Formatting Style
### Code Style
### Code Inspection

## Unity3D的C#配置
### 错误的警告
* 经过if(o)判断的对象还是会提示Possible NullException
* Start()/Update()等方法会提示Method xxx never used
* OnGUI()等方法会提示不符合命名规范
### 错误的标记
* MonoBehavior会提示Class xxx never used
* 一些拼写错误, 如coroutine

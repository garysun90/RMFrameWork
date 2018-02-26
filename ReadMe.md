Utility 是所有工具类集合
    包括以下工具：
	文件类 
	加密 
	序列化类
	缓存类 
	WCF类 
	IOC封装类 
	反射类
	克隆类
	win32帮助类
	日志帮助类
	热键 
	注册表 
	解压缩
	网络
	sql帮助类
		  
Utility<T>包括
		相等比较
		大小比较

CurrentData 是当前系统的一些基本信息 包括人员信息，版本号等等。
ExtensionMethod 是为一些密封类提供的一些扩展方法。
		

		#具体用法
		1.Core是接口和定义，Kernel是具体的实现，Core通过反射kernel实例化接口。
		实例化方式参照Utility的File属性。
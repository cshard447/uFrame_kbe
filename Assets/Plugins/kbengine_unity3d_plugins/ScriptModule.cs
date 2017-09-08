﻿namespace KBEngine
{
  	using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	using System.Reflection;

	/*
		一个entitydef中定义的脚本模块的描述类
		包含了某个entity定义的属性与方法以及该entity脚本模块的名称与模块ID
	*/
    public class ScriptModule
    {
		public string name;
		public bool usePropertyDescrAlias;
		public bool useMethodDescrAlias;
		
		public Dictionary<string, Property> propertys = new Dictionary<string, Property>();
		public Dictionary<UInt16, Property> idpropertys = new Dictionary<UInt16, Property>();
		
		public Dictionary<string, Method> methods = new Dictionary<string, Method>();
		public Dictionary<string, Method> base_methods = new Dictionary<string, Method>();
		public Dictionary<string, Method> cell_methods = new Dictionary<string, Method>();
		
		public Dictionary<UInt16, Method> idmethods = new Dictionary<UInt16, Method>();
		public Dictionary<UInt16, Method> idbase_methods = new Dictionary<UInt16, Method>();
		public Dictionary<UInt16, Method> idcell_methods = new Dictionary<UInt16, Method>();

		public Type script = null;

		public ScriptModule(string modulename)
		{
			name = modulename;

			foreach (System.Reflection.Assembly ass in AppDomain.CurrentDomain.GetAssemblies()) 
			{
				script = ass.GetType (KBEngineApp.app.getInitArgs().KbeMvvmNameSpace + "." + modulename);//ycm
				if(script == null)
				{
					script = ass.GetType (modulename);
				}

				if(script != null)
					break;
			}

			usePropertyDescrAlias = false;
			useMethodDescrAlias = false;

			if(script == null)
				Dbg.ERROR_MSG("can't load(KbeBalls." + modulename + ")!");
		}
    }

} 
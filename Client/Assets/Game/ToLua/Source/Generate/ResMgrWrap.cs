﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ResMgrWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ResMgr), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("CalcSpriteDict", CalcSpriteDict);
		L.RegFunction("CalcAudioDict", CalcAudioDict);
		L.RegFunction("GetSprite", GetSprite);
		L.RegFunction("GetAudioClip", GetAudioClip);
		L.RegFunction("PackByPath", PackByPath);
		L.RegFunction("Pack", Pack);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("m_sprites", get_m_sprites, set_m_sprites);
		L.RegVar("m_audios", get_m_audios, set_m_audios);
		L.RegVar("CommonRes", get_CommonRes, set_CommonRes);
		L.RegVar("SpriteDict", get_SpriteDict, null);
		L.RegVar("AudioDict", get_AudioDict, null);
		L.RegVar("NotAllowInstance", get_NotAllowInstance, set_NotAllowInstance);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalcSpriteDict(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ResMgr obj = (ResMgr)ToLua.CheckObject(L, 1, typeof(ResMgr));
			obj.CalcSpriteDict();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalcAudioDict(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ResMgr obj = (ResMgr)ToLua.CheckObject(L, 1, typeof(ResMgr));
			obj.CalcAudioDict();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSprite(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ResMgr obj = (ResMgr)ToLua.CheckObject(L, 1, typeof(ResMgr));
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.Sprite o = obj.GetSprite(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAudioClip(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ResMgr obj = (ResMgr)ToLua.CheckObject(L, 1, typeof(ResMgr));
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.AudioClip o = obj.GetAudioClip(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PackByPath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ResMgr obj = (ResMgr)ToLua.CheckObject(L, 1, typeof(ResMgr));
			System.Collections.Generic.List<string> arg0 = (System.Collections.Generic.List<string>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<string>));
			obj.PackByPath(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pack(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(ResMgr), typeof(System.Collections.Generic.List<UnityEngine.AudioClip>)))
			{
				ResMgr obj = (ResMgr)ToLua.ToObject(L, 1);
				System.Collections.Generic.List<UnityEngine.AudioClip> arg0 = (System.Collections.Generic.List<UnityEngine.AudioClip>)ToLua.ToObject(L, 2);
				obj.Pack(arg0);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(ResMgr), typeof(System.Collections.Generic.List<UnityEngine.Sprite>)))
			{
				ResMgr obj = (ResMgr)ToLua.ToObject(L, 1);
				System.Collections.Generic.List<UnityEngine.Sprite> arg0 = (System.Collections.Generic.List<UnityEngine.Sprite>)ToLua.ToObject(L, 2);
				obj.Pack(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: ResMgr.Pack");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_sprites(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			System.Collections.Generic.List<UnityEngine.Sprite> ret = obj.m_sprites;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index m_sprites on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_audios(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			System.Collections.Generic.List<UnityEngine.AudioClip> ret = obj.m_audios;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index m_audios on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CommonRes(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			UnityEngine.GameObject ret = obj.CommonRes;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CommonRes on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SpriteDict(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			System.Collections.Generic.Dictionary<string,UnityEngine.Sprite> ret = obj.SpriteDict;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SpriteDict on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AudioDict(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			System.Collections.Generic.Dictionary<string,UnityEngine.AudioClip> ret = obj.AudioDict;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index AudioDict on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NotAllowInstance(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, ResMgr.NotAllowInstance);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_sprites(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			System.Collections.Generic.List<UnityEngine.Sprite> arg0 = (System.Collections.Generic.List<UnityEngine.Sprite>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Sprite>));
			obj.m_sprites = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index m_sprites on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_audios(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			System.Collections.Generic.List<UnityEngine.AudioClip> arg0 = (System.Collections.Generic.List<UnityEngine.AudioClip>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.AudioClip>));
			obj.m_audios = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index m_audios on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CommonRes(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ResMgr obj = (ResMgr)o;
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
			obj.CommonRes = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CommonRes on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_NotAllowInstance(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			ResMgr.NotAllowInstance = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

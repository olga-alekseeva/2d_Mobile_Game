#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency
struct AnimationSampleDependency_t203A0E5B67FE38BE29AA119164B55D41EC5EFA7B;
// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F;
// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71;
// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C;
// System.String
struct String_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t06D2CD3F5F325CEA428517DE1284C7C27A1A6BA3 
{
};
struct Il2CppArrayBounds;

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C  : public RuntimeObject
{
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;
};

struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_StaticFields
{
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;
};
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};

// UnityEngine.Component
struct Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.GameObject
struct GameObject_t76FEDD663AB33C991A9C9A23129337651094216F  : public Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C
{
};

// UnityEngine.Behaviour
struct Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA  : public Component_t39FBE53E5EFCF4409111FB22C15FF73717632EC3
{
};

// UnityEngine.MonoBehaviour
struct MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71  : public Behaviour_t01970CFBBA658497AE30F311C447DB0440BAB7FA
{
};

// Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency
struct AnimationSampleDependency_t203A0E5B67FE38BE29AA119164B55D41EC5EFA7B  : public MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71
{
	// UnityEngine.GameObject Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency::errorUI
	GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* ___errorUI_4;
	// Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency/Dependency Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency::dependency
	int32_t ___dependency_5;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Boolean Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency::HasDependencyInstalled()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AnimationSampleDependency_HasDependencyInstalled_m2D974E47F11F6D7AFB25D6C9C36180D56519D574 (AnimationSampleDependency_t203A0E5B67FE38BE29AA119164B55D41EC5EFA7B* __this, const RuntimeMethod* method) ;
// System.Boolean UnityEngine.Object::op_Inequality(UnityEngine.Object,UnityEngine.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7 (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___x0, Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C* ___y1, const RuntimeMethod* method) ;
// System.Void UnityEngine.GameObject::SetActive(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void GameObject_SetActive_m638E92E1E75E519E5B24CF150B08CA8E0CDFAB92 (GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* __this, bool ___value0, const RuntimeMethod* method) ;
// System.Void UnityEngine.MonoBehaviour::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E (MonoBehaviour_t532A11E69716D348D8AA7F854AFCBFCB8AD17F71* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency::Update()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationSampleDependency_Update_mB098234076E0278AAA98A6D67F4B8524D1979A8E (AnimationSampleDependency_t203A0E5B67FE38BE29AA119164B55D41EC5EFA7B* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	{
		// var hasDependencyInstalled = HasDependencyInstalled();
		bool L_0;
		L_0 = AnimationSampleDependency_HasDependencyInstalled_m2D974E47F11F6D7AFB25D6C9C36180D56519D574(__this, NULL);
		V_0 = L_0;
		// if(errorUI != null)
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_1 = __this->___errorUI_4;
		il2cpp_codegen_runtime_class_init_inline(Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C_il2cpp_TypeInfo_var);
		bool L_2;
		L_2 = Object_op_Inequality_m4D656395C27694A7F33F5AA8DE80A7AAF9E20BA7(L_1, (Object_tC12DECB6760A7F2CBF65D9DCF18D044C2D97152C*)NULL, NULL);
		if (!L_2)
		{
			goto IL_0024;
		}
	}
	{
		// errorUI.SetActive(!hasDependencyInstalled);
		GameObject_t76FEDD663AB33C991A9C9A23129337651094216F* L_3 = __this->___errorUI_4;
		bool L_4 = V_0;
		NullCheck(L_3);
		GameObject_SetActive_m638E92E1E75E519E5B24CF150B08CA8E0CDFAB92(L_3, (bool)((((int32_t)L_4) == ((int32_t)0))? 1 : 0), NULL);
	}

IL_0024:
	{
		// }
		return;
	}
}
// System.Boolean Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency::HasDependencyInstalled()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool AnimationSampleDependency_HasDependencyInstalled_m2D974E47F11F6D7AFB25D6C9C36180D56519D574 (AnimationSampleDependency_t203A0E5B67FE38BE29AA119164B55D41EC5EFA7B* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		// switch (dependency)
		int32_t L_0 = __this->___dependency_5;
		V_0 = L_0;
		int32_t L_1 = V_0;
		if ((((int32_t)L_1) == ((int32_t)1)))
		{
			goto IL_0011;
		}
	}
	{
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) == ((int32_t)2)))
		{
			goto IL_0013;
		}
	}
	{
		goto IL_0015;
	}

IL_0011:
	{
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// return true;
		return (bool)1;
	}

IL_0015:
	{
		// return true;
		return (bool)1;
	}
}
// System.Void Unity.U2D.Animation.Sample.Dependency.AnimationSampleDependency::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AnimationSampleDependency__ctor_mDD141A5D22EE5DAAC408D0595A77794A99EBC3B6 (AnimationSampleDependency_t203A0E5B67FE38BE29AA119164B55D41EC5EFA7B* __this, const RuntimeMethod* method) 
{
	{
		MonoBehaviour__ctor_m592DB0105CA0BC97AA1C5F4AD27B12D68A3B7C1E(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif

#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>



// System.String
struct String_t;

IL2CPP_EXTERN_C RuntimeClass* SingletonSettings_tD7893C16EBE4E9A4BB3B0C213D60B1AD29114448_il2cpp_TypeInfo_var;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct U3CModuleU3E_t9A080C702F2DBE7B734E736A48E5108B98F8FD5E 
{
};

// SingletonSettings
struct SingletonSettings_tD7893C16EBE4E9A4BB3B0C213D60B1AD29114448  : public RuntimeObject
{
};

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

// <Module>

// <Module>

// SingletonSettings
struct SingletonSettings_tD7893C16EBE4E9A4BB3B0C213D60B1AD29114448_StaticFields
{
	// System.Boolean SingletonSettings::checkInitOrder
	bool ___checkInitOrder_0;
};

// SingletonSettings

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Boolean

// System.Void

// System.Void
#ifdef __clang__
#pragma clang diagnostic pop
#endif



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
// System.Void SingletonSettings::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SingletonSettings__cctor_m27F1C371961D78C40C71343BED149A7C6EB3FE6C (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SingletonSettings_tD7893C16EBE4E9A4BB3B0C213D60B1AD29114448_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// [PublicAPI] public static bool checkInitOrder = true;
		((SingletonSettings_tD7893C16EBE4E9A4BB3B0C213D60B1AD29114448_StaticFields*)il2cpp_codegen_static_fields_for(SingletonSettings_tD7893C16EBE4E9A4BB3B0C213D60B1AD29114448_il2cpp_TypeInfo_var))->___checkInitOrder_0 = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif

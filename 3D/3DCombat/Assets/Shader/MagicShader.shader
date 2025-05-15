// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "New Amplify Shader"
{
	Properties
	{
		_c("c", 2D) = "white" {}
		_d("d", 2D) = "white" {}
		_Move_X("Move_X", Range( -1 , 1)) = 0.5
		_Move_Y("Move_Y", Range( -1 , 1)) = 0.5
		_Scale_V("Scale_V", Range( 0.5 , 10)) = 0.5
		_Scale_U("Scale_U", Range( 0.5 , 10)) = 0.5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull Back
		ZWrite Off
		Blend One One
		
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _c;
		uniform sampler2D _d;
		uniform float _Move_X;
		uniform float _Move_Y;
		uniform float _Scale_U;
		uniform float _Scale_V;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float cos15 = cos( -1.0 * _Time.y );
			float sin15 = sin( -1.0 * _Time.y );
			float2 rotator15 = mul( i.uv_texcoord - float2( 0.5,0.5 ) , float2x2( cos15 , -sin15 , sin15 , cos15 )) + float2( 0.5,0.5 );
			float cos13 = cos( 1.0 * _Time.y );
			float sin13 = sin( 1.0 * _Time.y );
			float2 rotator13 = mul( i.uv_texcoord - float2( 0.5,0.5 ) , float2x2( cos13 , -sin13 , sin13 , cos13 )) + float2( 0.5,0.5 );
			float2 appendResult5 = (float2(_Move_X , _Move_Y));
			float2 appendResult10 = (float2(_Scale_U , _Scale_V));
			o.Emission = ( tex2D( _c, rotator15 ) + tex2D( _d, ( ( rotator13 + appendResult5 ) * appendResult10 ) ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16700
1026;637;995;749;900.688;316.79;1.3;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;4;-975.8701,-64.73245;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;7;-1023.992,202.0553;Float;False;Property;_Move_Y;Move_Y;4;0;Create;True;0;0;False;0;0.5;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-1023.992,106.0553;Float;False;Property;_Move_X;Move_X;3;0;Create;True;0;0;False;0;0.5;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;5;-661.894,186.178;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-768,390.0841;Float;False;Property;_Scale_U;Scale_U;6;0;Create;True;0;0;False;0;0.5;0;0.5;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;12;-768,518.0825;Float;False;Property;_Scale_V;Scale_V;5;0;Create;True;0;0;False;0;0.5;0;0.5;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;13;-673.7827,-6.327402;Float;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;10;-404.0543,369.3636;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;3;-418.694,88.57809;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;14;-471.7536,-189.0694;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RotatorNode;15;-179.0262,-108.4633;Float;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;-1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;9;-174.6589,263.4888;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;2;64.97843,177.9067;Float;True;Property;_d;d;2;0;Create;True;0;0;False;0;b4f5ca6e4d7e0bb4d902692937ffb756;b4f5ca6e4d7e0bb4d902692937ffb756;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;62.39561,-91.58457;Float;True;Property;_c;c;1;0;Create;True;0;0;False;0;95945c6989620f4488f7363a79874815;95945c6989620f4488f7363a79874815;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;16;424.6129,99.59422;Float;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;669.3043,53.1741;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;New Amplify Shader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;2;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;4;1;False;-1;1;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;6;0
WireConnection;5;1;7;0
WireConnection;13;0;4;0
WireConnection;10;0;11;0
WireConnection;10;1;12;0
WireConnection;3;0;13;0
WireConnection;3;1;5;0
WireConnection;15;0;14;0
WireConnection;9;0;3;0
WireConnection;9;1;10;0
WireConnection;2;1;9;0
WireConnection;1;1;15;0
WireConnection;16;0;1;0
WireConnection;16;1;2;0
WireConnection;0;2;16;0
ASEEND*/
//CHKSM=C02FF8F963C616451875435A958DDC85DD20B888
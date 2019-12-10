Shader "Custom/WireFrame" {
	//shaderslab.com
	Properties {
		_LineColor ("LineColor", Color) = (1, 1, 1, 1)
		_MainColor ("_MainColor", Color) = (1, 1, 1, 1)
		_LineWidth ("Line width", Range(0, 1)) = 0.1
		_ParcelSize ("ParcelSize", Range(0, 100)) = 1
		_Emission ("Emmision", Color) = (1,1,1,1)
		_EmissionLM ("Emission(Lightmapper)", Float) = 1
	}
	SubShader {
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		
		CGPROGRAM
		#pragma surface surf Standard alpha

		sampler2D _MainTex;
		float4 _LineColor;
		float4 _MainColor;
		fixed _LineWidth;
		float _ParcelSize;
		float4 _Emission;
		float _EmissionLM;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			half val1 = step(_LineWidth * 2, frac(IN.worldPos.x / _ParcelSize) + _LineWidth);
			half val2 = step(_LineWidth * 2, frac(IN.worldPos.z / _ParcelSize) + _LineWidth);
			fixed val = 1 - (val1 * val2);
			o.Albedo = lerp(_MainColor, _LineColor, val);
			o.Emission = lerp(_MainColor, _Emission.rgb*_EmissionLM, val);
			o.Alpha = 1;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
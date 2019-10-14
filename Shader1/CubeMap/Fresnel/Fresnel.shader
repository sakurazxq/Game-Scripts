Shader "Custom/Fresnel"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

		_CubeMap("Cube Map", CUBE) = "" {}
		_EatRatio("Rate",float) = 1.1

		_FresnelBias("fresnelBias",float) = 1
		_FresnelScale("fresnelScale",float) = 1
		_FresnelPower("fresnelPower",float) = 0.5
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert vertex:MyVertex

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		samplerCUBE _CubeMap;

        struct Input
        {
            float2 uv_MainTex;
			float3 worldRefl;
			float3 refract;
			float reflectFact;
        };

        
        fixed4 _Color;
		float _EatRatio;
		float _FresnelBias;
		float _FresnelScale;
		float _FresnelPower;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

		void MyVertex(inout appdata_full v, out Input data) 
		{
			UNITY_INITIALIZE_OUTPUT(Input, data);
			float3 localNormal = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
			float3 viewDir = -WorldSpaceViewDir(v.vertex);
			data.refract = refract(viewDir, localNormal, _EatRatio);
			data.reflectFact = _FresnelBias + _FresnelScale * pow(1 + dot(viewDir, localNormal), _FresnelPower);

		}

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 creflect = tex2D (_MainTex, IN.worldRefl);
			//fixed4 crefract = tex2D(_MainTex, IN.refract);

			fixed4 creflect = texCUBE(_CubeMap, IN.worldRefl);
			fixed4 crefract = texCUBE(_CubeMap, IN.refract);

			o.Albedo = IN.reflectFact * creflect.rgb + (1 - IN.reflectFact) * crefract.rgb;
            
            o.Alpha = creflect.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

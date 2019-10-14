Shader "Custom/NormalOutline"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

		_NorTex("Normal Map (RGB)", 2D) = "white" {}

		_RimPower("Rim Power", Range(0.6,36.0)) = 8.0
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _NorTex;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_NorTex;
			float3 viewDir;
        };

        
        fixed4 _Color;
		float _RimPower;
		

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
			float3 tmpNormal = UnpackNormal(tex2D(_NorTex, IN.uv_NorTex));   //tmpNormal为法线向量
			o.Normal = tmpNormal;

			float tmpFloat = 1-saturate(dot(normalize(IN.viewDir), tmpNormal));   //算出法线和视线的点乘
			o.Emission = _Color * pow(tmpFloat, _RimPower);
            
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

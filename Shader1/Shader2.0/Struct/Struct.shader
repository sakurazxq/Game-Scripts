Shader "Hidden/Struct"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        //Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert   //定义一个顶点着色器的入口函数
            #pragma fragment frag   //定义一个片段着色器的入口函数

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;   //POSITION为获取模型的顶点信息
                float2 uv : TEXCOORD0;   //TEXCOORD(n)为高精度地从顶点传递到片段着色器，可传递二维、三维、四维数据
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)   //顶点着色器的入口函数，appdata是从meshrender里面来的，v2f是顶点着色器的输出值，片段着色器的输入值
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                col.rgb = 1 - col.rgb;
                return col;
            }
            ENDCG
        }
    }
}

Shader "Hidden/API_Tex"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Overlay1 ("Overlay texture", 2D) = "white" {}
        _RedBlend ("Red blend value", float) = 1.0 {}
        _GreenBlend ("Red blend value", float) = 1.0 {}
        _BlueBlend ("Red blend value", float) = 1.0 {}

    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
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
                float rb = float(_RedBlend)
                // just invert the colors
                col.rgb = (col.r*)
                return col;
            }
            ENDCG
        }
    }
}

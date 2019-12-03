Shader "API/Greyscale"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Albedo ("Albedo color", Color) = (1,1,1,1)
        _Amount ("Amount of something", Float) = 0.75
    }
    
    Subshader
    {
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
                    float4 vertex : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };
                
                sampler2D _MainTex;
                float4 _MainTex_ST;
                
                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }
                
                float4 frag(v2f_img i): SV_TARGET
                {
                    float4 tex = tex2D(_MainTex, i.uv);
                    
                    float lum = tex.r * 0.3 + tex.g * 0.59 + tex.b * 0.11;
                    float4 result = float4(lum, lum, lum, tex.a);
                    return result;
                }
                
            ENDCG
        }
    }
}

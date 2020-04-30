Shader "KSP-API/ColorBlend"
{
    Properties
    {
        _MainTex ("Input Image", 2D) = "white" {}
    }
    
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            uniform sampler2D _MainTex;
            uniform half4x4 transform;
            uniform int preset;
            float4 frag(v2f_img i) : COLOR
            {
                float4 c = tex2D(_MainTex, i.uv);
                half4 result = mul(c.rgb, transform);
                return result;
            }
            ENDCG
        }
    }
}
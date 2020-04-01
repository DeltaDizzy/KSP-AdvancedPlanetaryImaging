Shader "KSP-API/ColorBlend"
{
    Properties
    {
        _MainTex ("Input Image", 2D) = "white" {}
        _Preset ("Channel Assignment Preset", Vector) = (1,2,3,1)
    }
    
    SubShader
    {
        Pass
        {
            CGPROGRAM
            // vert_img is the default vertex function provided by UnityCG
            #pragma vertex vert_img
            // our fragment processing will be done in the "frag" function
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            // define our variables (name MUST match the associated Property)
            uniform sampler2D _MainTex;
            uniform float4 _Preset;
            int presetInt;
            // main thing is the function semantic, which is how the output is intended
            // to be used. In this case, the output will be a diffuse pixel, so we use the COLOR 
            // semantic.
            float4 frag(v2f_img i) : COLOR
            {
                // c = r,g,b,a of maintex at the specified uv
                float4 c = tex2D(_MainTex, i.uv);
                presetInt = _Preset.x*1000 + _Preset.y*100 + _Preset.z*10  + _Preset.w*1;
                switch(presetInt)
                {
                    case (1231): // red, green, blue
                        return float4(c.r, c.g, c.b, c.a);
                    case (1211): // red, green, blue missing/replaced with red
                        return float4(c.r, c.g, c.r, c.a);
                    case (1221): // red, green, blue missing/replaced with green
                        return float4(c.r, c.g, c.g, c.a);
                    case (1131): // red, green missing/replaced with red, blue
                        return float4(c.r, c.r, c.b, c.a);
                    case (1331): // red, green missing/replaced with blue, blue
                        return float4(c.r, c.b, c.b, c.a);
                    case (2231): // red missing/replaced with green, green, blue
                        return float4(c.g, c.g, c.b, c.a);
                    case (3231): // red missing/replaced with blue, green, blue
                        return float4(c.b, c.g, c.b, c.a);
                    default:
                        return float4(c.r, c.g, c.b, c.a);
                }
            }
            ENDCG
        }
    }
}
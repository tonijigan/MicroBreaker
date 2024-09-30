Shader "Unlit/Mask"
{
    Properties
    {
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque" "Queue" = "Geometry-1"
        }

        Blend Zero One
        ZWrite Off
        
        Pass
        {
             Stencil
            {
                Ref 1
                Pass replace
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return 0;
            }
            ENDCG
        }
    }
}
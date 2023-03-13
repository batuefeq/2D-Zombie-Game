Shader "Unlit/Wind"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "black" {}
        _Speed ("Wind Speed", Range(0, 10)) = 1
        _Frequency ("Wind Frequency", Range(0, 5)) = 0.1
        _Amplitude ("Wind Amplitude", Range(0, 5)) = 0.1
        _Color ("Main Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Transparent" "DisableBatching" = "True"}
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Speed;
            float _Frequency;
            float _Amplitude;
            fixed4 _Color;

            float4 wind(float4 vertexPos, float2 uv)
            {
                // Displace vertex position over time
                vertexPos.x += sin((uv - (_Time.y * _Speed)) * _Frequency) * (uv.y * _Amplitude);
                float4 vertex = UnityObjectToClipPos(vertexPos);
                return vertex;
            }

            v2f vert (appdata v)
            {
                // Transform texture 
                v2f o;
                o.vertex = wind(v.vertex, v.uv);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Final texture output
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                return col;
            }
            ENDCG
        }
    }
}

Shader "Custom/Neutral"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "" {}
        _RimCol("Rim Colour" , Color) = (1,0,0,1)
        _RimPow("Rim Power", Float) = 1.0
    }
        SubShader
        {
            //Name "Behind1"
            //Tags { "RenderType"="Opaque"}
            //Blend SrcAlpha OneMinusSrcAlpha
            //ZTest Less
            //Cull Back
            //ZWrite On
            //LOD 200
            //

            ZWrite On
            ZTest LEqual
            CGPROGRAM

            #pragma surface surf Standard fullforwardshadows
            #pragma target 3.0
            #include "UnityCG.cginc"
            sampler2D _MainTex;
            struct Input
            {
                float2 uv_MainTex;
            };
            fixed4 _Color;
            UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_INSTANCING_BUFFER_END(Props)
            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = c.rgb;
            }

            ENDCG

                Pass{
                 Name "Behind"
                 Tags { "RenderType" = "transparent" "Queue" = "Transparent" }
                 Blend SrcAlpha OneMinusSrcAlpha
                //ZTest Greater               // here the check is for the pixel being greater or closer to the camera, in which
                Cull Back                   // case the model is behind something, so this pass runs
                //ZWrite On
                LOD 200

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct v2f {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                    float3 normal : TEXCOORD1;      // Normal needed for rim lighting
                    float3 viewDir : TEXCOORD2;     // as is view direction.
                };

                sampler2D _MainTex;
                float4 _RimCol;
                float _RimPow;

                float4 _MainTex_ST;

                v2f vert(appdata_tan v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                    o.normal = normalize(v.normal);
                    o.viewDir = normalize(ObjSpaceViewDir(v.vertex));       //this could also be WorldSpaceViewDir, which would
                    return o;                                               //return the World space view direction.
                }

                half4 frag(v2f i) : COLOR
                {
                    half Rim = 1 - saturate(dot(normalize(i.viewDir), i.normal));       //Calculates where the model view falloff is       
                                                                                                                                       //for rim lighting.

                    half4 RimOut = _RimCol * pow(Rim, _RimPow);
                    return RimOut;
                }
                ENDCG
           }

           Pass{
               Name "Behind3"
               Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }
               Blend OneMinusSrcAlpha SrcAlpha
               ZTest LEqual
               Cull Back
               ZWrite On
               LOD 200
               CGPROGRAM
               #pragma vertex vert
               #pragma fragment frag
               #include "UnityCG.cginc"

               struct v2f {
                   float4 pos : SV_POSITION;
                   float2 uv : TEXCOORD0;
               };

               sampler2D _MainTex;
               float4 _MainTex_ST;

               v2f vert(appdata_base v)
               {
                   v2f o;
                   o.pos = UnityObjectToClipPos(v.vertex);
                   o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                   return o;
               }

               half4 frag(v2f i) : COLOR
               {
                   half4 texcol = tex2D(_MainTex,i.uv);
                   return texcol;
               }
               ENDCG
           }

                    //Name "Behind1231312321"
                    //Tags { "RenderType" = "Opaque"}
                    //Blend SrcAlpha OneMinusSrcAlpha
                    //ZTest Less
                    //Cull Back
                    //ZWrite On
                    //LOD 200

                    CGPROGRAM

                    #pragma surface surf Standard fullforwardshadows
                    #pragma target 3.0
                    #include "UnityCG.cginc"
                    sampler2D _MainTex;
                    struct Input
                    {
                        float2 uv_MainTex;
                    };
                    fixed4 _Color;
                    UNITY_INSTANCING_BUFFER_START(Props)
                    UNITY_INSTANCING_BUFFER_END(Props)
                    void surf(Input IN, inout SurfaceOutputStandard o)
                    {
                        fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                        o.Albedo = c.rgb;
                    }

                    ENDCG

        }

            FallBack "Diffuse"
}
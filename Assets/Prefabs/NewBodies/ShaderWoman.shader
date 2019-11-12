// Shader created with Shader Forge v1.42 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Enhanced by Antoine Guillon / Arkham Development - http://www.arkham-development.com/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.42;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-1415-OUT,spec-358-OUT,gloss-1813-OUT,normal-5964-RGB;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32407,y:32978,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Tex2d,id:4840,x:29117,y:31449,ptovrint:False,ptlb:RGB_colors,ptin:_RGB_colors,varname:_RGB_colors,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8d33e5af098a2af48affd9f350ea006e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4352,x:29117,y:31653,cmnt:separamos el blanco,varname:node_4352,prsc:2|A-4840-R,B-4840-G,C-4840-B;n:type:ShaderForge.SFN_OneMinus,id:7605,x:29117,y:31228,varname:node_7605,prsc:2|IN-4840-RGB;n:type:ShaderForge.SFN_ComponentMask,id:1188,x:29124,y:31022,varname:node_1188,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-7605-OUT;n:type:ShaderForge.SFN_Multiply,id:495,x:29124,y:30831,varname:node_495,prsc:2|A-1188-R,B-1188-G,C-1188-B;n:type:ShaderForge.SFN_Subtract,id:6792,x:29489,y:31259,varname:node_6792,prsc:2|A-4840-RGB,B-495-OUT;n:type:ShaderForge.SFN_Subtract,id:2730,x:29505,y:31431,varname:node_2730,prsc:2|A-6792-OUT,B-4352-OUT;n:type:ShaderForge.SFN_Set,id:6486,x:29364,y:30831,cmnt:Separamos el negro,varname:node_6486,prsc:2|IN-495-OUT;n:type:ShaderForge.SFN_Clamp01,id:6822,x:29519,y:31600,varname:node_6822,prsc:2|IN-2730-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8845,x:29828,y:31419,varname:node_8845,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-6822-OUT;n:type:ShaderForge.SFN_Multiply,id:490,x:30026,y:31246,varname:node_490,prsc:2|A-8845-G,B-8845-B;n:type:ShaderForge.SFN_Multiply,id:6886,x:30026,y:31419,varname:node_6886,prsc:2|A-8845-R,B-8845-B;n:type:ShaderForge.SFN_Multiply,id:3419,x:30026,y:31569,varname:node_3419,prsc:2|A-8845-G,B-8845-R;n:type:ShaderForge.SFN_Set,id:6192,x:30026,y:31191,varname:node_6192,prsc:2|IN-490-OUT;n:type:ShaderForge.SFN_Set,id:7577,x:30026,y:31373,varname:node_7577,prsc:2|IN-6886-OUT;n:type:ShaderForge.SFN_Set,id:5237,x:30026,y:31524,varname:node_5237,prsc:2|IN-3419-OUT;n:type:ShaderForge.SFN_Add,id:7624,x:30313,y:31226,varname:node_7624,prsc:2|A-3419-OUT,B-6886-OUT;n:type:ShaderForge.SFN_Add,id:2295,x:30303,y:31366,varname:node_2295,prsc:2|A-3419-OUT,B-490-OUT;n:type:ShaderForge.SFN_Add,id:5781,x:30303,y:31528,varname:node_5781,prsc:2|A-6886-OUT,B-490-OUT;n:type:ShaderForge.SFN_Subtract,id:740,x:30557,y:31154,varname:node_740,prsc:2|A-8845-R,B-7624-OUT;n:type:ShaderForge.SFN_Subtract,id:9641,x:30570,y:31345,varname:node_9641,prsc:2|A-8845-G,B-2295-OUT;n:type:ShaderForge.SFN_Subtract,id:359,x:30570,y:31514,varname:node_359,prsc:2|A-8845-B,B-5781-OUT;n:type:ShaderForge.SFN_Set,id:4408,x:30939,y:31154,varname:node_4408,prsc:2|IN-1913-OUT;n:type:ShaderForge.SFN_Set,id:3933,x:30928,y:31345,varname:node_3933,prsc:2|IN-6962-OUT;n:type:ShaderForge.SFN_Set,id:1298,x:30982,y:31710,varname:node_1298,prsc:2|IN-166-OUT;n:type:ShaderForge.SFN_Set,id:4596,x:29315,y:31689,varname:node_4596,prsc:2|IN-4352-OUT;n:type:ShaderForge.SFN_Color,id:6489,x:30136,y:31841,ptovrint:False,ptlb:ColorSkin,ptin:_ColorSkin,varname:_ColR,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:1018,x:30136,y:32036,ptovrint:False,ptlb:ColorSweater,ptin:_ColorSweater,varname:_ColG,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:1,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:7137,x:30582,y:31838,ptovrint:False,ptlb:ColorShirt,ptin:_ColorShirt,varname:_ColC,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:8197,x:30136,y:32216,ptovrint:False,ptlb:ColorSkirt,ptin:_ColorSkirt,varname:_ColB,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:213,x:30423,y:31838,varname:node_213,prsc:2|A-6489-RGB,B-6907-OUT;n:type:ShaderForge.SFN_Get,id:6907,x:30241,y:31887,varname:node_6907,prsc:2|IN-4408-OUT;n:type:ShaderForge.SFN_Multiply,id:9103,x:30404,y:32044,varname:node_9103,prsc:2|A-1018-RGB,B-4440-OUT;n:type:ShaderForge.SFN_Get,id:4440,x:30240,y:32093,varname:node_4440,prsc:2|IN-3933-OUT;n:type:ShaderForge.SFN_Multiply,id:4655,x:30428,y:32236,varname:node_4655,prsc:2|A-8197-RGB,B-9153-OUT;n:type:ShaderForge.SFN_Get,id:9153,x:30245,y:32285,varname:node_9153,prsc:2|IN-1298-OUT;n:type:ShaderForge.SFN_Multiply,id:9681,x:30866,y:31864,varname:node_9681,prsc:2|A-7137-RGB,B-7845-OUT;n:type:ShaderForge.SFN_Get,id:7845,x:30683,y:31913,varname:node_7845,prsc:2|IN-6192-OUT;n:type:ShaderForge.SFN_Add,id:1415,x:31323,y:32438,varname:node_1415,prsc:2|A-213-OUT,B-9103-OUT,C-4655-OUT,D-9681-OUT;n:type:ShaderForge.SFN_Clamp01,id:1913,x:30748,y:31154,varname:node_1913,prsc:2|IN-740-OUT;n:type:ShaderForge.SFN_Clamp01,id:6962,x:30748,y:31345,varname:node_6962,prsc:2|IN-9641-OUT;n:type:ShaderForge.SFN_Clamp01,id:166,x:30820,y:31685,varname:node_166,prsc:2|IN-359-OUT;n:type:ShaderForge.SFN_Set,id:2309,x:31804,y:32393,varname:node_2309,prsc:2|IN-1415-OUT;proporder:5964-358-1813-4840-6489-1018-7137-8197;pass:END;sub:END;*/

Shader "Shader Forge/ShaderWoman" {
    Properties {
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _RGB_colors ("RGB_colors", 2D) = "white" {}
        _ColorSkin ("ColorSkin", Color) = (1,0.5,0.5,1)
        _ColorSweater ("ColorSweater", Color) = (0.5,1,0.5,1)
        _ColorShirt ("ColorShirt", Color) = (0.5,1,1,1)
        _ColorSkirt ("ColorSkirt", Color) = (0.5,0.5,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDBASE
            #define UNITY_PASS_FORWARDBASE
            #endif //UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu switch vulkan 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _RGB_colors; uniform float4 _RGB_colors_ST;
            uniform float4 _ColorSkin;
            uniform float4 _ColorSweater;
            uniform float4 _ColorShirt;
            uniform float4 _ColorSkirt;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                UNITY_LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                UNITY_TRANSFER_LIGHTING(o, v.texcoord1);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _RGB_colors_var = tex2D(_RGB_colors,TRANSFORM_TEX(i.uv0, _RGB_colors));
                float3 node_1188 = (1.0 - _RGB_colors_var.rgb).rgb;
                float node_495 = (node_1188.r*node_1188.g*node_1188.b);
                float node_4352 = (_RGB_colors_var.r*_RGB_colors_var.g*_RGB_colors_var.b); // separamos el blanco
                float3 node_8845 = saturate(((_RGB_colors_var.rgb-node_495)-node_4352)).rgb;
                float node_3419 = (node_8845.g*node_8845.r);
                float node_6886 = (node_8845.r*node_8845.b);
                float node_4408 = saturate((node_8845.r-(node_3419+node_6886)));
                float node_490 = (node_8845.g*node_8845.b);
                float node_3933 = saturate((node_8845.g-(node_3419+node_490)));
                float node_1298 = saturate((node_8845.b-(node_6886+node_490)));
                float node_6192 = node_490;
                float3 node_9681 = (_ColorShirt.rgb*node_6192);
                float3 node_1415 = ((_ColorSkin.rgb*node_4408)+(_ColorSweater.rgb*node_3933)+(_ColorSkirt.rgb*node_1298)+node_9681);
                float3 diffuseColor = node_1415; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_FORWARDADD
            #define UNITY_PASS_FORWARDADD
            #endif //UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu switch vulkan 
            #pragma target 3.0
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _RGB_colors; uniform float4 _RGB_colors_ST;
            uniform float4 _ColorSkin;
            uniform float4 _ColorSweater;
            uniform float4 _ColorShirt;
            uniform float4 _ColorSkirt;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                UNITY_LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                UNITY_TRANSFER_LIGHTING(o, v.texcoord1);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float4 _RGB_colors_var = tex2D(_RGB_colors,TRANSFORM_TEX(i.uv0, _RGB_colors));
                float3 node_1188 = (1.0 - _RGB_colors_var.rgb).rgb;
                float node_495 = (node_1188.r*node_1188.g*node_1188.b);
                float node_4352 = (_RGB_colors_var.r*_RGB_colors_var.g*_RGB_colors_var.b); // separamos el blanco
                float3 node_8845 = saturate(((_RGB_colors_var.rgb-node_495)-node_4352)).rgb;
                float node_3419 = (node_8845.g*node_8845.r);
                float node_6886 = (node_8845.r*node_8845.b);
                float node_4408 = saturate((node_8845.r-(node_3419+node_6886)));
                float node_490 = (node_8845.g*node_8845.b);
                float node_3933 = saturate((node_8845.g-(node_3419+node_490)));
                float node_1298 = saturate((node_8845.b-(node_6886+node_490)));
                float node_6192 = node_490;
                float3 node_9681 = (_ColorShirt.rgb*node_6192);
                float3 node_1415 = ((_ColorSkin.rgb*node_4408)+(_ColorSweater.rgb*node_3933)+(_ColorSkirt.rgb*node_1298)+node_9681);
                float3 diffuseColor = node_1415; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #ifndef UNITY_PASS_META
            #define UNITY_PASS_META 1
            #endif UNITY_PASS_META
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu switch vulkan 
            #pragma target 3.0
            uniform float _Metallic;
            uniform float _Gloss;
            uniform sampler2D _RGB_colors; uniform float4 _RGB_colors_ST;
            uniform float4 _ColorSkin;
            uniform float4 _ColorSweater;
            uniform float4 _ColorShirt;
            uniform float4 _ColorSkirt;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 _RGB_colors_var = tex2D(_RGB_colors,TRANSFORM_TEX(i.uv0, _RGB_colors));
                float3 node_1188 = (1.0 - _RGB_colors_var.rgb).rgb;
                float node_495 = (node_1188.r*node_1188.g*node_1188.b);
                float node_4352 = (_RGB_colors_var.r*_RGB_colors_var.g*_RGB_colors_var.b); // separamos el blanco
                float3 node_8845 = saturate(((_RGB_colors_var.rgb-node_495)-node_4352)).rgb;
                float node_3419 = (node_8845.g*node_8845.r);
                float node_6886 = (node_8845.r*node_8845.b);
                float node_4408 = saturate((node_8845.r-(node_3419+node_6886)));
                float node_490 = (node_8845.g*node_8845.b);
                float node_3933 = saturate((node_8845.g-(node_3419+node_490)));
                float node_1298 = saturate((node_8845.b-(node_6886+node_490)));
                float node_6192 = node_490;
                float3 node_9681 = (_ColorShirt.rgb*node_6192);
                float3 node_1415 = ((_ColorSkin.rgb*node_4408)+(_ColorSweater.rgb*node_3933)+(_ColorSkirt.rgb*node_1298)+node_9681);
                float3 diffColor = node_1415;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

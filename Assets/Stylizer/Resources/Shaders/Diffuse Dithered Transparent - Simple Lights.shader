Shader "Beffio/Diffuse Dithered Transparent - Simple Lights" 
{
	Properties 
	{
		// Diffuse Properties
		_Color ("Base Color", Color) = (1,1,1,1)
		_MainTex ("Base Color Texture", 2D) = "white" {}
		_BumpScale("Normal Scale", Float) = 1.0
		[Normal] _BumpMap("Normal Map", 2D) = "bump" {}

		_Cutout("Cutout", Range(0.0, 1.0)) = 0.5

		// Dithering
		_PaletteColorCount ("Mixed Color Count", float) = 4
		_PaletteHeight ("Palette Texture Height", float) = 128
		_PaletteTex ("Palette Texture", 2D) = "black" {}
		_PatternSize ("Pattern Texture Size", float) = 8
		_PatternTex ("Pattern Texture", 2D) = "black" {}
		_PatternScale("Pattern Scale", float) = 1

		// Reference hack
		[HideInInspector]__paletteRef ("Palette Asset", Vector) = (0,0,0,0)
		[HideInInspector]__patternRef ("Pattern Asset", Vector) = (0,0,0,0)
		[HideInInspector]__hasPatternTex ("Has Pattern Texture", float) = 0
	}

	SubShader 
	{
		Tags 
		{
			"Queue"="Transparent"
			"RenderType"="Transparent"
			"IgnoreProjector"="false"
		}
		LOD 200
		
		CGPROGRAM
			#pragma surface LambertSurface Lambert alphatest:_Cutout vertex:DitheringVertex finalcolor:DiffuseDither noforwardadd
			#pragma target 3.0

			// Shader features
			#pragma shader_feature _NORMALMAP
			#pragma shader_feature _SCREENSPACEDITHER

			#include "Dithering Material Base.cginc"
			#include "Diffuse Base Include.cginc"

			void DiffuseDither(Input i, SurfaceOutput o, inout fixed4 color) 
			{
				color.rgb = GetDitherColor(color.rgb, _PatternTex, _PaletteTex, _PaletteHeight, i.ditherPos, _PaletteColorCount, _PatternScale);
			}
		ENDCG
	}
	FallBack "Diffuse"
	CustomEditor "Beffio.Dithering.DiffuseDitheredEditor"
}

Shader "API/Blue" {
	Properties {
		_MainTex("Camera Output", 2D)="white" {}
		_DataOverlay("Frame Information Bar", 2D)="black" {}
		_OverlayTex1("Overlay1 Texture", 2D)="white" {}
		_OverlayTex2("Overlay2 Texture", 2D)
		_OverlayTex3("Overlay3 Texture", 2D)

		_Overlay1OffsetX("Overlay1 X Offset", Range(0,1))=0
		_Overlay1OffsetY("Overlay1 Y Offset", Range(0,1))=0

		_Overlay2OffsetX("Overlay2 X Offset", Range(0,1))=0
		_Overlay2OffsetY("Overlay2 Y Offset", Range(0,1))=0

		_ColorNoise("Color Noise", Range(0.7,1.3))=1
		_ContrastNoise("ContrastNoise", Range(0.7,1.3))=1
		_BrightnessNoise("brightness Noise", Range(0.7-1.3))=1
		
	}
	
	SubShader {
		Pass {
			#include "UnityCG.cginc"
		}
	}
}
Shader "Unlit/BrightnessSaturationAndContrast"
{
	Properties
	{
		//主纹理
		_MainTex("Texture", 2D) = "white" {}
		//亮度
		_Brightness("Brightness",Float) = 1
		//饱和度
		_Saturation("Saturation",Float) = 1
		//对比度
		_Contrast("Contrat",Float) = 1
	}
		SubShader
	{

		Pass
		{/*幕后处理实际上是在场景中绘制了一个与屏幕同宽同高的四边形面片，为了防止它对其他物体产生影响，我们需要
		 设置相关的渲染状态
		 在这里，我们关闭了深度写入，是为了防止它“挡住”在其后面被渲染的物体。*/
			ZTest Always Cull Off ZWrite Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


		//声明对应变量
		sampler2D _MainTex;
		half _Brightness;
		half _Saturation;
		half _Contrast;

		struct v2f
		{
			float4 pos : SV_POSITION;
			float2 uv : TEXCOORD0;
		};

		//顶点着色器
		/*使用了Unity内置的appdata_img结构体作为顶点着色器的输入
		它只包含了图像处理时必须的顶点坐标和纹理坐标等变量*/
		v2f vert(appdata_img v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			return o;
		}

		//片元着色器
		//实现调增亮度，饱和度，对比度
		fixed4 frag(v2f i) : SV_Target
		{
			//对原屏幕进行采样
			fixed4 renderTex = tex2D(_MainTex,i.uv);

		//Apply brightness 调整亮度
		//颜色值=源颜色*亮度系数
		fixed3 finalColor = renderTex.rgb * _Brightness;

		//饱和度的计算
		//计算对应的luminance(亮度值)，通过对每一个颜色分量乘以一个特定的系数再相加得到的
		fixed luminance = 0.2125 * renderTex.r + 0.7154 * renderTex.g + 0.0721 * renderTex.b;
		//使用该亮度值创建了一个饱和度为0的颜色值。
		fixed luminanceColor = fixed3(luminance, luminance, luminance);
		//使用_Saturation属性在  饱和度为0的颜色 和上一步得到的颜色 之间进行插值
		finalColor = lerp(luminanceColor, finalColor, _Saturation);

		//Apply contrast 对比度计算
		//创建一个对比度为零的颜色值（各分量均为0.5）
		fixed3 avgColor = fixed3(0.5, 0.5, 0.5);
		//使用_Contrast与 对比度为0的颜色值， 和 上一步得到的颜色之间进行插值
		finalColor = lerp(avgColor, finalColor, _Contrast);

		//返回最后的颜色值和a通道
		return fixed4(finalColor, renderTex.a);

		}
		ENDCG
	}
	}
}
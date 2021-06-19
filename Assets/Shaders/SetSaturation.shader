Shader "Unlit/BrightnessSaturationAndContrast"
{
	Properties
	{
		//������
		_MainTex("Texture", 2D) = "white" {}
		//����
		_Brightness("Brightness",Float) = 1
		//���Ͷ�
		_Saturation("Saturation",Float) = 1
		//�Աȶ�
		_Contrast("Contrat",Float) = 1
	}
		SubShader
	{

		Pass
		{/*Ļ����ʵ�������ڳ����л�����һ������Ļͬ��ͬ�ߵ��ı�����Ƭ��Ϊ�˷�ֹ���������������Ӱ�죬������Ҫ
		 ������ص���Ⱦ״̬
		 ��������ǹر������д�룬��Ϊ�˷�ֹ������ס��������汻��Ⱦ�����塣*/
			ZTest Always Cull Off ZWrite Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


		//������Ӧ����
		sampler2D _MainTex;
		half _Brightness;
		half _Saturation;
		half _Contrast;

		struct v2f
		{
			float4 pos : SV_POSITION;
			float2 uv : TEXCOORD0;
		};

		//������ɫ��
		/*ʹ����Unity���õ�appdata_img�ṹ����Ϊ������ɫ��������
		��ֻ������ͼ����ʱ����Ķ����������������ȱ���*/
		v2f vert(appdata_img v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			return o;
		}

		//ƬԪ��ɫ��
		//ʵ�ֵ������ȣ����Ͷȣ��Աȶ�
		fixed4 frag(v2f i) : SV_Target
		{
			//��ԭ��Ļ���в���
			fixed4 renderTex = tex2D(_MainTex,i.uv);

		//Apply brightness ��������
		//��ɫֵ=Դ��ɫ*����ϵ��
		fixed3 finalColor = renderTex.rgb * _Brightness;

		//���Ͷȵļ���
		//�����Ӧ��luminance(����ֵ)��ͨ����ÿһ����ɫ��������һ���ض���ϵ������ӵõ���
		fixed luminance = 0.2125 * renderTex.r + 0.7154 * renderTex.g + 0.0721 * renderTex.b;
		//ʹ�ø�����ֵ������һ�����Ͷ�Ϊ0����ɫֵ��
		fixed luminanceColor = fixed3(luminance, luminance, luminance);
		//ʹ��_Saturation������  ���Ͷ�Ϊ0����ɫ ����һ���õ�����ɫ ֮����в�ֵ
		finalColor = lerp(luminanceColor, finalColor, _Saturation);

		//Apply contrast �Աȶȼ���
		//����һ���Աȶ�Ϊ�����ɫֵ����������Ϊ0.5��
		fixed3 avgColor = fixed3(0.5, 0.5, 0.5);
		//ʹ��_Contrast�� �Աȶ�Ϊ0����ɫֵ�� �� ��һ���õ�����ɫ֮����в�ֵ
		finalColor = lerp(avgColor, finalColor, _Contrast);

		//����������ɫֵ��aͨ��
		return fixed4(finalColor, renderTex.a);

		}
		ENDCG
	}
	}
}
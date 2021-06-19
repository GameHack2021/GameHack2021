//12.2 
//����������ϣ����û������Ƿ���ã�
//��shader�Ľӿڣ�����Ӧ�������ȣ����Ͷȣ��Աȶȵ�ֵ�������µĲ��ʣ���ʾ����Ļ��


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̳�12.1���д����Ļ���PostEffectsBase
public class CameraSaturationSettings : PostEffectsBase
{
    //������Ч����Ҫ��shader�����ݴ˴�����Ӧ�Ĳ���
    public Shader briSatConShader;
    private Material briSatConMaterial;

    public Material material
    {
        get
        {
            //briSatConMaterial��ָ����shader �� CheckShaderAndCreateMaterial�õ���Ӧ�Ĳ���
            briSatConMaterial = CheckShaderAndCreateMaterial(briSatConShader, briSatConMaterial);
            return briSatConMaterial;
        }
    }

    //�ڽű����ṩ�������ȣ����Ͷȣ��ԱȶȵĲ���
    [Range(0.0f, 1.0f)]
    public float brightness = 1.0f;

    [Range(0.0f, 1.0f)]
    public float saturation = 1.0f;

    [Range(0.0f, 1.0f)]
    public float contrast = 1.0f;


    //����OnRenderImage������������������Ч����
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        //ÿ��OnRenderImage���������õ�ʱ�򶼼������Ƿ����
        if (material != null)
        {
            //������þͰѲ�������
            material.SetFloat("_Brightness", brightness);
            material.SetFloat("_Saturation", saturation);
            material.SetFloat("_Contrast", contrast);

            //�ٵ���Graphics.Blit���д���
            Graphics.Blit(src, dest, material);
        }
        else
        {
            //����ֱ�Ӱ�ͼ����ʾ����Ļ�ϣ������κδ���
            Graphics.Blit(src, dest);
        }

    }
}





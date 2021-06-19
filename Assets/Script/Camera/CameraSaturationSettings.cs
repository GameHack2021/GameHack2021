//12.2 
//放在摄像机上，调用基类检查是否可用，
//有shader的接口，并对应调整亮度，饱和度，对比度的值，建立新的材质，显示到屏幕上


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//继承12.1节中创建的基类PostEffectsBase
public class CameraSaturationSettings : PostEffectsBase
{
    //声明该效果需要的shader，并据此创建相应的材质
    public Shader briSatConShader;
    private Material briSatConMaterial;

    public Material material
    {
        get
        {
            //briSatConMaterial是指定的shader ， CheckShaderAndCreateMaterial得到对应的材质
            briSatConMaterial = CheckShaderAndCreateMaterial(briSatConShader, briSatConMaterial);
            return briSatConMaterial;
        }
    }

    //在脚本中提供调节亮度，饱和度，对比度的参数
    [Range(0.0f, 1.0f)]
    public float brightness = 1.0f;

    [Range(0.0f, 1.0f)]
    public float saturation = 1.0f;

    [Range(0.0f, 1.0f)]
    public float contrast = 1.0f;


    //定义OnRenderImage函数来进行真正的特效处理
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        //每当OnRenderImage函数被调用的时候都检查材质是否可用
        if (material != null)
        {
            //如果可用就把参数传递
            material.SetFloat("_Brightness", brightness);
            material.SetFloat("_Saturation", saturation);
            material.SetFloat("_Contrast", contrast);

            //再调用Graphics.Blit进行处理
            Graphics.Blit(src, dest, material);
        }
        else
        {
            //否则直接把图像显示到屏幕上，不做任何处理
            Graphics.Blit(src, dest);
        }

    }
}





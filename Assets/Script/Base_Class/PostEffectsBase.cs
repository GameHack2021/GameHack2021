using System.Collections.Generic;
using UnityEngine;

//在编辑模式执行
[ExecuteInEditMode]
//需要绑定组件（类型（相机））
[RequireComponent(typeof(Camera))]

public class PostEffectsBase : MonoBehaviour
{
    //新建检查资源函数 开始时调用
    protected void CheckResources()
    {
        //新建布尔类型 调用检查支持函数
        bool isSupported = CheckSupport();
        //如果 检查支持函数结果是假
        if (isSupported == false)
        {
            //调用没有支持函数
            NotSupported();
        }
    }

    //新建检查支持函数 调用CheckResources检查此平台上的支持
    protected bool CheckSupport()
    {
        //if (访问系统和硬件信息.支持图像效果 为假  或  访问系统和硬件信息.支持渲染纹理 为假）
        if (SystemInfo.supportsImageEffects == false || SystemInfo.supportsRenderTextures == false)
        {

            //输出 balabala
            Debug.LogWarning("This Platform does not support image effects or render textures.");
            //返回 假
            return false;
        }
        //返回真
        return true;
    }

    //新建 没有支持 函数，当平台不支持此效果时调用
    protected void NotSupported()
    {
        //enabled  启用的行为被更新，禁用的行为没有被更新
        enabled = false;
    }

    //开始函数
    protected void Start()
    {
        //调用 检查资源函数
        CheckResources();
    }


    //当需要创建此效果所使用的材质时调用
    // 材质 检查着色器和创建材质 ，接受两个参数（渲染器，材质）
    protected Material CheckShaderAndCreateMaterial(Shader shader, Material material)
    {//检查 渲染器 可用性
        //如果 着色器为空
        if (shader == null)
        {
            //返回空
            return null;
        }

        //如果 着色器有纹理，有材质，有渲染器
        if (shader.isSupported && material && material.shader == shader)
        {
            //返回 
            return material;
        }
        if (!shader.isSupported)
        {
            return null;
        }

        else
        {
            //材质赋值
            material = new Material(shader);
            // 对象不会保存到场景中，当一个新的场景创建的时候也不会被销毁
            material.hideFlags = HideFlags.DontSave;

            //检查赋值成功就返回材质
            if (material)
                return material;
            else
                return null;
        }

    }
}
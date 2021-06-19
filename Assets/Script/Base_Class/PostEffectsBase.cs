using System.Collections.Generic;
using UnityEngine;

//�ڱ༭ģʽִ��
[ExecuteInEditMode]
//��Ҫ����������ͣ��������
[RequireComponent(typeof(Camera))]

public class PostEffectsBase : MonoBehaviour
{
    //�½������Դ���� ��ʼʱ����
    protected void CheckResources()
    {
        //�½��������� ���ü��֧�ֺ���
        bool isSupported = CheckSupport();
        //��� ���֧�ֺ�������Ǽ�
        if (isSupported == false)
        {
            //����û��֧�ֺ���
            NotSupported();
        }
    }

    //�½����֧�ֺ��� ����CheckResources����ƽ̨�ϵ�֧��
    protected bool CheckSupport()
    {
        //if (����ϵͳ��Ӳ����Ϣ.֧��ͼ��Ч�� Ϊ��  ��  ����ϵͳ��Ӳ����Ϣ.֧����Ⱦ���� Ϊ�٣�
        if (SystemInfo.supportsImageEffects == false || SystemInfo.supportsRenderTextures == false)
        {

            //��� balabala
            Debug.LogWarning("This Platform does not support image effects or render textures.");
            //���� ��
            return false;
        }
        //������
        return true;
    }

    //�½� û��֧�� ��������ƽ̨��֧�ִ�Ч��ʱ����
    protected void NotSupported()
    {
        //enabled  ���õ���Ϊ�����£����õ���Ϊû�б�����
        enabled = false;
    }

    //��ʼ����
    protected void Start()
    {
        //���� �����Դ����
        CheckResources();
    }


    //����Ҫ������Ч����ʹ�õĲ���ʱ����
    // ���� �����ɫ���ʹ������� ������������������Ⱦ�������ʣ�
    protected Material CheckShaderAndCreateMaterial(Shader shader, Material material)
    {//��� ��Ⱦ�� ������
        //��� ��ɫ��Ϊ��
        if (shader == null)
        {
            //���ؿ�
            return null;
        }

        //��� ��ɫ���������в��ʣ�����Ⱦ��
        if (shader.isSupported && material && material.shader == shader)
        {
            //���� 
            return material;
        }
        if (!shader.isSupported)
        {
            return null;
        }

        else
        {
            //���ʸ�ֵ
            material = new Material(shader);
            // ���󲻻ᱣ�浽�����У���һ���µĳ���������ʱ��Ҳ���ᱻ����
            material.hideFlags = HideFlags.DontSave;

            //��鸳ֵ�ɹ��ͷ��ز���
            if (material)
                return material;
            else
                return null;
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlatformIcon : MonoBehaviour
{
    private Image m_image;
    public IconCollections iconCollections;

    public eIconType IconType
    {
        get => m_iconType;
        set
        {
            m_iconType = value;
            Refresh();
        }
    }
    [SerializeField]
    private eIconType m_iconType;

    private eIconType m_cacheIconType;
    private string m_cacheDeviceName;
    void Awake()
    {
        m_image = GetComponent<Image>();
        Refresh();

        PlayerInput.OnLastInputChanged += Refresh;
    }

    void OnDestroy()
    {
        PlayerInput.OnLastInputChanged -= Refresh;
    }

    public async void Refresh()
    {
        if (m_image == null) return;
         if (m_cacheDeviceName == PlayerInput.s_LastDeviceDisplayName && m_cacheIconType == m_iconType) return;

        m_cacheDeviceName = PlayerInput.s_LastDeviceDisplayName;
        m_cacheIconType = m_iconType;
        Sprite sprite = null;
        if (iconCollections.Map.TryGetValue(m_iconType, out var mapper))
        {
            var deviceName = PlayerInput.s_LastDeviceDisplayName;
            if (!string.IsNullOrEmpty(deviceName)) 
            {
                switch(deviceName)
                {
                    case "Xbox Controller":
                        sprite = mapper.Xbox;
                        break;
                    case "Keyboard":
                    case "Mouse":
                        sprite = mapper.KeyBoardWASD;
                        break;
                    case "PlayStation Controller":
                        sprite = mapper.PlayStation;
                        break;
                    case "Switch Pro Controller":
                        sprite = mapper.Switch;
                        break;
                    default:
                        Debug.Log($"未找到适配的配置: {deviceName}");
                        sprite = mapper.KeyBoardWASD;
                        break;
                }
            }
            else
            {
                sprite = mapper.PlayStation;
            }
        }
        m_image.sprite = sprite;
        if (sprite != null)
        {
            float w = sprite.rect.width / sprite.pixelsPerUnit;
            float h = sprite.rect.height / sprite.pixelsPerUnit;
            var scalar = m_image.rectTransform.sizeDelta.y / h;
            m_image.rectTransform.anchorMax = m_image.rectTransform.anchorMin;
            m_image.rectTransform.sizeDelta = new Vector2(w * scalar, h * scalar);
        }
    }
#if UNITY_EDITOR
    void OnValidate()
    {
        Refresh();
    }
#endif
}

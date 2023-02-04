using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public struct IconPlatformMapper
{
    public Sprite Xbox;
    public Sprite Switch;
    public Sprite PlayStation;
    public Sprite KeyBoardWASD;
}

public enum eIconType
{
    Logo, Up, Down, Left, Right, Start
}

[CreateAssetMenu]
public class IconCollections : ScriptableObject, ISerializationCallbackReceiver
{
    public IconPlatformMapper Logo;
    public IconPlatformMapper Up;
    public IconPlatformMapper Down;
    public IconPlatformMapper Left;
    public IconPlatformMapper Right;
    public IconPlatformMapper Start;

    private Dictionary<eIconType, IconPlatformMapper> m_map;
    public IReadOnlyDictionary<eIconType, IconPlatformMapper> Map => m_map;
    public void OnAfterDeserialize()
    {
        if (m_map == null) m_map = new Dictionary<eIconType, IconPlatformMapper>();
        else m_map.Clear();

        m_map[eIconType.Logo] = Logo;
        m_map[eIconType.Up] = Up;
        m_map[eIconType.Down] = Down;
        m_map[eIconType.Left] = Left;
        m_map[eIconType.Right] = Right;
        m_map[eIconType.Start] = Start;
    }

    public void OnBeforeSerialize()
    {
    }
}

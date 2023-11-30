using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BulletSO", menuName ="BullType")]
public class BulletSO : ScriptableObject
{
    [SerializeField] List<GameObject> Listbullet = new List<GameObject>();
    [SerializeField] Sprite shopIcon;
    [SerializeField] float PointToBuy = 20000;
    [SerializeField] bool IsEquiped;
    [SerializeField] string BulletTypeName;

    public void SetIsEquiped()
    {
        IsEquiped = true;
        if(IsEquiped == true)
        {
            PlayerPrefs.SetString(BulletTypeName, BulletTypeName);
        }
    }
    public bool GetEquipedState()
    {
        if (IsEquiped == true)
        {
            return true;
        }
        else if (PlayerPrefs.HasKey(BulletTypeName))
        {
            return true;
        }
        return false;
    }
    public Sprite GetShopIcon()
    {
        return shopIcon;
    }
    public float GetPointToBuy()
    {
        return PointToBuy;
    }
    public int GetBulletCount()
    {
        return Listbullet.Count;
    }
    public GameObject GetBullet(int i)
    {
        return Listbullet[i];
    }
}

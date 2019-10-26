using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    //public Image ItemImage;
    //public void UpdateImage(Sprite s)
    //{
    //    ItemImage.sprite = s;   //更新图片
    //}

    public Text ItemName;
    public void UpdateItem(string name)
    {
        ItemName.text = name;
    }
}

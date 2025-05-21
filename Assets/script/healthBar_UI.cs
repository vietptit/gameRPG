using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar_UI : MonoBehaviour
{
    Entity entity;
    RectTransform UITransform;
    Slider thanhHP;

    float healMax;
    void Start()
    {
        entity = GetComponentInParent<Entity>();
        UITransform = GetComponent<RectTransform>();
        entity.onFlipped += FlipUI;
        thanhHP = GetComponentInChildren<Slider>();
        healMax = entity.heath;
    }

    void Update()
    {
        thanhHP.value = entity.heath / healMax;
        if (thanhHP.value <= 0)
            thanhHP.gameObject.SetActive(false);
    }



    void FlipUI()
    {
        UITransform.Rotate(0, 180, 0);
    }
}

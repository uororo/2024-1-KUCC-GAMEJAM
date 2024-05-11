using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public SpriteRenderer backgroundImage;
    public Sprite[] dayBackgrounds; // �� ���ں� ��� �̹���

    public void ChangeBackground(int day)
    {
        if (day >= 0 && day < dayBackgrounds.Length)
        {
            backgroundImage.sprite = dayBackgrounds[day]; // ��� �̹��� ��ü
        }
    }
}


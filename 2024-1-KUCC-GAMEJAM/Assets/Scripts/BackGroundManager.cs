using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public SpriteRenderer backgroundImage;
    public Sprite[] dayBackgrounds; // 각 일자별 배경 이미지

    public void ChangeBackground(int day)
    {
        if (day >= 0 && day < dayBackgrounds.Length)
        {
            backgroundImage.sprite = dayBackgrounds[day]; // 배경 이미지 교체
        }
    }
}


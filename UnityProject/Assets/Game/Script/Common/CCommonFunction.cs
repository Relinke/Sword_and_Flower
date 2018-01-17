using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public abstract class CCommonFunction
    {
        public static void SetImageAlpha(Image image, float alpha)
        {
            if (image.color.a == alpha)
            {
                return;
            }
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyAnimation
{
    [AddComponentMenu("EasyAnimation/透明渐变效果")]
    public class EasyAnimation_Fade : EasyAnimationTemplateMethod
    {
        [Header("起始透明度"), Range(0, 1)]
        public float startAlpha;

        [Header("结束透明度"), Range(0, 1)]
        public float endAlpha;

        private MaskableGraphic image;

        private bool isImage = false;

        protected override void Easy_Animation_Awake()
        {
            
            image = GetComponent<MaskableGraphic>();
            if (image != null)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, startAlpha);
                isImage = true;
            }
            
        }

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            if (isImage)
            {
                float i = ead.getProgress(time);
                float s = startAlpha + (endAlpha - startAlpha) * i;
                image.color = new Color(image.color.r, image.color.g, image.color.b, s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Rese()
        {
            if (isImage)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, startAlpha);
            }
        }
    }
}
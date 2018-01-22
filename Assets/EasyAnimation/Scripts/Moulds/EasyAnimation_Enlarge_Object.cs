using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EsayAnimation
{
    [AddComponentMenu("EasyAnimation/GameObject效果/Scale效果")]
    public class EasyAnimation_Enlarge_Object : EsayAnimationTemplateMethod
    {
        [Header("初始大小")]
        public Vector3 fromScale = Vector3.zero;
        [Header("结束大小")]
        public Vector3 toScale = Vector3.one;

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            transform.localScale = fromScale + (toScale - fromScale)* ead.getProgress(time);
            return true;
        }
    }

}
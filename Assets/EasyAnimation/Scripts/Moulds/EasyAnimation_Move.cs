using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EsayAnimation {

    [AddComponentMenu("EasyAnimation/UI效果/移动效果")]
    public class EasyAnimation_Move : EsayAnimationTemplateMethod
    {
        [Header("移动目标")]
        public Vector3 vector_To;

        [Header("反向")]
        public bool isInversion;

        private Vector3 nowPos;

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
            nowPos = transform.localPosition;
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            float i = ead.getProgress(time);
            if (isInversion)
            {
                i = 1 - i;
            }
            transform.localPosition = vector_To*i + nowPos;
            return true;
        }

        public override void Rese()
        {

        }
    }
}
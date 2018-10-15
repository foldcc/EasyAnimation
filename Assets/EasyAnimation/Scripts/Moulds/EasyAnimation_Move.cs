using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyAnimation {

    [AddComponentMenu("EasyAnimation/移动效果")]
    public class EasyAnimation_Move : EasyAnimationTemplateMethod
    {
        [Header("移动增量")]
        public Vector3 vector_To;

        private Vector3 nowPos;

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
            nowPos = transform.localPosition;
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            float i = ead.getProgress(time);
            transform.localPosition = vector_To*i + nowPos;
            return true;
        }

        public override void Rese()
        {
            transform.localPosition = initPostion;
        }
    }
}
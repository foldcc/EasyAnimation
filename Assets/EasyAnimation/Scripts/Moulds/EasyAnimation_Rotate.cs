using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyAnimation {
    [AddComponentMenu("EasyAnimation/旋转效果")]
    public class EasyAnimation_Rotate : EasyAnimationTemplateMethod
    {
        [Header("旋转增量")]
        public Vector3 incrementRotate = Vector3.zero;

        Vector3 lastRotation;

        protected override void Easy_Animation_Awake()
        {
            lastRotation = initRotation.eulerAngles;
        }

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            transform.localRotation = Quaternion.Euler(incrementRotate * ead.getProgress(time) + lastRotation);
            return true;
        }

        public override void Rese()
        {
            transform.localRotation = initRotation;
        }
    }
}


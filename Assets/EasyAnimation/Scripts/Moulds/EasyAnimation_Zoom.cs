using UnityEngine;

namespace EsayAnimation
{
    [AddComponentMenu("EasyAnimation/UI效果/缩放效果")]
    public class EasyAnimation_Zoom : EsayAnimationTemplateMethod
    {

        RectTransform rectTransform;

        protected override void Easy_Animation_Awake()
        {
            rectTransform = transform as RectTransform;
        }

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            rectTransform.localScale = Vector3.one  - ead.getProgressForVector3(time);
            return true;
        }
    }
}



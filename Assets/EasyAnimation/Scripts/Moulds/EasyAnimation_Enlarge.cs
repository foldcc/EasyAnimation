using UnityEngine;

namespace EsayAnimation {

    [AddComponentMenu("EasyAnimation/UI效果/放大效果")]
    public class EasyAnimation_Enlarge : EsayAnimationTemplateMethod
    {

        RectTransform rectTransform;

        Vector3 rectSize = Vector3.one;

        protected override void Easy_Animation_Awake()
        {
            rectTransform = transform as RectTransform;
            rectSize = rectTransform.localScale;
        }

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            rectTransform.localScale = rectSize * ead.getProgress(time) ;
            return true;
        }
    }
}

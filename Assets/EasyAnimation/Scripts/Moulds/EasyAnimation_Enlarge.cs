using UnityEngine;

namespace EasyAnimation {

    [AddComponentMenu("EasyAnimation/缩放效果")]
    public class EasyAnimation_Enlarge : EasyAnimationTemplateMethod
    {

        Vector3 rectSize = Vector3.one;

        protected override void Easy_Animation_Awake()
        {
            rectSize = transform.localScale;
        }

        protected override void PrimitiveOperation_Start()
        {
            ead = new EaseAinmationDrive(1, 0, 1, easetype);
        }

        protected override bool PrimitiveOperation_UpDate(float time)
        {
            transform.localScale = rectSize * ead.getProgress(time) ;
            return true;
        }

        public override void Rese()
        {
            transform.localScale = initScale;
        }
    }
}

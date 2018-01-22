using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EsayAnimation
{
    public class EaseAinmationDrive
    {
        public float maxTime;
        public float startNum;
        public float overNum;
        public Vector3 startVector;
        public Vector3 overVector;
        public EaseActionMethod easeType;

        /// <summary>
        /// 初始化动画事件
        /// </summary>
        /// <param name="maxTime">最大时间</param>
        /// <param name="startNum">初始倍率</param>
        /// <param name="overNum">结束倍率</param>
        /// <param name="easeType">缓动函数类型</param>
        public EaseAinmationDrive(float maxTime,  float startNum, float overNum, EaseActionMethod easeType) {
            this.maxTime = maxTime;
            this.overNum = overNum;
            this.startNum = startNum;
            this.easeType = easeType;
            startVector = Vector3.one * startNum;
            overVector = Vector3.one * overNum;
        }


        public float getProgress(float time) {
            if (time < 0)
                time = 0;
            else if (time >  maxTime)
                time =  maxTime;

            return EaseAction.GetEaseAction(easeType, time / maxTime * (overNum - startNum) + startNum);
        }

        public Vector3 getProgressForVector3(float time) {
            if (time < 0)
                time = 0;
            else if (time > maxTime)
                time = maxTime;
            return new Vector3(
                EaseAction.GetEaseAction(easeType, time / maxTime * (overVector.x - startVector.x) + startVector.x) , 
                EaseAction.GetEaseAction(easeType, time / maxTime * (overVector.y - startVector.y) + startVector.y) , 
                EaseAction.GetEaseAction(easeType, time / maxTime * (overVector.z - startVector.z)) + startVector.z);
        }
    }
}

  

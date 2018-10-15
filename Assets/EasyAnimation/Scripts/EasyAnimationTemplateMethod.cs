using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EasyAnimation {

    public enum PlayActionType {
        On_Start,
        On_End
    }


    /// <summary>
    /// 动画播放模板
    /// </summary>
    abstract public class EasyAnimationTemplateMethod : MonoBehaviour
    {
        [Header("自动播放")]
        public bool isAutoPlay = false;

        [Header("反向播放")]
        public bool isReverse = false;

        [Header("往返播放")]
        public bool isBack = false;

        [Header("循环播放")]
        public bool isLoop = false;

        [Header("缓动函数类型")]
        public EaseActionMethod easetype;

        [Header("动画时长"), Range(0.01f, 4)]
        public float animationTime = 0.25f;

        [Header("当前时间轴(仅用于观察动画播放情况)"), Range(0, 4)]
        public float animationNowTime = 0;

        /// <summary>
        /// 缓动函数驱动器
        /// </summary>
        protected EaseAinmationDrive ead;

        protected Vector3 initPostion;

        protected Quaternion initRotation;

        protected Vector3 initScale;

        private float playSpeed = 1;
        /// <summary>
        /// 判断是否初始化
        /// </summary>
        private bool isInit = false;
        /// <summary>
        /// 用于判断是否正在播放中，防止同时播放多次
        /// </summary>
        private bool isPlaying = false;

        void OnEnable() {

            if (!isInit)
            {
                initAction();
                Easy_Animation_Awake();
                isInit = true;
            }
            if (isAutoPlay)
            {
                rPlay();
            }
        }

        void OnDisable() {
            if (isPlaying) {
                StopCoroutine(animationDrive());
                play_end();
            }
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        protected virtual void Easy_Animation_Awake() { }

        /// <summary>
        /// 动画播放前触发事件
        /// </summary>
        private Action start_Actions;
        /// <summary>
        /// 动画播放结束触发事件
        /// </summary>
        private Action end_Actions;

        /// <summary>
        /// 播放动画模板，0.02s/执行一次,返回false时 执行跳出
        /// </summary>
        /// <returns>当返回值为true 表示播放进行中 false表示播放结束</returns>
        protected virtual bool PrimitiveOperation_UpDate(float time) {
            return false;
        }
        /// <summary>
        /// 当每个周期播放时初始化执行一次
        /// </summary>
        protected virtual void PrimitiveOperation_Start() {

        }
        /// <summary>
        /// 复位
        /// </summary>
        public virtual void Rese() {
            transform.localScale = initScale;
            transform.localRotation = initRotation;
            transform.localPosition = initPostion;
        }

        /// <summary>
        /// 动画驱动器
        /// </summary>
        /// <returns></returns>
        private IEnumerator animationDrive() {
            do
            {
                Rese();
                PrimitiveOperation_Start();
                animationNowTime = 0;
                playSpeed = 1;
                PrimitiveOperation_UpDate(0);
                while (PrimitiveOperation_UpDate(getPlayValue(animationNowTime / animationTime))) {
                    yield return 0;
                    animationNowTime += Time.deltaTime * playSpeed;
                    if (isBack && gameObject.activeSelf)
                    {
                        if (playSpeed > 0)
                        {
                            if (animationNowTime >= animationTime)
                            {
                                animationNowTime = animationTime - 0.01f;
                                playSpeed = -1;
                            }
                        }
                        else if (playSpeed == -1)
                        {
                            if (animationNowTime <= 0)
                            {
                                animationNowTime = 0f;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (playSpeed <= 0)
                        {
                            playSpeed = 1;
                        }
                    }

                    if (animationNowTime >= animationTime)
                    {
                        break;
                    }
                }
                yield return 0;
            } while (isLoop);
            play_end();
            yield return 0;
        }

        private float getPlayValue(float value , float max = 1) {
            if (isReverse)
            {
                return max - value;
            }
            else {
                return value;
            }
        }

        /// <summary>
        /// 钩子方法用于确定是否播放，可重写，默认播放
        /// </summary>
        /// <returns></returns>
        protected bool isPlay()
        {
            return true;
        }

        /// <summary>
        /// 动画播放开始
        /// </summary>
        private void play_start()
        {
            isPlaying = true;
            if(start_Actions != null)
                start_Actions();
        }

        /// <summary>
        /// 动画播放结束
        /// </summary>
        protected void play_end()
        {
            if (isBack)
            {
                animationNowTime = getPlayValue(0 , animationTime);
                PrimitiveOperation_UpDate(getPlayValue(0));
            }
            else {
                animationNowTime = getPlayValue(animationTime , animationTime);
                PrimitiveOperation_UpDate(getPlayValue(1));
            }
            isPlaying = false;
            if(end_Actions != null)
                end_Actions();
        }

        /// <summary>
        /// 模板方法模板
        /// </summary>
        private void TemplateMethod()
        {
            play_start();
            StartCoroutine(animationDrive());
        }

        /// <summary>
        /// 开始播放动画（不进行复位）
        /// </summary>
        public void Play() {
            if (isPlay() && !isPlaying && gameObject.activeSelf) {
                TemplateMethod();
            }
        }

        /// <summary>
        /// 先进行重置复位在开始播放动画
        /// </summary>
        public void rPlay()
        {
            Rese();
            if (isPlay() && !isPlaying && gameObject.activeSelf)
            {
                TemplateMethod();
            }
        }

        /// <summary>
        /// 结束动画播放
        /// </summary>
        public void Stop() {
            if (isPlaying)
            {
                StopCoroutine(animationDrive());
                play_end();
            }
        }

        /// <summary>
        /// 刷新原始的重置位置信息
        /// </summary>
        public void initAction() {
            initPostion = transform.localPosition;
            initRotation = transform.localRotation;
            initScale = transform.localScale;
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="e">Active</param>
        /// <param name="type">动画播放类型</param>
        public void addListener(Action e , PlayActionType type) {
            if (type == PlayActionType.On_Start)
            {
                start_Actions += e;
            }
            else
            {
                end_Actions += e;
            }
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="e"></param>
        /// <param name="type"></param>
        public void removeListener(Action e, PlayActionType type) {
            
            if (type == PlayActionType.On_Start)
            {
                if (start_Actions != null)
                    start_Actions -= e;
            }
            else
            {
                if (end_Actions != null)
                    end_Actions -= e;
            }
        }
    }
}

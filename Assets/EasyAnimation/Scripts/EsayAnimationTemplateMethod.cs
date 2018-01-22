using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EsayAnimation {

    public enum PlayActionType {
        On_Start,
        On_End
    }


    /// <summary>
    /// 动画播放模板
    /// </summary>
    abstract public class EsayAnimationTemplateMethod : MonoBehaviour
    {
        [Header("自动播放")]
        public bool isAutoPlay = false;

        [Header("往返播放")]
        public bool isBack = false;

        [Header("循环播放")]
        public bool isLoop = false;

        [Header("缓动函数类型")]
        public EaseActionMethod easetype;

        [Header("动画时长"), Range(0.01f, 2)]
        public float animationTime = 0.25f;

        [Header("当前时间轴(仅用于观察动画播放情况)"), Range(0, 2)]
        public float animationNowTime = 0;

        [Header("开始时触发动画事件")]
        public EsayAnimationTemplateMethod[] start_animation_actions;

        [Header("结束后触发动画事件")]
        public EsayAnimationTemplateMethod[] end_animation_actions;

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
                Play();
            }
        }

        void OnDisable() {
            if (isPlaying) {
                StopCoroutine(animationDrive());
                play_end();
            }
            Rese();
        }

        /// <summary>
        /// 初始化方法
        /// </summary>
        protected virtual void Easy_Animation_Awake() {}

        /// <summary>
        /// 动画播放前触发事件
        /// </summary>
        private List<Action> start_Actions;
        /// <summary>
        /// 动画播放结束触发事件
        /// </summary>
        private List<Action> end_Actions;

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
                PrimitiveOperation_Start();
                animationNowTime = 0;
                while (PrimitiveOperation_UpDate(animationNowTime/animationTime)) {
                    yield return 0;
                    animationNowTime += 0.02f * playSpeed;
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
                        else
                        {
                            if (animationNowTime <= 0)
                            {
                                animationNowTime = 0.01f;
                                playSpeed = 1;
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
            if (start_Actions != null && start_Actions.Count > 0)
            {
                foreach (Action e in start_Actions)
                {
                    e();
                }
            }
        }

        /// <summary>
        /// 动画播放结束
        /// </summary>
        protected void play_end()
        {
            animationNowTime = animationTime;
            PrimitiveOperation_UpDate(1);
            isPlaying = false;
            if (end_Actions != null && end_Actions.Count > 0) {
                foreach (Action e in end_Actions) {
                    e();
                }
            }
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
        /// 开始播放动画
        /// </summary>
        public void Play() {
            Rese();
            if (isPlay() && !isPlaying && gameObject.activeSelf) {
                TemplateMethod();
            }
        }

        /// <summary>
        /// 初始化本地事件
        /// </summary>
        private void initAction() {
            initPostion = transform.localPosition;
            initRotation = transform.localRotation;
            initScale = transform.localScale;

            if (start_animation_actions != null && start_animation_actions.Length > 0) {
                foreach (EsayAnimationTemplateMethod e in start_animation_actions) {
                    addListener(e , PlayActionType.On_Start);
                }
            }
            if (end_animation_actions != null && end_animation_actions.Length > 0)
            {
                foreach (EsayAnimationTemplateMethod e in end_animation_actions)
                {
                    addListener(e, PlayActionType.On_End);
                }
            }
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="e">Active</param>
        /// <param name="type">动画播放类型</param>
        public void addListener(Action e , PlayActionType type) {
            if (type == PlayActionType.On_Start)
            {
                if (start_Actions == null) {
                    start_Actions = new List<Action>();
                }
                start_Actions.Add(e);
            }
            else
            {
                if (end_Actions == null)
                {
                    end_Actions = new List<Action>();
                }
                end_Actions.Add(e);
            }
        }

        public void addListener(EsayAnimationTemplateMethod e, PlayActionType type) {
            if (type == PlayActionType.On_Start)
            {
                if (start_Actions == null)
                {
                    start_Actions = new List<Action>();
                }
                start_Actions.Add(e.Play);
            }
            else
            {
                if (end_Actions == null)
                {
                    end_Actions = new List<Action>();
                }
                end_Actions.Add(e.Play);
            }
        }

        
    }
}

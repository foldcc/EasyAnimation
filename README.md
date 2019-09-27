# EasyAnimation

![Unity 5][1] ![Unity 2017][2] ![Unity 2018][3]

---

[下载插件](https://gitee.com/Foldcc/EasyAnimation/releases)

## 简介

> **该项目停止维护，推荐使用另外一套UI动画系统 [MintAnimation](https://github.com/foldcc/MintAnimation) , 这套动画系统灵活性更高，且性能优化远高于EasyAnimation，能做到0 GC Alloc。**

EasyAnimation是一套简单并适用于UI系统的动画控制工具，满足大部分UI的动画效果，最大的优势在于创建动画轻便易上手，可灵活控制支持多效果复合。
使用Unity的动画系统来控制UI显得太过庞大臃肿，针对UI的通用性控制不够灵活并且麻烦，相比之下该工具集成了大部分UI动效并且开放了动画播放的控制接口以及监听事件，更加简单。
> [2018-8-13] 由于录制GIF图时帧率较低，该页面显示效果可能有所欠佳，可自行在Unity上测试实际效果 
> **注：图片较多流量消耗可能较高**

**效果演示-"缩放效果"** 
点击属性面板选择EasyAnimation选项选择缩放效果并设置自动播放

![缩放效果][4]

## 动画效果

EasyAnimation动画通过缓动函数实现，目前实现了大约提供了十多种常用缓动效果，以下是几种常用缓动效果演示:

- Sine
![Sine][5]

- Bounce
![Bounce][6]

- Back
![Back][7]

缓动函数可为系统提供稳定的动画效果，并且未来会逐步测试增加新的效果。

## 动画类型

目前提供3种类型分别为： 缩放(scale)、移动(postion)、透明度(alpha)

- 缩放效果
![缩放效果][8]
- 移动
![移动][9]
- 透明度
![透明度][10]

## 系统机制

### 事件监听

每一个动画提供两个监听事件，分别为

- OnStart : 该动画Play()之后和开始播放前执行

- OnEnd ：该动画结束播放之后执行

注册监听方法
**public void addListener(Action e , PlayActionType type)**

### 动画播放周期流程图

![动画周期][11]

## 使用介绍

导入该插件后

- 选种任意UI对象点击属性面板的Add Component按钮添加EasyAnimation

- 选择需要的动画类型

- 设置参数，勾选自动播放

- 当该UI被创建或者被激活时 自动播放设置好的动画

  [1]: https://img.shields.io/badge/Unity-5-red.svg
  [2]: https://img.shields.io/badge/Unity-2017-blue.svg
  [3]: https://img.shields.io/badge/Unity-2018-green.svg
  [4]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1001.gif
  [5]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1003.gif
  [6]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1004.gif
  [7]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1005.gif
  [8]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1001.gif
  [9]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1007.gif
  [10]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1006.gif
  [11]: https://fold.oss-cn-shanghai.aliyuncs.com/Geeit/EasyAnimation/1008.png

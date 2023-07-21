# UtilityAIEditor

> 这是一个基于[xNode](https://github.com/Siccity/xNode)和[Odin](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)的最小UtilityAI节点编辑器，在Unity中使用，`UtilityAIEditor`定义了许多常用的评分，选择办法，不包含任何具体的AI逻辑，可以在任何情况下使用，方便的组织AI代码。

![](D:\GitHub\UtilityAI\Image\示例.png)

## Action and Scene

AI的具体执行逻辑完全由用户自定义，在`UtilityAIEditor`中，AI被分为`Action` 和`Scene`，这是两种`ScriptableObject`，由上下文资源`IAIContext`连接起来。

### ActionScriptableObject

定义一个`Action`，只需继承`ActionScriptableObject`，然后创建一个asset资产，`Action`是AI在确认将执行某种行动时执行的代码。

```c#
[CreateAssetMenu]
public class MyAction : ActionScriptableObject
{
    public override void Execute(IAIContext context)
    {
    // ......
    }
}
```

### SceneScriptableObject

`Scene`与`Action`类似，定义一个Scene需要继承`SceneScriptableObject`，然后创建一个asset资产，`Scene`代表一种情景，是AI用于判断当前`IAIContext`的各种信息的代码。如何判断是完全自定义的，最终，你可以得到简单的`Scene`和复杂的图表，或者相反。

```c#
[CreateAssetMenu]
public class MyScene : SceneScriptableObject
{
    public override float Evaluate(IAIContext context)
    {
        // ......
    }
}
```

### IAIContext

`IAIContext`是一个空接口，实现`IAIContext`的类用于在所有节点间传递消息，`IAIContext`应该包含所有AI需要了解的信息。

## 节点编辑器

### AIGraph

`AIGraph`是编辑器的主要组成，可以使用各种节点在编辑器中可视化的组合`Scene`和`Action`的运行模式，

#### 决策器

决策器是`AIGraph`的输出和开始节点，外部需要调用决策器才能开始AI流程，决策器有一个可配置的值作为AI Lod的依据，可以依此实现负载均衡。在一个`AIGraph`中限制只能存在一个决策器节点，决策器没有输出端口，输入端口只能接受一个选择器节点。

#### 选择器

选择器是`AIGraph`根据评分做出决定的地方，选择器根据其规则对所有动作的评分进行选择，最后返回被选中的动作，选择器的输出只能连接决策器，输入可以连接多个动作绑定器。

##### 取高选择器

这个选择器返回得分最高的动作。

##### 随机选择器

这个选择器可以设置一个整数值数量=N，将首先选择得分最高的最多N个动作，然后返回其中的随机一项。

#### 动作绑定器

动作绑定器用来连接`AIGraph`和`ActionScriptableObject`资产，在图中代表一个动作，输出必须是一个选择器，输入必须是一个计分器。

##### 动作绑定器集

`动作绑定器集`是一种特殊的`动作绑定器`，可以用于连接一个`动作绑定集`，被视为多个`动作绑定器`。

#### 计分器

`计分器`用于得到动作的分数，将连接的`评估器`得到的分数组合起来作为最终分数，输入可以连接多个`评估器`，输出只能连接一个`动作绑定器`。

##### 加法计分器

输出所有评估分数之和。

##### 平均计分器

输出所有评估分数的平均值。

##### 取高计分器

输出评估分数的最大值。

##### 取低计分器

输出评估分数的最小值。

##### 乘法计分器

输出评估分数之积。

#### 评估器

`评估器`连接`SceneScriptableObject`，将Evaluate()方法返回的值进行修正后输出给`计分器`，用于计算一个动作在一个情景下的得分，所有直接的评估器都有一个可设置的权重值来缩放大小。

##### 曲线评估器

这个评估器需要设置一条曲线，返回Scene.Evaluate()在采样曲线函数后的结果值。

##### 自定义评估器

这个评估器直接返回Scene.Evaluate()的值，当希望直接在代码中处理评估时使用。

##### 阈值评估器

这个评估器设置一个阈值N和一个反转值B，

B=false:

Scene.Evaluate()>N返回1，否则返回0。

B=true:

Scene.Evaluate()>N返回0，否则返回1。

##### 计分器评估器

这个`评估器`接受一个`计分器`输入，返回`计分器`的结果值，可以在希望使用复杂的计分方式，在计算一个动作时使用多个计分器时使用。

##### 评估器集

评估器集是一个特殊的`评估器`，用来连接一个`评估器集`，可以视为多个`评估器`。

### 动作绑定器和评估器集

在很多时候动作和情景具有固定的组合，`动作绑定器集`和`评估器集`可以用来简化这些情况下的固定节点，要使用`动作绑定器集`和`评估器集`，需要创建相应的图资源，在这两种子图中，需要创建相应的唯一节点子图输出/动作绑定器集或评估器集，子图输出节点的输入可以连接多个`动作绑定器`或者`评估器`节点，在`AIGraph`中，使用相应的集节点连接子图，即可使用预制的多个动作组合或者情景评估组合。

## 安装

- 在安装前，需要确保已经安装了[xNode](https://github.com/Siccity/xNode)和[Odin](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)

- 下载或克隆此存储库复制到您的项目文件夹中

- 在`Package Manager`中选择`Add Package form git URL`，使用以下链接

  ```
  https://github.com/zhl-dru/UtilityAIEditor.git
  ```






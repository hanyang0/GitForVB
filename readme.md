---
title: Markdown语法概述
lang: zh
date: 2019/3/7 18:45:12
type: post
---

# Markdown语法概述

Markdown 是一种方便记忆、书写的纯文本标记语言，用户可以使用这些标记符号以最小的输入代价生成极富表现力的文档：譬如您正在阅读的这份文档。它使用简单的符号标记不同的标题，分割不同的段落，**粗体** 或者 *斜体* 某些文字

## 1. 斜体和粗体

使用 * 和 ** 表示斜体和粗体。

示例：

这是 *斜体*，这是 **粗体**。

## 2. 分级标题

在行首加井号表示不同级别的标题 (H1-H6)，例如：# H1, ## H2, ### H3，#### H4。

## 3. 外链接

使用 \[描述](链接地址) 为文字增加外链接。

示例：

这是去往 [本人博客](http://blog.richasy.cn) 的链接。

## 4. 无序列表

使用 *，+，- 表示无序列表。

示例：

- 无序列表项 一
- 无序列表项 二
- 无序列表项 三

## 5. 有序列表

使用数字和点表示有序列表。

示例：

1. 有序列表项 一
2. 有序列表项 二
3. 有序列表项 三

## 6. 文字引用

使用 > 表示文字引用。

示例：

> 野火烧不尽，春风吹又生。

## 7. 行内代码块

使用 \`代码\` 表示行内代码块。

示例：

让我们聊聊 `html`。

## 8.  代码块

使用 四个缩进空格 表示代码块。

示例：

    这是一个代码块，此行左侧有四个不可见的空格。

## 9.  插入图像

使用 \!\[描述](图片链接地址) 插入图像。

示例：

![others-app_icon_options_justalk.png](http://storage.live.com/items/51816931BAB0F7A8!8889?authkey=AO7QXpgYo7-5DUU)

## 10. 删除线

使用 ~~ 表示删除线。

~~这是一段错误的文本。~~

## 11. 注脚

使用 \^[keyword] 表示注脚。

这是一个注脚^[footnote]的样例。

这是第二个注脚^[footnote]的样例。

这是第三个注脚^[footnote]的样例。

## 12. KaTeX 公式

$ 表示行内公式： 

质能守恒方程可以用一个很简洁的方程式 $E=mc^2$ 来表达。

\$\$ 表示整行公式:

$$\sum_{i=1}^n a_i=0 $$

$$f(x_1,x_x,\ldots,x_n) = x_1^2 + x_2^2 + \cdots + x_n^2$$

$$x = {-b \pm \sqrt{b^2-4ac} \over 2a}.$$

## 13. 加强的代码块

支持四十一种编程语言的语法高亮的显示，行号显示。

非代码示例：

```
$ sudo apt-get install vim-gnome
```

Python 示例：

```python
@requires_authorization
def somefunc(param1='', param2=0):
    '''A docstring'''
    if param1 > param2: # interesting
        print 'Greater'
    return (param2 - param1 + 1) or None

class SomeClass:
    pass

>>> message = '''interpreter
... prompt'''
```

JavaScript 示例：

``` javascript
/**
* nth element in the fibonacci series.
* @param n >= 0
* @return the nth element, >= 0.
*/
function fib(n) {
  var a = 1, b = 1;
  var tmp;
  while (--n >= 0) {
    tmp = a;
    a += b;
    b = tmp;
  }
  return a;
}

document.write(fib(10));
```

## 14. Html 标签

软件支持在 Markdown 语法中嵌套 Html 标签，譬如，你可以用 Html 写一个纵跨两行的表格：

    <table>
        <tr>
            <th rowspan="2">值班人员</th>
            <th>星期一</th>
            <th>星期二</th>
            <th>星期三</th>
        </tr>
        <tr>
            <td>李强</td>
            <td>张明</td>
            <td>王平</td>
        </tr>
    </table>


<table>
    <tr>
        <th rowspan="2">值班人员</th>
        <th>星期一</th>
        <th>星期二</th>
        <th>星期三</th>
    </tr>
    <tr>
        <td>李强</td>
        <td>张明</td>
        <td>王平</td>
    </tr>
</table>

## 15. 待办事宜 Todo 列表

使用带有 `[ ]` 或 `[x]` （未完成或已完成）项的列表语法撰写一个待办事宜列表，并且支持子列表嵌套以及混用Markdown语法，例如：

    - [ ] **采买清单**
        - [ ] Surface Studio
        - [ ] Microsoft Hololens
        - [x] Surface Phone
        
对应显示如下待办事宜 Todo 列表：
        
- [ ] **采买清单**
   - [ ] Surface Studio
    - [ ] Microsoft Hololens
    - [x] Surface Phone

## 16. 高亮标记

使用\==标记文字\==来对指定文本进行标记

如 ==我是一段被标记的文字==

## 17. 上标与下标

使用 \^搞事情\^ 对文本进行上标处理，使用 \~下标\~ 渲染出来是这样：

这是一段包含着^上标^与~下标~的文字

## 18. 预设容器

软件提供了三种常用的自定义容器，分别是tip、warning、danger，使用方式如下

```markdown
:::tip
我是一段提示文字
:::

::warning
我是一段警告文字
:::

::danger
我是一段危险警示文字
:::
```

:::tip
我是一段提示文字
:::

:::warning
我是一段警告文字
:::

:::danger
我是一段危险警示文字
:::

## 19.UML绘图支持

UML是一种常用的绘图语言，可以方便地画出时序图、流程图、用例图等。

```markdown
@startuml

title:时序图

== 鉴权阶段 ==

Alice -> Bob: 请求
Bob -> Alice: 应答

== 数据上传 ==

Alice -> Bob: 上传数据
note left: 这是显示在左边的备注

Bob --> Canny: 转交数据
... 不超过 5 秒钟 ...
Canny --> Bob: 状态返回
note right: 这是显示在右边的备注

Bob -> Alice: 状态返回

== 状态显示 ==

Alice -> Alice: 给自己发消息
@enduml
```

@startuml

title:时序图
== 鉴权阶段 ==

Alice -> Bob: 请求
Bob -> Alice: 应答

== 数据上传 ==

Alice -> Bob: 上传数据
note left: 这是显示在左边的备注

Bob --> Canny: 转交数据
... 不超过 5 秒钟 ...
Canny --> Bob: 状态返回
note right: 这是显示在右边的备注

Bob -> Alice: 状态返回

== 状态显示 ==

Alice -> Alice: 给自己发消息
@enduml

```markdown
@startuml

left to right direction
actor 消费者
actor 销售员
rectangle 买单 {
消费者 -- (买单)
(买单) .> (付款) : include
(帮助) .> (买单) : extends
(买单) -- 销售员
}

@enduml
```
@startuml

left to right direction
actor 消费者
actor 销售员
rectangle 买单 {
消费者 -- (买单)
(买单) .> (付款) : include
(帮助) .> (买单) : extends
(买单) -- 销售员
}

@enduml

```markdown
@startuml

title 流程图

start
:"步骤1处理";
:"步骤2处理";
if ("条件1判断") then (true)
    :条件1成立时执行的动作;
    if ("分支条件2判断") then (no)
        :"条件2不成立时执行的动作";
    else
        if ("条件3判断") then (yes)
            :"条件3成立时的动作";
        else (no)
            :"条件3不成立时的动作";
        endif
    endif
    :"顺序步骤3处理";
endif

if ("条件4判断") then (yes)
:"条件4成立的动作";
else
    if ("条件5判断") then (yes)
        :"条件5成立时的动作";
    else (no)
        :"条件5不成立时的动作";
    endif
endif
stop

@enduml
```

@startuml

title 流程图

start
:"步骤1处理";
:"步骤2处理";
if ("条件1判断") then (true)
    :条件1成立时执行的动作;
    if ("分支条件2判断") then (no)
        :"条件2不成立时执行的动作";
    else
        if ("条件3判断") then (yes)
            :"条件3成立时的动作";
        else (no)
            :"条件3不成立时的动作";
        endif
    endif
    :"顺序步骤3处理";
endif

if ("条件4判断") then (yes)
:"条件4成立的动作";
else
    if ("条件5判断") then (yes)
        :"条件5成立时的动作";
    else (no)
        :"条件5不成立时的动作";
    endif
endif
stop

@enduml
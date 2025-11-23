* 原案: スコープ関数 `apply` は、レシーバーが持つメンバーを操作する時に使うこと。
* 英訳: Use the scope function `apply` when you want to operate on the members of the receiver object.
___

## 解説
下記引用のように、公式サイトで推奨されているため。

> As `apply` returns the context object itself, we recommend that you use it for code blocks that don't return a value and that mainly operate on the members of the receiver object.
> The most common use case for `apply` is for object configuration. Such calls can be read as " **apply the following assignments to the object.** "
>
> ``` kotlin
> data class Person(var name: String, var age: Int = 0, var city: String = "")
>
> fun main() {
>     val adam = Person("Adam").apply {
>         age = 32
>         city = "London"
>     }
>     println(adam)
> }
> ```
>
> 引用元: https://kotlinlang.org/docs/scope-functions.html#apply


## 参考文献
* https://kotlinlang.org/docs/scope-functions.html

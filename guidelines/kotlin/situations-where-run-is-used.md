* 原案: スコープ関数 `run` は、 `?:` の右辺で使っても良い。
* 英訳: You may use the scope function `run` on the right side of `?:`.
___

## 解説
レシーバーを変換したい場合、コーディング規約にあるように基本的には `let` を使う。
しかし、エルビス演算子 `?:` の右辺では使えないため、代わりに `run` を使っても良い。

``` kotlin
fun main() { 
    val expectZero = doubleOrDefault(null)
    println(expectZero) // 0
    
    val expectFour = doubleOrDefault(2)
    println(expectFour) // 4
}

fun doubleOrDefault(
    value: Int?,
) = value?.let { it * 2 } ?: run { 0 }

// サンプルコード: https://pl.kotl.in/uX1njgGh-
```

この例は単純な値の割り当てのため、 `value?.let { it * 2 } ?: 0` と記述できるが、
もし複雑な処理が必要な場合は、 `run` を使うことでひとまとめに記述できる。


## 関連するコーディング規約
* [situations-where-let-is-used.md](./situations-where-let-is-used.md)


## 参考文献
* https://kotlinlang.org/docs/scope-functions.html

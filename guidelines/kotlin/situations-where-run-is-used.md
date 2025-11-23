* 原案: スコープ関数 `run` は、 `?:` の右辺で使っても良い。
* 英訳: You may use the scope function `run` on the right side of `?:`.
___

## 解説
エルビス演算子 `?:` の右辺は、レシーバーが存在しない。
コーディング規約で基本的には `run` より `let` を推奨しているが、 
`let` はレシーバーが必要なため、このケースでは使えない。

一方、 `run` には `inline fun <R> run(block: () -> R): R` という実装があり、
エルビス演算子の右辺で使うことが出来る。

なので、１行で収まらない複雑な処理がある時は `run` を使うこと。

``` kotlin
fun main() { 
    val expectZero = doubleOrDefault(null)
    println(expectZero) // 0

    val expectFour = doubleOrDefault(2)
    println(expectFour) // 4
}

fun doubleOrDefault(
    value: Int?,
) = value?.let { it * 2 } ?: run {
    println("value is null")
    0
}

// Playground: https://pl.kotl.in/tJiUoGDOp
```


## 関連するコーディング規約
* [situations-where-let-is-used.md](./situations-where-let-is-used.md)


## 参考文献
* https://kotlinlang.org/api/core/kotlin-stdlib/kotlin/run.html
* https://kotlinlang.org/docs/scope-functions.html

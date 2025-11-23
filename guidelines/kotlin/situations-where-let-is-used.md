* 原案: スコープ関数 `let` は、レシーバーを変換したい時に使うこと。
* 英訳: Use the scope function `let` when you want to transform the receiver object.
___

## 解説
レシーバーを変換したい時、下記のようにスコープ関数 `let`, `run` を使用することが出来る。

``` kotlin
val complexData = Pair("Kotlin", "Kotlin is a concise and multiplatform programming language by JetBrains.")

val titleByLet = complexData.let { it.first }
println(titleByLet) // Kotlin

val titleByRun = complexData.run { first }
println(titleByRun) // Kotlin
```

ここに同名のローカル変数を追加すると、
`run` が指す `this` よりローカル変数が優先されるため、結果が変わってしまう。

``` kotlin
val first = "first"
val complexData = Pair("Kotlin", "Kotlin is a concise and multiplatform programming language by JetBrains.")

val titleByLet = complexData.let { it.first }
println(titleByLet) // Kotlin

val titleByRun = complexData.run { first }
println(titleByRun) // first

// サンプルコード: https://pl.kotl.in/oFqvpgDAX
```

なので `let` を使用し、変数のスコープを小さく保つこと。


## 参考文献
* https://kotlinlang.org/docs/scope-functions.html
* DroidKaigi
    * [Kotlinアンチパターン](https://2018.droidkaigi.jp/timetable?session=16969)

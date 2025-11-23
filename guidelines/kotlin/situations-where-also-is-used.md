* 原案: スコープ関数 `also` は、レシーバーが持つメンバーを他の処理で使いたい時に使うこと。
* 英訳: Use the scope function `also` when you want to use members of the receiver in other operations.
___

## 解説
レシーバーのプロパティやメソッドを他の処理で使いたい時、 基本的には `also` を使うこと。
他のスコープ関数でも同様の処理を記述できるが、意図しない挙動を招く可能性があるため避けること。

### `let` との使い分け
スコープ関数 `let` は、レシーバーを `it` で受け取れる点では `also` と同じだが、
例えば下記のように意図せず値を変えてしまうことがあるため、避けること。

``` kotlin
data class SomeData(val text: String)
val someData = SomeData("text from data class")

// NG: `patternNG` type is `int`
val patternNG = someData.let {
    android.util.Log.d("TAG", it.text)
}

// OK: `patternOK` type is `SomeData`
val patternOK = someData.also {
    android.util.Log.d("TAG", it.text)
}
```

### `apply` との使い分け
スコープ関数 `apply` は返り値を変更しないため、その点では `also` と同じように使うことも出来る。
ただし同名のローカル変数がある場合、 `apply` が指す `this` よりローカル変数が優先されるため、
結果が変わってしまうため、 `also` を使うこと。

``` kotlin
data class SomeData(val text: String)

val text = "text from local variable"
val someData = SomeData("text from data class")

someData.also { println(it.text) } // text from data class
someData.apply { println(text) } // text from local variable

// Playground: https://pl.kotl.in/7vP58y4FL
```


## 参考文献
* https://kotlinlang.org/docs/scope-functions.html
* DroidKaigi
    * [Kotlinアンチパターン](https://2018.droidkaigi.jp/timetable?session=16969)

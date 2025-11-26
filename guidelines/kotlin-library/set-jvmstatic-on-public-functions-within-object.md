* 原案: `companion object` または `object` 内の `public` 関数に `@JvmStatic` を設定すること。
* 英訳: Set `@JvmStatic` on `public` functions within the `companion object` or `object`.
___

## 解説
Kotlin の `companion object` はJava の `static` と同等ではない。
そのため `@JvmStatic` が無い関数をJava から呼び出した際、下記の例のように余分なアクセスが必要となる。
よりJava らしく書けるようにするため、アノテーションを付与すること。

### 例: `companion object` の場合
``` kotlin
public class C {
    public companion object {
        public fun callNonStatic() {}

        @JvmStatic public fun callStatic() {}
    }
}
```

これをJava から呼び出すと下記のようになる。

``` java
// NG: コンパイルエラー
C.callNonStatic();

// OK: 冗長だがアクセスできる
C.Companion.callNonStatic();
C.Companion.callStatic();

// OK: ベスト
C.callStatic();
```

### 例: `object` の場合
``` kotlin
public object Obj {
    public fun callNonStatic() {}

    @JvmStatic public fun callStatic() {}
}
```

これをJava から呼び出すと下記のようになる。

``` java
// NG: コンパイルエラー
Obj.callNonStatic();

// OK: 冗長だがアクセスできる
Obj.INSTANCE.callNonStatic();
Obj.INSTANCE.callStatic();

// OK: ベスト
Obj.callStatic();
```


## 参考文献
* https://developer.android.com/kotlin/interop#companion-functions
* https://kotlinlang.org/docs/java-to-kotlin-interop.html#static-methods

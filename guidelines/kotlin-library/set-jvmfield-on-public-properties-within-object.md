* 原案: `companion object` または `object` 内の `const` 以外の `public` なプロパティに `@JvmField` を設定すること。
* 英訳: Set `@JvmField` on `public` non-`const` properties within the `companion object` or `object`.
___

## 解説
Kotlin の `companion object` はJava の `static` と同等ではない。
そのため `@JvmField` が無い `const` 以外のプロパティをJava から呼び出した際、下記の例のように余分なアクセスが必要で、さらに名前も変わってしまう。
よりJava らしく書けるようにするため、アノテーションを付与すること。

### 例: `companion object` の場合
``` kotlin
public class C {
    public companion object {
        public val ONE = 1

        @JvmField public val ONE_FIELD = 1
        public const val ONE_CONST = 1
    }
}
```

これをJava から呼び出すと下記のようになる。

``` java
// NG: コンパイルエラー
C.getONE();

// OK: 冗長だがアクセスできる
C.Companion.getONE();

// OK: ベスト
C.ONE_FIELD;
C.ONE_CONST;
```

### 例: `object` の場合
``` kotlin
public object Obj {
    public val ONE = 1

    @JvmField public val ONE_FIELD = 1
    public const val ONE_CONST = 1
}
```

これをJava から呼び出すと下記のようになる。

``` java
// NG: コンパイルエラー
Obj.getONE();

// OK: 冗長だがアクセスできる
Obj.INSTANCE.getONE();

// OK: ベスト
Obj.ONE_FIELD;
Obj.ONE_CONST;
```


## 参考文献
* https://developer.android.com/kotlin/interop#companion-constants
* https://kotlinlang.org/docs/java-to-kotlin-interop.html#static-fields

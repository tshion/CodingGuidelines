# Use JSON instead of `java.io.Serializable`
## 規約
### 英訳
Use JSON instead of `java.io.Serializable`.

### 日本語の原案
`java.io.Serializable` の代わりにJSON を利用すること。


## 解説
### 元ネタ
> ### Recommended Alternatives
> **JSON** is concise, human-readable and efficient.
> Android includes both a `streaming API` and a `tree API` to read and write JSON.
> Use a binding library like GSON to read and write Java objects directly.
>
> 引用元: https://developer.android.com/reference/java/io/Serializable

### `java.io.Serializable` の問題点
ざっくりとは下記の点が挙げられる。
* 公開API としてサポートする必要が生じる
* セキュリティリスクがある

下記引用にもあるように、より詳しく知りたい場合は書籍 [Effective Java 第3版](https://www.maruzen-publishing.co.jp/book/b10120153.html) を参照すること。

> ### Implement Serializable Judiciously
> Refer to *Effective Java*'s chapter on serialization for thorough coverage of the serialization API.
> The book explains how to use this interface without harming your application's maintainability.
>
> 引用元: https://developer.android.com/reference/java/io/Serializable


## 参考文献
* https://developer.android.com/reference/java/io/Serializable

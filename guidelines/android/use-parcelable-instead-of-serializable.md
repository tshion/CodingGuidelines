* 原案: Android プロセス間で複雑なデータを送信する際、 `java.io.Serializable` ではなく `Parcelable` を利用すること。
* 英訳: When sending complex data between Android processes, use `Parcelable` instead of `java.io.Serializable`.
___

## 解説
`Parcelable` を継承した実装は、例えば `Intent` や `Bundle` が挙げられる。

`Intent#getSerializableExtra(String)` や `Bundle#getSerializable(String)` のように`java.io.Serializable` を取り扱うことも出来るが、[use-json-instead-of-serializable.md](../kotlin/use-json-instead-of-serializable.md) に記載したように問題があるため、代わりに `Parcelable` を利用すること。


## 参考文献
* https://developer.android.com/guide/components/activities/parcelables-and-bundles

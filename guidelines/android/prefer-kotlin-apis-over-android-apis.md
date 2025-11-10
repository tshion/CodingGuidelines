# Prefer Kotlin APIs over Android APIs
## 規約
### 英語
Prefer Kotlin APIs over Android APIs when they provide similar functionality.

### 日本語の原案
同様の機能が提供されている場合、Android API よりもKotlin API を優先して使用すること。


## 解説
例えば空文字かどうかを判定する際、下記の２つがある。

* Android API: `TextUtils.isEmpty(str)`
* Kotlin API: `str.isEmpty()`

どちらでも目的を達成することが出来るが、ユニットテストを組んだ際に違いが出てくる。

Android API はモックが必要になるため、
Android デバイス上で行うか、Robolectric への依存を追加する必要があるが、
Kotlin API では特に何もしなくともテストすることが出来る。

なので特別な理由が無い限り、Kotlin API を優先すること。


## 参考文献
* https://developer.android.com/training/testing/local-tests/robolectric

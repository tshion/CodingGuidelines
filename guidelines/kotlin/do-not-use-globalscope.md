* 原案: Kotlin Coroutine の `GlobalScope` を使用しないこと。
* 英訳: Do not use `GlobalScope` in Kotlin Coroutine.
___

## 解説
### API Document の記述
下記引用にもあるように、 `GlobalScope` は使い方によっては誤ってリソースリークやメモリリークを発生させる可能性があるため、原則使用しないこと。

> This is a **delicate** API.
> It is easy to accidentally create resource or memory leaks when `GlobalScope` is used.
> A coroutine launched in `GlobalScope` is not subject to the principle of structured concurrency, so if it hangs or gets delayed due to a problem (e.g., due to a slow network), it will stay working and consuming resources.
>
> For example, consider the following code:
> ``` kotlin
> fun loadConfiguration() {
>     GlobalScope.launch {
>         val config = fetchConfigFromServer() // network request
>         updateConfiguration(config)
>     }
> }
> ```
>
> A call to `loadConfiguration` creates a coroutine in the `GlobalScope` that works in the background without any provision to cancel it or to wait for its completion.
> If a network is slow, it keeps waiting in the background, consuming resources.
> Repeated calls to `loadConfiguration` will consume more and more resources.
>
> 引用元: https://kotlinlang.org/api/kotlinx.coroutines/kotlinx-coroutines-core/kotlinx.coroutines/-global-scope/

### Android で代替案
Android はJetPack ライブラリから、ライフサイクルに紐付いた `CoroutineScope` が提供されているので、それを利用すること。

* Activity: `lifecycleScope`
* Fragment: `viewLifecycleOwner.lifecycleScope`
* ViewModel: `viewModelScope`


## 参考文献
* https://kotlinlang.org/api/kotlinx.coroutines/kotlinx-coroutines-core/kotlinx.coroutines/-global-scope/
    * 和訳: https://blog.jetbrains.com/ja/kotlin/2021/06/kotlin-coroutines-1-5-0-released-ja/#globalscope

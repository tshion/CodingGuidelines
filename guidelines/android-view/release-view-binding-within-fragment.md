* 原案: `Fragment` 内でView binding の参照を保持している場合、 `onDestroyView` で解放すること。
* 英訳: When holding a *View binding* reference within a `Fragment`, release it in `onDestroyView`.
___

## 解説
> Note: Fragments outlive their views. Make sure you clean up any references to the binding class instance in the fragment's `onDestroyView()` method.
>
> 引用元: https://developer.android.com/topic/libraries/view-binding#fragments

## 参考文献
* https://developer.android.com/topic/libraries/view-binding

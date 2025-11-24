* 原案: View のネストを避けるために `ConstraintLayout` を使うこと。ただし単に重ねるだけであれば `FrameLayout` を使うこと。
* 英訳: To avoid nesting views, use `ConstraintLayout`. However, if you simply want to stack views, use `FrameLayout`.
___

## 解説
> A common reason for layout taking a long time is when hierarchies of `View` objects are nested within one another.
> Each nested layout object adds cost to the layout stage.
> The flatter your hierarchy, the less time it takes for the layout stage to complete.
>
> We recommend using the Layout Editor to create a `ConstraintLayout`, instead of `RelativeLayout` or `LinearLayout`, as it's generally both more efficient and reduces the nesting of layouts.
> However, for simple layouts that can be achieved using `FrameLayout`, we recommend using `FrameLayout`.
>
> 引用元: https://developer.android.com/topic/performance/rendering/optimizing-view-hierarchies#managing


## 参考文献
* https://developer.android.com/topic/performance/rendering/optimizing-view-hierarchies

* 原案: カスタムビューのレイアウトXML を実装する際、 `<merge>` タグを使うこと。
* 英訳: When implementing the layout XML for a custom view, use the `<merge>` tag.
___

## 解説
> The `<merge>` tag helps eliminate redundant view groups in your view hierarchy when including one layout within another.
> One use case of `<merge>` is when you implement a custom view by extending a `ViewGroup`.
>
> For example, if your main layout is a vertical `LinearLayout` in which two consecutive views can be reused in multiple layouts, then the reusable layout where you place the two views requires its own root view.
> However, using another `LinearLayout` as the root for the reusable layout results in a vertical `LinearLayout` inside a vertical `LinearLayout`.
> The nested `LinearLayout` serves no real purpose and slows down your UI performance.
>
> Instead, you can extend a `LinearLayout` to create a custom view and use a layout XML to describe its child views.
> The top tag in the XML is `<merge>`, rather than `LinearLayout`, as shown in the following example:
> ``` xml
> <merge xmlns:android="http://schemas.android.com/apk/res/android">
>     <Button
>         android:layout_width="fill_parent"
>         android:layout_height="wrap_content"
>         android:text="@string/add"/>
>
>     <Button
>         android:layout_width="fill_parent"
>         android:layout_height="wrap_content"
>         android:text="@string/delete"/>
> </merge>
> ```
>
> 引用元: https://developer.android.com/develop/ui/views/layout/improving-layouts/reusing-layouts#Merge


## 参考文献
* https://developer.android.com/topic/performance/rendering/optimizing-view-hierarchies#adopt-merge-or-include
* https://developer.android.com/develop/ui/views/layout/improving-layouts/reusing-layouts#Merge

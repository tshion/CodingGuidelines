* 原案: レイアウトXML にView を記述する際、まず重なり方向を地 → 天の順に記述し、同じ重なり階層のものは左上 → 右上 → 左下 → 右下の順に記述すること。
* 英訳: When describing views in the layout XML, sort them in z-order from back to front. For views at the same z-order, sort them in order: top-left → top-right → bottom-left → bottom-right.
___

## 解説
View の記述順が統一されていると、作業者が違っていても大体同じ場所にView が配置されるため、コードが読みやすくなる。

逆に統一されていないと、その時の作業者の気分によって記述されるため、コードがどんどん煩雑になってしまう。
特にGit マージでコンフリクトが起きた際、その解決をするのが困難になってしまうため、なるべく統一的に記述すること。


## 参考文献

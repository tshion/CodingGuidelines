# Separate improvements based on Boy Scout principles
## 規約
### 英訳
Separate improvements based on Boy Scout principles to keep clear context.

### 日本語の原案
ボーイスカウトの原則による改善は、目的がぼやけるため、別Pull Request にすること。


## 解説
プログラミングにおけるボーイスカウトの原則は、作業のついでにリファクタリングをして、コードを綺麗に保つことを指します。
一見良いことのように思えますが、例えば下記の時に困ってしまいます。

* 新しいAPI への書き換えの場合、作業範囲以外はそのままのため、統一感が無くなる
    * コードが作業対象になる頻度はバラバラのため、いつまでも古いAPI が残置されてしまう恐れがある
* 大幅なロジック変更の場合、その変更の要の部分なのかどうかの判断が難しくなる
* 主目的に対して他のPull Request の方が適している場合、リジェクトとなるため、綺麗にしたコードがマージされるタイミングを失ってしまう
* テスト範囲が広くなる
* バグ修正の場合、どれがバグを解消したコードなのか特定しづらくなる

なので、専用のPull Request を作成し、因果関係を明示してください。

### その他の文献
下記引用のような表現で言及されることがあります。
なお文中の `CL` は `ChangeList` の略です。

> ## Separate Out Refactorings
> It’s usually best to do refactorings in a separate CL from feature changes or bug fixes.
> For example, moving and renaming a class should be in a different CL from fixing a bug in that class.
> It is much easier for reviewers to understand the changes introduced by each CL when they are separate.
>
> Small cleanups such as fixing a local variable name can be included inside of a feature change or bug fix CL, though.
> It’s up to the judgment of developers and reviewers to decide when a refactoring is so large that it will make the review more difficult if included in your current CL.
>
> 引用元: https://google.github.io/eng-practices/review/developer/small-cls.html#refactoring


## 参考文献
* https://google.github.io/eng-practices/review/developer/small-cls.html#refactoring

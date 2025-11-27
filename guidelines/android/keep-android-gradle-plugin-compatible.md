* 原案: Android Gradle Plugin を更新する際、Gradle、JDK、Kotlin Gradle Plugin との互換性を維持すること。
* 英訳: Keep Android Gradle Plugin compatible with Gradle, JDK, and Kotlin Gradle Plugin when updating.
___

## 解説
Android Gradle Plugin(AGP) バージョンは、下記との間でサポート範囲が決められている。
更新する際は必ず公式ドキュメントを確認し、サポート範囲内に収めるようにすること。

* Android Studio
* Gradle
* JDK
* Kotlin Gradle Plugin(KGP)

### 例: Android OS アップデートする際の流れ
よくある作業の一つにAndroid OS のアップデート対応がある。
その場合 `compileSdk` の設定を変更する必要があるためAndroid API level の確認から始める。

※各引用にあるバージョンは 2025/11/17 時点での情報となる。実際に作業をする際は必ず最新情報を確認すること。

#### 1. Android API level の要求を確認する
導入したいAndroid API level に対応したAndroid Studio とAGP の最小バージョンを確認する。

> API level | Minimum Android Studio version | Minimum AGP version
> --- | --- | ---
> 36.1 | Narwhal 3 Feature Drop \| 2025.1.3 | 8.13.0
> 36.0 | Meerkat \| 2024.3.1 Patch 1 | 8.9.1
> (後略)
>
> 引用元: https://developer.android.com/build/releases/gradle-plugin#api-level-support

#### 2. AGP の要求を確認する
AGP バージョンに対応したGradle とJDK の最小バージョン、Android Studio のサポート範囲を確認する。
Gradle とJDK の表は、AGP バージョンごとのリリースノートに記載されている。

> | | Minimum version | Default version | Notes
> --- | --- | --- | ---
> Gradle | 8.13 | 8.13 | To learn more, see updating Gradle.
> SDK Build Tools | 35.0.0 | 35.0.0 | Install or configure SDK Build Tools.
> NDK | N/A | 27.0.12077973 | Install or configure a different version of the NDK.
> JDK | 17 | 17 | To learn more, see setting the JDK version.
>
> 引用元: https://developer.android.com/build/releases/past-releases/agp-8-12-0-release-notes#compatibility

> Android Studio version | Required AGP version
> --- | ---
> Otter \| 2025.2.1 | 4.0-8.13
> Narwhal 4 Feature Drop \| 2025.1.4 | 4.0-8.13
> (後略)
>
> 引用元: https://developer.android.com/build/releases/gradle-plugin#android_gradle_plugin_and_android_studio_compatibility

#### 3. KGP の要求を確認する
KGP バージョンに対応したGradle とAGP のサポート範囲を確認する。

> KGP version | Gradle min and max versions | AGP min and max versions
> --- | --- | ---
> 2.2.20 | 7.6.3-8.14 | 7.3.1-8.11.1
> 2.2.0-2.2.10 | 7.6.3-8.14 | 7.3.1-8.10.0
> (後略)
>
> 引用元: https://kotlinlang.org/docs/gradle-configure-project.html#apply-the-plugin

#### 4. 採用するバージョンを決定する
手順1 ~ 3 で得た情報を元に、サポート範囲を満たす各バージョンを決定する。


## 参考文献
* https://developer.android.com/build/releases/gradle-plugin
* https://kotlinlang.org/docs/gradle-configure-project.html#apply-the-plugin

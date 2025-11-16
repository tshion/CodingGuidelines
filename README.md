# CodingGuidelines
> コーディング規約をまとめたリポジトリ

## 使い方
下記に対してカスタム指示を整備しているので、依頼してみてください。

* Gemini
* GitHub Copilot

### コーディング規約のファイル追加
1. チャットを開く
1. チャットに`/add-guidline` を入力し、実行する
1. 生成されたファイルにコーディング規約を追記する


## フォルダー構成
パス | 概要
--- | ---
[.gemini/](./.gemini/) | Gemini 向けの設定
[.github/](./.github/) | GitHub 向けの設定
[create-index/](./create-index/) | コーディング規約の索引を生成するC# プロジェクト
[guidelines/](./guidelines/) | コーディング規約のドキュメント配置
[llms/](./llms/) | AI 向けにデータ加工するC# プロジェクト
[mcp-server/](./mcp-server/) | コーディング規約に関するMCP サーバーのC# プロジェクト
[prompts/](./prompts/) | プロンプトの配置

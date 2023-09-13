# Jenga

## 概要
複合現実(MR)デバイスであるHoloLens2(Microsoft社：https://www.microsoft.com/ja-jp/hololens/hardware )を用いたMRジェンガゲームです。UI・デザイン担当2人、ゲームシステム開発担当2人で開発を行いました。

本ゲームには以下の機能があります。
- 難易度選択機能
  - 難易度は「EASY」と「HARD」があり、それぞれジェンガの高さが異なります
- 選択したジェンガを発光させる機能
  - 選択したジェンガがどれかわかります
- リセット機能
  - ゲームのやり直しが可能です
- ジェンガが落ちた時をゲームオーバーとし、これ以上ジェンガを操作できないように自動で設定

## スクリーンショット
※このスクリーンショットはHoloLensエミュレータで実行したものを撮影しています。
- 難易度選択画面
![スタート画面](https://github.com/Yolog6101/Jenga/assets/72485319/3ebabce9-e6ca-4291-89ae-a6edcc8a8ae8)

-「EASY」でのゲーム画面
![「EASY」](https://github.com/Yolog6101/Jenga/assets/72485319/67e79b15-bdd1-4d9c-83fc-f9f6dc714ba5)

-「HARD」でのゲーム画面
![「「HARD」」](https://github.com/Yolog6101/Jenga/assets/72485319/7068e2d6-ca79-4dac-bd94-7cf8c257bc81)


## アピールポイント
　このゲームではジェンガという親しみのあるゲームにMRという近年話題となっている技術を組み合わせることで、ジェンガを遊ぶプレイヤーに新鮮さを感じてもらうことを狙いとしています。また。難易度も「EASY」と「HARD」の2種類用意し、簡単なものでは物足りないプレイヤーでも飽きにくいようにすることも狙いとしています。
 実装・技術面としてはまずMRでも普通のジェンガと同じように遊ぶことが出来るように、ジェンガのテクスチャを実物になるべく近づけています。また、選んだジェンガを発光させることで、手に取ったジェンガと実際にMR内で取ったジェンガで異なるということがほとんどないようにしています。さらに、ジェンガが床に落ちてゲームオーバーになった場合にゲームを続けられないように、ゲームオーバー後はジェンガを操作できないようにしました。
 
## 開発言語・環境
Unity(C#) 2021.3.8f1　そのほかSDKであるHoloLens2を扱えるMixed Reality Tool Kit(MRTK)を利用しています。
動作確認にはHoloLensエミュレータを使用しました。

## 今後の実装予定
ゲームオーバー時、プレイヤーにもわかるように表示するUIを実装予定です。
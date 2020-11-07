# VTuber動画素材メーカー + 簡単動画VTuber

[![IMAGE ALT TEXT HERE](https://jphacks.com/wp-content/uploads/2020/09/JPHACKS2020_ogp.jpg)](https://www.youtube.com/watch?v=G5rULR53uMk)

## 製品概要
### 背景
　近年、VTuber市場が急激に巨大化しています。VTuberの代名詞的存在である『キズナアイ』が活動を開始したのが2016年11月29日であり、現在ではその総数は1万人を超えるほどになっています。しかしVTuberの数が増加する一方で、何も機材や知識がない状態からVTuberになるのは未だにハードルが高いです。そこで我々は、今手元にある普通のパソコン一台のみで、誰でもVTuberになることのできるアプリの開発を目指しました。
### 製品説明
【VTuber動画素材メーカー】<br>
　無数ともいえるほど多く存在する3Dモデルや、その3Dモデルを動かすモーションをインターネット上から自由に選ぶことで、好きなキャラクターを好きなようにに動かすことができます。例えば、3DモデルであればVRoid　Hub、モーションであればmixamoといったサイトが、フリー素材として利用できるものを紹介しています。選んだ3Dモデルとモーションを使い動画の撮影を行います。これが動画素材となり、いくつかの動画を組み合わせていくことでVTuberになることができます。<br>
　また、撮影した動画はYouTubeのアニメーション動画の素材や、FaceBook、LINE、Tick Tokなどの動画アイコンとしても利用することが可能です。<br>
【簡単動画VTuber】<br>
　動画をデスクトップにウィンドウなしで表示することができます。VTuberのゲーム実況や雑談などの配信では、画面の端に自分自身（VTuber）を表示させています。これを実現させるためには、複数のソフトを準備したり、複雑な手順が必要であったりと、厄介なことが多いです。そこで動画や画像をドラッグ＆ドロップするだけで、簡単に配信画面のようにキャラクターを表示できる製品を作成しました。動画（.mp4　.avi）や画像（.png）ファイルを読み込み、デスクトップ上に表示させることができます。上で説明した【VTuber動画素材メーカー】と合わせて使うことで、自分の選んだキャラクターとモーションでVTuberになることができます。
### 特長
特長1　特殊な機材が必要ない！普通のパソコン１台あれば誰でもVTuberになれる。<br>
特長2　作成した動画は、YouTubeやSNSの動画アイコンにも応用できる。<br>
特長3　複雑な配信画面の準備も簡単にできるように整備しました。<br>

### 解決出来ること
「VTuberになってみたいけど、知識や機材がないから、何から始めればいいのかわからない...」そういった悩みを持つ人が簡単にVTuberになれるようになりました。パソコンの設定が苦手な人でも配信を始められるようになります。<br>
またデスクトップ上にアイコンや動画を表示できるのでzoomで画面共有して目を引きたいときや説明にアクセントを加えたいときに活用できます。
### 今後の展望
動画ではなく、モデルを読み込んで動かせるようになりたい。
動画をクロマキーで透過する処理が間に合わなかったので、それを完成させたい。
### 注力したこと
* 画面を透過、常に最前面など、配信の邪魔にならないようにした
* できるだけ簡単な手順で使えるようにした

## 開発技術
### 活用した技術
Unity(WebGLビルド)
JavaScript(動画のダウンロード)

#### API・データ
* VRM(3Dアバター)
* Mixamo(3Dアバターのアニメーション)
#### フレームワーク・ライブラリ・モジュール
* OpenCV for Unity(動画の作成)
* Unityでファイルブラウザを表示するアセット
https://baba-s.hatenablog.com/entry/2017/12/26/091400
* Unityでビルドしたソフトウェア上でオブジェクトの座標軸を表示するアセット
https://github.com/HiddenMonk/Unity3DRuntimeTransformGizmo
* Unityでビルドしたソフトウェアのウィンドウを透過できるアセット
https://github.com/XJINE/Unity_TransparentWindowManager
* Unityでビルドしたソフトウェアにドラッグアンドドロップをできるアセット
https://github.com/Bunny83/UnityWindowsFileDrag-Drop
#### デバイス
* パソコンのブラウザ

### 独自技術
#### ハッカソンで開発した独自機能・技術
* Unityを使い、ブラウザから動画をダウンロードさせるアプリは、おそらく前例のないものだと思います。 

#### 製品に取り入れた研究内容（データ・ソフトウェアなど）（※アカデミック部門の場合のみ提出必須）
* 
* 

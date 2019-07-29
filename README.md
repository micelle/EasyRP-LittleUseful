EasyRP-LittleUseful
=====

EasyRPをちょっと便利にします。

![EasyRP-LittleUseful](https://prfac.com/wp-content/uploads/2019/07/0d40a5e4a645fc6b96e767d64ac0878e-5.jpg)

## 特徴
- 複数のconfig.iniを利用できます！
- StartTimestampを現在の時間に更新できます！
- EasyRPを最小化した状態で起動できます！
- 起動オプションでもう少し便利に！

## インストール
- EasyRP-LittleUseful.exeをダウンロードし、EasyRP(easyrp.exe)と同じ場所に置きます。
- 初回起動時にsettingフォルダが生成され、元々存在したconfig.iniをコピーしてきます。

## アンインストール
- EasyRP-LittleUseful.exeを削除するだけです。レジストリ等に書き込みは発生しません。
- settingフォルダについてはお好みで削除してください。。

## 使い方
1. StartTimestampにチェックを付けると、EasyRP起動前にStartTimestampを現在のUNIX時間へ更新できます。
2. AutoCloseにチェックを付けると、EasyRP起動後に本ソフトを自動終了できます。
3. settingフォルダにiniファイルを置くことで、iniの選択リストへ反映されます。
4. iniの選択リストは更新ボタンを押すことで最新の情報になります。
5. STARTをクリックすることでconfig.iniを書き換え、EasyRPを最小化した状態で起動します。
6. NoAlertにチェックを付けると、EasyRPを起動したお知らせを出さないようにできます。
7. 起動オプションを付けることで、各種設定を自動化できます。

### 起動オプション
- `"/ini file.ini"`  
  file.iniを選択した状態で起動できます。存在しないファイルの場合、未選択状態になります。
- `/Start`  
  EasyRP-LittleUsefulの起動後、自動的にEasyRPを開始できます。
- `/StartTimestamp`  
  StartTimestampのチェックを外した状態で起動できます。
- `/AutoClose`  
  AutoCloseのチェックを外した状態で起動できます。
- `/NoAlert`  
  NoAlertのチェックを付けた状態で起動できます。

#### 起動オプションの例
- `"C:\EasyRP-windows\EasyRP-LittleUseful.exe" "/ini test.ini" /Start`  
  test.iniを選択した状態で起動し、自動的にEasyRPを開始する設定。
- `"C:\EasyRP-windows\EasyRP-LittleUseful.exe" /StartTimestamp /AutoClose`  
  StartTimestampとAutoCloseのチェックを外した状態で起動する設定。

## 注意点
- iniファイルを未選択状態で起動することはできません。
- 仕様上EasyRPを複数起動できてしまいます。EasyRP自体がそうだからね。
- Not support English.

## 動作確認
- Windows 7 Enterprise 32bit
- Windows 10 HOME 64bit
- Windows 10 Pro 64bit

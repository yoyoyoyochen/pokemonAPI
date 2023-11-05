#Pokemon API

## 目標

**設計一個 Automation Script 透過** `/api/v2/item` **API 確認：**

1. 列出 item 總數量（count）
2. 列出 id < 20, id > 0 的寶可夢物品名稱（name），依照 id 由小至大排序
3. 列出 id < 50, id > 0 的寶可夢物品中，價格（cost）≤ 1500 的寶可夢物品名稱（name）及寶可夢物品價格（cost），並且依照花費價格（cost）由大至小排序

##安裝套件
System.Text.Json

##啟動應用程式(VS 2022) 執行 應用程式：

Program.cs

##預期的執行結果

目標1
```
物品總數量: 2110
```
目標2
```
ID < 20 的寶可夢物品名稱：
master-ball
ultra-ball
great-ball
poke-ball
safari-ball
net-ball
dive-ball
nest-ball
repeat-ball
timer-ball
luxury-ball
premier-ball
dusk-ball
heal-ball
quick-ball
cherish-ball
potion
antidote
burn-heal
```
目標3
```
價格 <= 1500 的寶可夢物品名稱及價格，依價格排序：
hyper-potion - 價格：1500
energy-root - 價格：1200
ether - 價格：1200
net-ball - 價格：1000
dive-ball - 價格：1000
nest-ball - 價格：1000
repeat-ball - 價格：1000
timer-ball - 價格：1000
dusk-ball - 價格：1000
quick-ball - 價格：1000
ultra-ball - 價格：800
super-potion - 價格：700
great-ball - 價格：600
moomoo-milk - 價格：600
energy-powder - 價格：500
full-heal - 價格：400
lemonade - 價格：400
lava-cookie - 價格：350
heal-ball - 價格：300
soda-pop - 價格：300
heal-powder - 價格：300
poke-ball - 價格：200
potion - 價格：200
antidote - 價格：200
burn-heal - 價格：200
ice-heal - 價格：200
awakening - 價格：200
paralyze-heal - 價格：200
fresh-water - 價格：200
berry-juice - 價格：200
premier-ball - 價格：20
master-ball - 價格：0
safari-ball - 價格：0
cherish-ball - 價格：0
```

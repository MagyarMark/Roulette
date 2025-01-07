**Roulette** 
 
**Bevezetés**
A rulett egy kaszinójáték, amelyben a játékosok téteket helyeznek el egy forgó keréken szereplő számokra, színekre vagy számkategóriákra. A játék izgalmát a véletlen eredménye adja, amely meghatározza a nyertes számot és kategóriát. Az általunk készített program célja, hogy a roulett játékmenetét hűen modellezze, lehetővé téve a felhasználóknak, hogy interaktívan megtapasztalják a játék működését egy digitális környezetben. 
<br><br>
<br><br>
**Játékmenet:** 

**Bejelentkezés:** 
A játék kezdetén a felhasználó megadja a nevét és feltölti a kezdő egyenlegét. Ezt követően lehetősége van kiválasztani, hogy hány játékossal szeretne játszani (maximum 6) 

**Tétek Megadása:** 
Miután a bejelentkezés megtörtént, a felhasználó kiválaszthatja, hogy melyik számra, színre vagy számkategóriára (például páros vagy páratlan) szeretne tétet helyezni. Az elhelyezett tétek összege automatikusan levonásra kerül a játékos egyenlegéből. 

**Kerék Pörgetése:**
A tétek megadása után a kerék megpördül. Egy véletlenszám generátor segítségével kisorsolja a nyertes számot. 

**Eredmények Értékelése:** 
A rendszer ellenőrzi, hogy a játékos által megadott tétek egyeznek-e a nyertes számmal 	vagy kategóriával. Az egyezések alapján a hozzájuk tartozó szorzókkal kiszámolja a 		játékos nyereményét. 

**Játék Folytatása:** 
A játékos dönthet arról, hogy folytatja a játékot, vagy kilép a  programból. 
<br><br><br><br>
**Szorzók és Típusok** 

**Egy számra tét (Straight-up):** 

Tehetünk egy adott számra (például: 0,1...36). 
**Szorzó:** 35-szörös 


**Színre tét (Piros/Fekete):** 

A játékos választhat a piros vagy fekete számok közül. 
**Szorzó:** 2-szeres 
<br><br>
**Páros/Páratlan (Even/Odd):** 

Tehetünk arra, hogy a szám páros (even) vagy páratlan (odd). 
**Szorzó:** 2-szeres 
<br><br>
**Kisebb/Nagyobb (1-18 vagy 19-36):** 

Az alsó (1-18) vagy felső (19-36) tartományokra tehetünk tétet. 
**Szorzó:** 2-szeres 
<br><br>
**Tucat (1-12, 13-24, 25-36):**

Három tucatnyi szám közül választhatunk. 
**Szorzó:** 3-szoros 
<br><br>
**Oszlop (1 to 12):** 

A három oszlop egyikére rakhatunk tétet. 
**Szorzó:** 3-szoros 

<br><br><br><br>
**Programozási Összetevők** 

1. **Véletlenszám Generálás** 
A nyertes szám meghatározására a **C#** beépített **Random** függvényt alkalmazunk:
```c#
Random random = new Random(); 
int winningNumber = random.Next(0, 37);
```
2. **Tétek Kezelése** 
A megtett téteket egy **int** listában táruljuk:
```c#
List<int> UserBets = new List<int>(); 
UserBets.Add(UserBet);
```
4. **Mezők kezelése**  
A kiválasztott mezőket egy **string** listában tároljuk:
```c#
List<string> Odds = new List<string(); 
Odds.Add(“2x”);
```

<br><br><br><br>
**Felhasználói Felület** 

A felhasználói felülethez grafikus megjelenítéséhez **Windows Forms Apps** járul hozzá a **C#**-on belül. 
A grafikus dizájnhoz a **Stake.com**-on található roulette játékot vettük alapul. 

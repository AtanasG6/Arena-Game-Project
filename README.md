# 🏆 Arena Game

## 📝 Описание на проекта

Този проект е разработен за предмета "Обектно-ориентирано програмиране 2" (ООП2) в специалност "Софтуерно инженерство" на Пловдивски университет "Паисий Хилендарски". Специалността се ръководи от проф. д-р Николай Павлов и ас. д-р Симеон Монов.

Arena Game е текстова игра, която позволява на играчите да създават герои с различни умения и оръжия, да стартират битки между тях и да наблюдават изхода от тези битки. Играта демонстрира използването на обектно-ориентирани принципи като наследяване, полиморфизъм и капсулация. Проектът включва и unit test-ове, написани с xUnit и FluentAssertions.

## 📁 Структура на проекта
```plaintext
ArenaGame/
├── Core/
│ ├── Engine.cs
│ ├── Contracts/
│ │ └── IEngine.cs
│ └── Startup.cs
├── IO/
│ ├── Contracts/
│ │ ├── IReader.cs
│ │ └── IWriter.cs
│ ├── Reader.cs
│ └── Writer.cs
├── Models/
│ ├── Contracts/
│ │ ├── IHero.cs
│ │ └── IWeapon.cs
│ ├── Enums/
│ │ ├── HeroType.cs
│ │ └── OutputColor.cs
│ ├── Hero/
│ │ ├── Knight.cs
│ │ ├── Assassin.cs
│ │ ├── Archer.cs
│ │ └── Mage.cs
│ ├── Weapon/
│ │ ├── Sword.cs
│ │ ├── FireWeapon.cs
│ │ ├── IceWeapon.cs
│ │ ├── BloodRestorationWeapon.cs
│ │ └── Bow.cs
│ ├── Pet.cs
│ └── Item.cs
├── Repositories/
│ ├── Repository.cs
│ └── Contracts/
│ └── IRepository.cs
├── Controllers/
│ ├── BattleController.cs
│ ├── GameController.cs
│ └── ShopController.cs
├── Utilities/
│ ├── ExceptionMessages.cs
│ └── OutputMessages.cs
├── ArenaGame.Tests/
│ ├── HeroTests.cs
│ └── Controllers/
│ ├── BattleControllerTests.cs
│ ├── GameControllerTests.cs
│ └── ShopControllerTests.cs
└── .gitignore
└── README.md
```
## 📂 Описание на структурата

- **Core**: Съдържа основните компоненти на играта, включително инициализацията и изпълнението на играта.
- **IO**: Съдържа интерфейси и класове за вход/изход.
- **Models**: Съдържа модели за герои, оръжия, домашни любимци и предмети.
- **Repositories**: Съдържа репозиторита за управление на колекциите от обекти.
- **Controllers**: Съдържа контролери за управление на битките, героите и магазина.
- **Utilities**: Съдържа помощни класове за съобщения и константи.
- **Tests**: Съдържа тестове за проверка на функционалността на различните компоненти на играта, написани с xUnit и FluentAssertions.

## 📝 Механика на играта
В този проект за арена игра има няколко ключови механики, които определят геймплея и стратегията:

### 🦸 Герои и нива
Герои: Всеки герой е уникален и принадлежи към определен тип, като рицар, асасин, стрелец или маг. Героите имат различни атрибути като броня, сила, здраве и ниво.
Нива: Героите получават точки опит (XP) по време на битки. След като натрупат достатъчно XP, те вдигат ниво, което увеличава тяхното здраве и сила.
### 🐾 Домашни любимци
Домашни любимци: Героите могат да имат домашни любимци, които им помагат в битките. Домашните любимци са два типа:
Атакуващи: Тези домашни любимци помагат, като нанасят допълнителни щети на опонентите.
Защитни: Тези домашни любимци помагат в защитата на героя, като предоставят допълнително здраве или други защитни ползи.
### 💰 Монети и предмети
Монети: Героите печелят монети за всяка успешна атака. Тези монети могат да се използват за автоматично закупуване на нови оръжия, когато герой събере достатъчно монети.
Предмети: По време на битките героите имат шанс да намерят предмети с различна рядкост. Тези предмети предоставят допълнителни точки опит (XP) и бонуси към здравето и силата.
### 🗡️ Оръжия
Оръжия: Героите могат да носят различни типове оръжия, всяко със своите уникални ефекти:
Меч: Стандартно оръжие с балансирани атрибути.
Огнено оръжие: Може да запали опонентите, причинявайки щети в продължение на няколко рунда.
Ледено оръжие: Може да замрази опонентите, предотвратявайки ги да атакуват за няколко рунда.
Оръжие за възстановяване на кръв: Позволява на героя да възстановява здраве по време на атака.

## 🎮 Как се играе

За да създадете герой и да стартирате битка, използвайте следните команди:

- **Създаване на герой**:
*```CreateHero <Name> <HeroType> <Armor> <Strength> <WeaponType> <PetType> <PetEffect>```*

Пример:
CreateHero Arthur Knight 50 100 BloodRestorationWeapon Attack 10

- **Стартиране на битка**:
*```StartBattle <AttackerName> <DefenderName>```*

Пример:
StartBattle Arthur Eivor

- **Край на играта**:
*```End```*


## ⚔️ Примерен ход на игра

Ето пример за ход на игра, включващ създаване на герои и стартиране на битки:
```plaintext
----------------------------------------------------------------------
|CreateHero Arthur Knight 50 100 BloodRestorationWeapon Attack 10    |
|CreateHero Eivor Assassin 30 80 IceWeapon Defense 5                 |
|CreateHero Legolas Archer 40 90 Bow Attack 7                        | 
|CreateHero Gandalf Mage 20 70 FireWeapon Defense 8                  |
|StartBattle Arthur Eivor                                            |
|StartBattle Legolas Gandalf                                         |   
|End                                                                 |
----------------------------------------------------------------------
```
## 🛡️ Примерна битка

### Рунд 1:
```diff
+ Arthur възстановява 10 здраве. Общо здраве: 110.
- Arthur (Ниво 1) атакува Eivor с Default Healing Wand, нанасяйки 75 щети.
! Атакуващ домашен любимец помага на Arthur, предоставяйки допълнителен ефект.
+ Arthur получава 10 монети. Общо монети: 10.
- Eivor (Ниво 1) атакува Arthur с Default IceWeapon, нанасяйки 35 щети.
! Защитен домашен любимец помага на Eivor, предоставяйки допълнителен ефект.
+ Eivor получава 10 монети. Общо монети: 10.
@@ Eivor намира случаен предмет (Common) и получава 0 XP.@@
@@ Eivor получава 0 XP. Общо XP: 0. Ниво: 1.@@
+ Eivor получава 0 здраве. Общо здраве: 20.
+ Eivor получава 0 сила. Общо сила: 80.
@@ Статус: Arthur - 75 HP, Eivor - 20 HP.@@
```
### Рунд 2:
```diff
@@ Arthur (Ниво 1) е замразен и не може да атакува. @@
- Eivor (Ниво 1) атакува Arthur с Default IceWeapon, нанасяйки 35 щети.
! Защитен домашен любимец помага на Eivor, предоставяйки допълнителен ефект.
+ Eivor получава 10 монети. Общо монети: 20.
! Eivor купува ново оръжие: Random Sword.
@@ Eivor намира случаен предмет (Uncommon) и получава 50 XP.@@
@@ Eivor получава 50 XP. Общо XP: 50. Ниво: 1.@@
+ Eivor получава 10 здраве. Общо здраве: 35.
+ Eivor получава 5 сила. Общо сила: 85.
! Статус: Arthur - 40 HP, Eivor - 35 HP.
```

### Рунд 3:
```diff
@@ Arthur (Ниво 1) е замразен и не може да атакува. @@
- Eivor (Ниво 1) атакува Arthur с Random Sword, нанасяйки 50 щети.
! Защитен домашен любимец помага на Eivor, предоставяйки допълнителен ефект.
+ Eivor получава 10 монети. Общо монети: 10.
- Arthur е победен!
```
### StartBattle Legolas Gandalf

### Рунд 1:
```diff
- Legolas (Ниво 1) атакува Gandalf с Default Bow, нанасяйки 85 щети.
! Атакуващ домашен любимец помага на Legolas, предоставяйки допълнителен ефект.
+ Legolas получава 10 монети. Общо монети: 10.
- Gandalf (Ниво 1) атакува Legolas с Default FireWeapon, нанасяйки 47 щети.
! Защитен домашен любимец помага на Gandalf, предоставяйки допълнителен ефект.
+ Gandalf получава 10 монети. Общо монети: 10.
@@ Статус: Legolas - 53 HP, Gandalf - 16 HP.@@
```

### Рунд 2:
```diff
- Legolas (Ниво 1) атакува Gandalf с Default Bow, нанасяйки 85 щети.
! Атакуващ домашен любимец помага на Legolas, предоставяйки допълнителен ефект.
+ Legolas получава 10 монети. Общо монети: 20.
@@ Legolas купува ново оръжие: Random Staff.@@
- Legolas изгаря и получава 5 щети.
- Gandalf е победен!
```

### 🏁 Край на играта <br>

## 📚 Заключение
Този проект демонстрира основните принципи на обектно-ориентираното програмиране чрез създаване на текстова игра, в която играчите могат да създават герои, да стартират битки и да наблюдават резултатите от тях. Проектът използва интерфейси, наследяване и полиморфизъм, за да създаде гъвкава и разширяема система за управление на героите и битките.

Проектът включва unit test-ове, написани с xUnit и FluentAssertions, които тестват основните функционалности на играта.

  <p align="center">
  <img src="https://github.com/AtanasG6/Arena-Game-Project/assets/92335834/3d3d97dd-f323-4c55-9239-7abe7430416c" style="margin-right: 20px;">
  <img src="https://github.com/AtanasG6/Arena-Game-Project/assets/92335834/a861f0f7-5c4a-4f6f-af96-9e9c0cbcc9f0" style="margin-left: 20px;">
  </p>






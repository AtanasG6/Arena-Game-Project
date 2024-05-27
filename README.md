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
- **Repositories**: Съдържа репозитории за управление на колекциите от обекти.
- **Controllers**: Съдържа контролери за управление на битките, героите и магазина.
- **Utilities**: Съдържа помощни класове за съобщения и константи.
- **Tests**: Съдържа тестове за проверка на функционалността на различните компоненти на играта, написани с xUnit и FluentAssertions.

## 🎮 Как се играе

За да създадете герой и да стартирате битка, използвайте следните команди:

- **Създаване на герой**:
CreateHero <Name> <HeroType> <Armor> <Strength> <WeaponType> <PetType> <PetEffect>

Пример:
CreateHero Arthur Knight 50 100 BloodRestorationWeapon Attack 10

- **Стартиране на битка**:
StartBattle <AttackerName> <DefenderName>

Пример:
StartBattle Arthur Eivor

- **Край на играта**:
End


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
Round 1: <br>
Arthur възстановява 10 здраве. Общо здраве: 110. <br>
Arthur (Ниво 1) атакува Eivor с Default Healing Wand, нанасяйки 75 щети. <br>
Атакуващ домашен любимец помага на Arthur, предоставяйки допълнителен ефект. <br>
Arthur получава 10 монети. Общо монети: 10. <br>
Eivor (Ниво 1) атакува Arthur с Default IceWeapon, нанасяйки 35 щети. <br>
Защитен домашен любимец помага на Eivor, предоставяйки допълнителен ефект. <br>
Eivor получава 10 монети. Общо монети: 10. <br>
Eivor намира случаен предмет (Common) и получава 0 XP. <br>
Eivor получава 0 XP. Общо XP: 0. Ниво: 1. <br>
Eivor получава 0 здраве. Общо здраве: 20. <br>
Eivor получава 0 сила. Общо сила: 80. <br>
Статус: Arthur - 75 HP, Eivor - 20 HP. <br>

Round 2: <br>
Arthur (Ниво 1) е замразен и не може да атакува. <br>
Eivor (Ниво 1) атакува Arthur с Default IceWeapon, нанасяйки 35 щети. <br>
Защитен домашен любимец помага на Eivor, предоставяйки допълнителен ефект. <br>
Eivor получава 10 монети. Общо монети: 20. <br>
Eivor купува ново оръжие: Random Sword. <br>
Eivor намира случаен предмет (Uncommon) и получава 50 XP. <br>
Eivor получава 50 XP. Общо XP: 50. Ниво: 1. <br>
Eivor получава 10 здраве. Общо здраве: 35. <br>
Eivor получава 5 сила. Общо сила: 85. <br>
Статус: Arthur - 40 HP, Eivor - 35 HP. <br>

Round 3: <br>
Arthur (Ниво 1) е замразен и не може да атакува. <br>
Eivor (Ниво 1) атакува Arthur с Random Sword, нанасяйки 50 щети. <br>
Защитен домашен любимец помага на Eivor, предоставяйки допълнителен ефект. <br>
Eivor получава 10 монети. Общо монети: 10. <br>
Arthur е победен! <br>

StartBattle Legolas Gandalf <br>

Round 1: <br>
Legolas (Ниво 1) атакува Gandalf с Default Bow, нанасяйки 85 щети. <br>
Атакуващ домашен любимец помага на Legolas, предоставяйки допълнителен ефект. <br>
Legolas получава 10 монети. Общо монети: 10. <br>
Gandalf (Ниво 1) атакува Legolas с Default FireWeapon, нанасяйки 47 щети. <br>
Защитен домашен любимец помага на Gandalf, предоставяйки допълнителен ефект. <br>
Gandalf получава 10 монети. Общо монети: 10. <br>
Статус: Legolas - 53 HP, Gandalf - 16 HP. <br>
 
Round 2: <br>
Legolas (Ниво 1) атакува Gandalf с Default Bow, нанасяйки 85 щети. <br>
Атакуващ домашен любимец помага на Legolas, предоставяйки допълнителен ефект. <br>
Legolas получава 10 монети. Общо монети: 20. <br>
Legolas купува ново оръжие: Random Staff. <br>
Legolas изгаря и получава 5 щети. <br>
Gandalf е победен! <br>
🏁 Край на играта <br>

## 📚 Заключение
Този проект демонстрира основните принципи на обектно-ориентираното програмиране чрез създаване на текстова игра, в която играчите могат да създават герои, да стартират битки и да наблюдават резултатите от тях. Проектът използва интерфейси, наследяване и полиморфизъм, за да създаде гъвкава и разширяема система за управление на героите и битките.

Проектът включва unit test-ове, написани с xUnit и FluentAssertions, които тестват основните функционалности на играта.

  ![image](https://github.com/AtanasG6/Arena-Game-Project/assets/92335834/3d3d97dd-f323-4c55-9239-7abe7430416c)                     ![image](https://github.com/AtanasG6/Arena-Game-Project/assets/92335834/a861f0f7-5c4a-4f6f-af96-9e9c0cbcc9f0)




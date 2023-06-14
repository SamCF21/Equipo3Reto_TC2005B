# **Mealtime Mayhem**

## _Game Design Document_

---

##### **Copyright notice / Samantha Covarrubias, Cristina González, Valeria Martínez, Mauricio Tumalan, Fernanda Colomo / E**

##
## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
    1. [Summary](#summary)
    2. [Gameplay](#gameplay)
    3. [Mindset](#mindset)
3. [Technical](#technical)
    1. [Screens](#screens)
    2. [Controls](#controls)
    3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
    1. [Themes](#themes)
    2. [Game Flow](#game-flow)
5. [Development](#development)
    1. [Abstract Classes](#abstract-classes--components)
6. [Graphics](#graphics)
    1. [Style Attributes](#style-attributes)
    2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
    1. [Style Attributes](#style-attributes-1)
    2. [Sounds Needed](#sounds-needed)
    3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

Mealtime Mayhem is a real time strategy game where the player takes the role of a chef that has to fight the evil fungi that was found on the island where they recently opened their regional food cart.

### **Gameplay**

The game is a 2D top-down with RPG and real-time strategy elements, where the player must focus on selecting the best strategy to defeat the enemy hordes of fungi, creating the food companions that will best fulfill the task.

The playable ground is designed as a grid in order to aid the player regarding the positioning of the chef and his sidekicks. For the placement of the characters on the grid, the player will have to select the character followed by the desired square. Once placed, the sidekicks will remain fixed on the selected square. The chef will be able to move to the food cart in case a sidekick is defeated and a new one has to be created. In terms of the enemies (fungi), these will spawn randomly from the edges of the playable ground and move freely towards the food cart. 

The levels of the game revolve around hordes of enemies (fungi) that must be defeated by the player and its food sidekicks. The player must achive a certain amount of score in order to win the level. The score is obtained by defeating enemies.

The attack of the characters is automatic and will be triggered whenever an enemy and a sidekick/chef encounter each other within a certain distance. The healing of the chef and sidekicks is also automatic, entering into effect a few seconds after finishing a combat.

After completing a level, the total amount of score obtained will be shown, they will transform into currency points that can be spent on the many skill trees available in the game, where you can upgrade the chef or the sidekick statistics, such as health, speed and damage. The player will also be able to upgrade the food cart, which will increase its resistance to enemy attacks.

You can select the color of the chef's body and eyes, to have a more personalized experience. Other cosmetics will start appearing after the evolution of the chef’s skill tree, (clothes, hats) showing improvement of their statistics.


The chef is the main character that the entire game is based on. Its main mission is to defend his food cart from the fungi by creating his sidekicks. Likewise, he can attack his enemies with melee combat with the spatula that he has by default, if the chef is defeated, the game will be over.


### **Mindset**

What is expected to generate in a player is a strategic and tactical approach, where they have to make decisions about the best selection of food to face the mushrooms of the level, as well as the ability to think long term and be able to act on unpredictable decisions.

## _Technical_

---

### **Screens**

1. Title Screen
   1. Controls
   1. Login/Play
   1. Stats
   1. Options

![Title Screen](/Videogames/imagesforGDD/titlescreen.png)

2. Game slot selection

![Game slot selection](/Videogames/imagesforGDD/gameselection.png)

3. Country selection

![Country selection](/Videogames/imagesforGDD/nationalityselection.png)


4. Game
   1. Sidekick upgrades

![Chef upgrades](/Videogames/imagesforGDD/ChefUpgrades.png)

   1. Food upgrades

![Food upgrades](/Videogames/imagesforGDD/FoodUpgrades.png)

   1. Skill tree upgrades
   1. Fungi hordes (3)
   1. Levels (5)

![Levels](/Videogames/imagesforGDD/levels.png)

   1. Level map

![map](/Videogames/imagesforGDD/tiles.jpg)


5. End Screen
   1. Winning screen

![Winning screen](/Videogames/imagesforGDD/endwon.png)

   1. Losing screen

![Loosing screen](/Videogames/imagesforGDD/endlost.png)

6. Credits Screen

![Credits screen](/Videogames/imagesforGDD/credits.png)

### **Controls**

The game is played by using the mouse controller in order to select where the sidekick will be placed, sidekick´s upgrades selection and other game options like the food stand or the chef personalization. 

**Assets**:

Sprites: 

1. Chef: that can be personalized

![Chef](/Videogames/imagesforGDD/chef.png)

1. Chef´s weapon (selected by the player)

4. Food:
   1. Mexican

![mex](/Videogames/imagesforGDD/taco.png)


      1. Taco (will be upgrades as the game advance) 
   1. Venezuelan

![ven](/Videogames/imagesforGDD/arepa.png)

      1. Arepa ( will be upgrades as the game advance)
   1. USA

![us](/Videogames/imagesforGDD/bread.png)

      1. Sandwich (will be upgrades as the game advance)
3. Enemies (Fungi)
   1. Type 1

![e1](/Videogames/imagesforGDD/enemy1.png)

   2. Type 2

![e2](/Videogames/imagesforGDD/enemy2.png)

   3. Type 3 

![e3](/Videogames/imagesforGDD/enemy3.png)

Note: the color of the Fungi distinguishes each type from each other, in the game, each type has its own difficulty. 

5. Food cart

![fc](/Videogames/imagesforGDD/foodcart.png)

1. Background
   1. Island background with sea animations
   1. Grid (playable ground) 
   1. Level design:
      1. Progress bar 
      1. Food stall
      1. Background decorations
         1. Palm tree
         1. Boat
         1. Menu button 
1. Title screen
   1. Background
   1. Log In setup
      1. Buttons 
         1. Username
         1. Password
         1. Sign in
         1. Welcome 
   1. Country selection 
   1. Upgrades 


1. Title screen
1. Level music
1. End level 
   1. Win level
   1. Lose level
1. Upgrades scene 
1. End game 
1. Credits 

### **Mechanics**

1. Grid like setup: How are the levels configured 
   1. The level display is based on a grid, like a chess board divided in squares in which the player can place one sidekick per square. 
1. Scoring system: a way in which the player collects points that will be useful for upgrades. 
   1. The player will earn points after each level, which is won by defeating each enemy/horde. These points will be stored and can be exchanged for different upgrades like special ingredients for the sidekicks, the chef´s weapon, or the food stall (resistance).
1. Horde management
   1. Enemies spawning - Each enemy will appear at a random position declared in a range, and if a sidekick or chef is near, they will attack each other. 
1. Cooking
   1. Each time the chef wants to cook a sidekick, movement or attack will be blocked for a few seconds

## _Level Design_

---

### **Themes**

1. Island 
    1. Light, sunny, colorful.
2. Objects
    1. Palm Trees
    2. Sand
    3. Sand castles
    4. Water surroundings
    5. Boat floating on water surroundings


### **Game Flow**

1. Player chooses his country
2. Player starts fighting enemies as a chef
3. Chef gathers points to redeem for ingredients and cook food sidekicks
4. Player chooses where to put their sidekicks to fight
5. Player successfully beats 3 fungi hordes and passes to the next level


## _Development_

---

### **Abstract & Derived Classes / Components**

1. Chef
   1. ` `Upgradable stats (health, damage, stamina) 
1. Chef’s brother 
   1. Ability to attack 
   1. Dialogue interaction 
1. Sidekicks
   1. Attack 
   1. Placeable object
   1. Added upgrade 
1. Enemies 
   1. Hord plantation
   1. Attack
   1. Loot (may or may not drop gas) 
1. Food stall
   1. Upgrades 
1. Buttons 
   1. Login 
   1. Play
   1. Menu
1. Progress bars (changeable during each level): 
   1. Health bar 
   1. Level bar (hordes)
1. Stats bars (shown when upgrades are made): 
   1. Stats such as chef´s stats like health and damage
   1. Sidekicks´ bars such as health and damage
   1. Food stall´s bar such as health
1. Map
   1. Trigger islands for each level
   1. Side quests to earn points 
   1. Opening and closing paths according to the player´s progress
1. Decision making 
   1. Nationality 
   1. Side quest option 
1. Points
   1. They can be collected and exchanged for different upgrades



## _Graphics_

---

### **Graphics Needed**

1. Characters
    1. Chef (idle, walking, attacking)
    2. Sidekick (idle, walking, attacking)
    3. Fungi (idle, walking, attacking)

2. Blocks
    1. Sand
    2. Sand/Water
    3. Waves
    4. Ocean
3. Ambient
    1. Palm Tree
    2. Sea shell
    3. Crab
    4. Armored Suit
4. Other
    1. Sand Castle
    2. Stone Castle




## _Sounds/Music_

---

### **Sounds Needed**

1. Effects
    1. Sand Footsteps
    2. Ocean Waves
    3. Tense Moments
    4. Checkpoint
    5. Cooking
    6. Win level
    7. Loose level
    8. Loose game
    9. Win game
    10. Eliminate ally
    11. Eliminate main boss



### **Music Needed**

1. Beach Party Island


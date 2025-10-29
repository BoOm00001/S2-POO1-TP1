TP1 - Programmation objet 1 (Jeu de Bingo)
==========================================

Cours : 420-W20-SF - Programmation objet 1  
Cegep de Sainte-Foy  
Date : fevrier 2025  

Objectif du projet
------------------
Ce projet consiste a concevoir une application console simulant un jeu de Bingo simplifie.  
Le travail permet de mettre en pratique les concepts fondamentaux de la programmation oriente objet en C#, incluant les classes, les proprietes, les tableaux 2D et les tests unitaires.

---------------------------------------------------------

Description generale
--------------------
Le jeu de Bingo est compose de plusieurs cartes carre (ex. 5x5), ou chaque case contient un numero.  
Les numeros sont marques au fur et a mesure qu'ils sont tires par un generateur pseudo-aleatoire.  
Le programme s'arrete des qu'une carte obtient un pointage superieur a 0, c'est-a-dire lorsqu'une ligne ou une colonne complete est marquee.

---------------------------------------------------------

Classes principales
-------------------

### Classe CardCell
Cette classe represente une case individuelle sur une carte de Bingo.

**Attributs et proprietes :**
- `Value` : int — le numero de la case.  
- `IsMarked` : bool — indique si la case est marquee.  

**Methodes principales :**
- `MarkCell(int value)` : marque la case si le numero correspond a la valeur.  

### Classe BingoCard
Cette classe represente une carte de Bingo entiere.

**Attributs :**
- Tableau 2D de `CardCell` representant les cases.  
- Un compteur du nombre de tirages effectues.

**Constructeur :**
- `BingoCard(int size, NumberGenerator generator)`  
  Initialise la carte avec des valeurs fournies par un generateur de nombres (sequentiel ou pseudo-aleatoire).

**Methodes principales :**
- `MarkNumber(int value)` : marque la valeur tiree sur la carte.  
- `ComputeScore()` : calcule le pointage de la carte selon les regles suivantes :  
  - 0 si aucune ligne ni colonne n'est completement marquee.  
  - Somme des valeurs de toutes les lignes et colonnes completes sinon.

### Classe NumberGenerator
Cette classe est fournie et **ne doit pas etre modifiee**.  
Elle permet de generer des nombres constants, sequentiels ou pseudo-aleatoires.  

**Constructeurs :**
- `NumberGenerator()` : mode sequentiel (1, 2, 3, ...)  
- `NumberGenerator(int value)` : mode constant.  
- `NumberGenerator(long seed)` : mode pseudo-aleatoire.  

---------------------------------------------------------

Fonctionnement principal (Main)
-------------------------------
1. Creer 5 cartes de Bingo avec des generateurs differents initialises avec les valeurs 0 a 4.  
2. Creer un autre generateur pour le tirage avec la valeur initiale 8473718269.  
3. Tirer un nombre a la fois et le marquer sur chaque carte.  
4. Arreter lorsque l'une des cartes a un pointage > 0.  
5. Afficher :
   - Le numero de la carte gagnante (0 a 4)  
   - Le nombre total de tirages  
   - Le pointage de la carte gagnante  
   Si deux cartes gagnent en meme temps, afficher celle ayant le pointage le plus eleve.

---------------------------------------------------------

Tests unitaires
---------------
Des tests unitaires doivent etre produits pour valider les classes `CardCell` et `BingoCard`.

**Classe CardCell :**
- Test du constructeur.  
- Test de la methode `MarkCell()`.  

**Classe BingoCard :**
- Test de la methode `ComputeScore()` avec differents generateurs et tailles de cartes.  

Les tests doivent assure une couverture complete du code et respecte les signatures fournies dans les fichiers de test fournis.

---------------------------------------------------------

Technologies utilisees
----------------------
- C# (.NET 8)  
- Programmation oriente objet (classes, proprietes, methodes)  
- Generation pseudo-aleatoire  
- Tests unitaires (xUnit )  
- IDE : Visual Studio 2022  

---------------------------------------------------------

Auteur
------
Cherif Ouattara - Etudiant AEC Programmation, bases de donnees et serveurs  
Cegep de Sainte-Foy  
GitHub : https://github.com/BoOm00001  
LinkedIn : https://www.linkedin.com/in/cherif-ouattara/

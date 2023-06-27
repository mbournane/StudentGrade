# Session C# Mai 2023 - Projet 1 - Application Console - 2 Semaines

![](resources/logo_wild.png)

- [Session C# Mai 2023 - Projet 1 - Application Console - 2 Semaines](#session-c-mai-2023---projet-1---application-console---2-semaines)
  - [Introduction](#introduction)
  - [Technologies](#technologies)
    - [C#.Net](#cnet)
    - [Nuget](#nuget)
    - [Newtonsoft.JSON](#newtonsoftjson)
    - [Visual Studio Code](#visual-studio-code)
    - [Github](#github)
  - [L'application](#lapplication)
    - [Le besoin](#le-besoin)
    - [L'environnement d'exécution](#lenvironnement-dexécution)
  - [Spécification fonctionnelle](#spécification-fonctionnelle)
    - [Fichier de données](#fichier-de-données)
    - [Menu](#menu)
    - [La notion d'Élève](#la-notion-délève)
    - [La notion de Cours](#la-notion-de-cours)
    - [La suppression d'un cours](#la-suppression-dun-cours)
    - [L'ajout d'une note et appréciation](#lajout-dune-note-et-appréciation)
    - [L'enregistrement des données](#lenregistrement-des-données)
    - [La moyenne](#la-moyenne)
    - [Affichage](#affichage)
    - [La gestion des erreurs](#la-gestion-des-erreurs)
    - [Fichier de log](#fichier-de-log)
  - [Objectifs bonus facultatifs](#objectifs-bonus-facultatifs)

## Introduction
Afin de révolutionner le système informatique de l'éducation nationale, nous souhaitons la création d'une application console permettant de réaliser la saisie des notes des élèves.
En tant qu'éducation nationale, nous regroupons des cursus de formation divers et variés avec des professeurs et des étudiants multi-ethniques.
La condition d'obtention du diplôme nécessite bien évidemment la réussite des examens. Examens catégorisés par matières, et donnant lieu à une note ainsi qu'une appréciation de la part du professeur.

## Technologies

### C#.Net 
Le programme sera développé dans le langage C# en utilisant le framework .Net Core 7.0

### Nuget
Les paquets Nuget pourront être utilisés pour l'inclusion de dépendances externes.

### Newtonsoft.JSON
La persistence se fera dans un simple fichier texte au format JSON.

La librairie Newtonsoft.JSON sera utilisée pour la manipulation des données au format JSON

### Visual Studio Code
Les développements et compilations seront réalisés sur l'outil Visual Studio Code

### Github
Les sources de l'application sont à déposer sur un dépot Github. Les binaires ne doivent pas être versionnés (utilisez un .gitignore)

## L'application

### Le besoin
Le papier étant voué à disparaitre, une solution digitale permettant aux professeurs de saisir les notes et appréciations de leurs différents élèves devient indispensable.
Les ordinateurs de l'éducation nationale étant à la pointe de la technologie, la saisie des informations se fera uniquement au clavier et sur des écrans 4k. Les interfaces graphiques (web ou applicatives) sont à proscrire afin de ne pas heurter les potentiels utilisateurs daltonniens.
Afin d'éviter toute fuite de données, aucun système de gestion en ligne ne doit être utilisé. Toutes les données saisies et manipulées dans l'application doivent être enregistrées dans un fichier texte au format JSON afin de pouvoir facilement être échangées sur support amovible (disquette/CD-ROM/clé USB).

### L'environnement d'exécution
L'application sera mono-poste et fonctionnera sans base de données. L'application pourra s'exécuter sur MacOs, Linux, ou Windows 10 et supérieur. 

## Spécification fonctionnelle

### Fichier de données
Le fichier de données JSON à utiliser sera passé en argument au programme lors du lancement. 

Il peut se trouver sur n'importe quel disque dur ou amovible tant que les accès en écriture sont bien présents.

### Menu
Au lancement de l'application, un menu permettra à l'utilisateur de choisir entre ces entrées : 
- Elèves
- Cours

Le menu Elèves permettra quant à lui de : 
- Lister les élèves
- Créer un nouvel élève
- Consulter un élève existant
- Ajouter une note et une appréciation pour un cours sur un élève existant
- Revenir au menu principal

Le menu Cours permettra de son côté de : 
- Lister les cours existants
- Ajouter un nouveau cours au programme
- Supprimer un cours par son identifiant
- Revenir au menu principal

### La notion d'Élève
Un élève sera composé des attributs suivants : 
- Un identifiant unique au format numérique
- Un nom au format texte
- Un prénom au format texte
- Une date de naissance
- Un liste de notes (nombre à virgule) et d'appréciation du professeur (texte) pour chaque cours
- La moyenne de ses notes qui sera calculée à la volée et ne sera pas enregistrée dans le fichier

### La notion de Cours
Les cours seront composés des attributs suivants : 
- Un identifiant unique au format numérique
- Un nom au format texte

### La suppression d'un cours
Quand un cours est supprimé du programme, il faut également supprimer les notes et appréciations de ce cours pour tous les élèves.

Une demande de confirmation devra être effectuée afin de s'assurer qu'il ne sagit pas d'une erreur.

### L'ajout d'une note et appréciation
Lors de l'ajout d'une note et d'une appréciation sur un élève, un menu devra permettre d'indiquer le cours pour lequel la saisie doit être faite.

L'appréciation du professeur est facultative. Seule la note est obligatoire.

Un récapitulatif de la saisie, ainsi qu'une demande de confirmation permettront de valider l'ajout de la saisie à l'élève.

### L'enregistrement des données
Toute modification faite par l'utilisateur (ajout/suppression de cours, ajout de note etc...) donnera lieux à une sauvegarde au format JSON dans le fichier.

Lors du lancement du programme, le fichier JSON sera lu afin d'initialiser les données existantes sur le poste de l'utilisateur.

### La moyenne
La moyenne est une information calculée à la volée. Il ne faut donc pas l'enregistrer dans le fichier JSON.

La moyenne est arrondie à 1 chiffre après la virgule. Exemple : 

- 12 => 12/20
- 12.2 => 12/20
- 12.3 => 12.5/20
- 12.6 => 13/20

### Affichage
Afin de bénéficier de toute la puissance mise à disposition par la console, la mise en page des données devra permettre une lecture claire et aérée des informations. 

Exemple : 
```
----------------------------------------------------------------------
Informations sur l'élève : 

Nom               : Arus
Prénom            : Joshua
Date de naissance : 01/01/1980

Résultats scolaires:

    Cours : Mathématiques
        Note : 18/20
        Appréciation : Continue comme ça ! 

    Cours : Anglais
        Note : 6/20
        Appréciation : Aie aie aie, ça va pas du tout...

    Cours : Programmation
        Note : 13/20
        Appréciation : 

    Moyenne : 12.5/20
----------------------------------------------------------------------
```

### La gestion des erreurs
Toutes les saisies utilisateurs devront être contrôlées afin d'éviter les erreurs de saisie.

Dans le cas où la saisie de correspondrait pas à un choix valide, la question sera réaffichée, et la saisie redemandée.

Exemple : lors de la saisie d'une note, le cours doit obligatoirement exister dans l'application et être un choix proposé. Sinon, on demande à l'utilisateur de refaire sa saisie.

### Fichier de log
Chaque action utilisateur devra être enregistrée dans un fichier de log. Aussi bien les modifications de données que les consultations.

Hormi l'horodatage, la mise en page est libre mais doit permettre d'interpréter clairement l'action réalisée
Le fichier de log aura le même nom que le fichier JSON (à l'extension près) et sera stocké au même endroit

Exemple : 
```
2021-09-01 14:00:00 Consultation de la liste des élèves
2021-09-01 14:00:02 Consultation des détails de l'élève XXX
2021-09-01 14:00:10 Saisie d'une note pour l'élève XXX : "Anglais" 6/20 "Aie aie aie, ça va pas du tout..."
2021-09-01 14:00:15 Retour au menu principal
```

## Objectifs bonus facultatifs
Dans le cas où toutes les demandes fonctionnelles seraient remplies (et, j'insiste, seulement dans ce cas là), on pourra aller plus loin en implémentant la notion de "Promotion" avec les impacts suivants :

- Chaque élève est rattaché à une promotion
- La liste des promotions est déduites des élèves existants (pas stockées dans le fichier JSON)
- Une nouvelle entrée dans le menu principal permet d'afficher la liste des promotions existantes
- Un écran permettant d'afficher la liste des élèves dans une promotion (nom/prénom/etc... pas les notes)
- Un écran permettant d'afficher la moyenne par cours de tous les élèves d'une promotion donnée
- Sur l'écran qui liste les cours, la moyenne de chaque promotion par cours

Une saisie en mode console un peu plus "interactive" pourra être proposée. Vous êtes libres de la réaliser comme vous le souhaitez.

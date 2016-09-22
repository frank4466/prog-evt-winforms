# Principaux contrôles WinForms

L'objectif de ce chapitre est de présenter succinctement quelques contrôles WinForms parmi les plus utilisés.

> D'autres contrôles plus spécialisés seront présentés plus loin.

## Nommage des contrôles

Comme indiqué précédemment, il est fortement recommandé de donner un nom parlant à un contrôle immédiatement après son ajout au formulaire. Cela augmente fortement la lisibilité du code utilisant ce contrôle.

On peut aller plus loin et choisir une convention de nommage qui permet d'identifier clairement le type du contrôle. Le reste de ce chapitre fait des propositions, mais il n'existe pas de consensus à ce sujet. L'important est de rester cohérent dans la convention choisie afin que le code soit uniforme.

## Affichage de texte

Le contrôle **Label** est dédié à l'affichage d'un texte *non modifiable*. 

> On peut donner à un contrôle de ce type un nom finissant par `Lbl`. Exemple : `loginLbl`.

Il dispose d'une propriété **Text** qui permet de récupérer ou de définir le texte affiché par le contrôle.

## Saisie de texte

Le contrôle **TextBox** crée une zone de saisie de texte. 

> On peut donner à un contrôle de ce type un nom finissant par `Box`. Exemple : `loginTB`.

Voici ses propriétés importantes :

* **Text** permet de récupérer ou de définir la valeur saisie.
* **Enabled** permet, quand elle vaut `true`, d'en faire une zone en lecture seule (saisie impossible).

## Liste déroulante

Le contrôle **ComboBox** définit une liste déroulante. 

> On peut donner à un contrôle de ce type un nom finissant par `Box`. Exemple : `countryCB`.

Voici ses propriétés importantes :
* **Items** regroupe ses valeurs sous la forme d'une liste (collection) d'objets. On peut ajouter des valeurs dans la liste déroulante dans le concepteur du formulaire ou via le code.
* **DropDownStyle** permet de choisir le style de la liste. Pour obtenir des valeurs non éditables par l'utilisateur, il faut choisir le style `DropDownList`. 
* **SelectedIndex** récupère ou définit l'indice de l'élément actuellement sélectionné. Le premier élément correspond à l'indice 0.
* **SelectedItem** renvoit l'élément actuellement sélectionné sous la forme d'un objet.

```csharp
// Ajoute 3 pays à la liste
countryCB.Items.Add("France");
countryCB.Items.Add("Belgique");
countryCB.Items.Add("Suisse");

// Sélectionne le 2ème élément de la liste
countryCB.SelectedIndex = 1;
```

L'évènement **SelectedIndexChanged** permet de gérer le changement de la valeur sélectionnée de la liste.

```csharp
// Gère le changement de sélection dans la liste déroulante
private void countryCB_SelectedIndexChanged(object sender, EventArgs e)
{
    // On caste l'objet renvoyé par SelectedItem vers le type chaîne
    string selectedValue = (string) countryCB.SelectedItem;
    // ...
}
```

## Liste d'éléments

## Bouton

## Menu déroulant


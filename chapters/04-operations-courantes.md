# Opérations courantes avec les WinForms

L'objectif de ce chapitre est de rassembler les solutions à des besoins courants lorsqu'on développe une application WinForms.

## Gérer le redimensionnement d'un formulaire

Une IHM réussie doit adapter sa présentation à la taille de sa fenêtre, notamment lorsque celle-ci est redimensionnée par l'utilisateur.

### Interdire le redimensionnement

Une première solution, simple et radicale, consiste à interdire tout redimensionnement du formulaire. Pour cela, il faut modifier les propriétés suivantes du formulaire :

* **FormBorderStyle** : `Fixed3D` (ou une autre valeur commençant par `Fixed`).
* **MaximizeBox** et **MinimizeBox** ; `false`

Ainsi, le formulaire ne sera plus redimensionnable et les icônes pour le minimiser/maximiser ne seront plus affichés.

![](../images/no-redim.png)

### Gérer le positionnement des contrôles

Si le formulaire doit pouvoir être redimensionné, il faut prévoir de quelle manière les contrôles qu'il contient vont être repositionnés pour que le résultat affiché soit toujours harmonieux.

Le positionnement d'un contrôle s'effectue par rapport à son conteneur, qui peut être le formulaire ou un autre contrôle (exemples : **GroupBox**, **Panel**, **TabControl**). Les deux propriétés qui gouvernent le positionnement sont **Anchor** et  **Dock**. 

* **Anchor** décrit l'ancrage du contrôle par rapport aux bordures de son conteneur. Lorsqu'un contrôle est ancré à une bordure, la distance entre le contrôle et cette bordure restera toujours constante. 

> Par défaut, les contrôles sont ancrés en haut (`Top`) et à gauche (`Left`) de leur conteneur.

Si on donne à un contrôle les valeurs d'ancrage `Bottom` et `Right`, il sera déplacé pour conserver les mêmes distances avec les bordures bas et droite lors d'un redimensionnement de son conteneur. C'est le cas pour le bouton dans l'exemple ci-dessous.

![](../images/redim-anchor.png)

* **Dock** définit la ou les bordures du contrôles directement attachées au conteneur parent. Le contrôle prendra toute la place disponible sur la ou les bordure(s) en question, même en cas de redimensionnement.

Voici l'exemple d'un bouton attaché à la bordure gauche de son conteneur.

![](../images/redim-dock.png)

## Gérer l'arrêt de l'application

### Déclencher l'arrêt

Une application dont le programme principal contient une ligne du type `Application.Run(new MainForm())` se termine automatiquement lorsque l'utilisateur décide de fermer le formulaire `MainForm`.

Depuis un gestionnaire d'évènement, le même résultat s'obtient avec la commande `Application.Exit()`.

### Confirmer l'arrêt

Pour effectuer une demande de confirmation avant la fermeture, il faut ajouter un gestionnaire pour l'évènement **FormClosing** du formulaire. Dans ce gestionnaire, on peut afficher un message puis récupérer le choix de l'utilisateur.

```csharp
// Gère la fermeture du formulaire par l'utilisateur
private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
{
    if (MessageBox.Show("Etes-vous sûr(e) ?", "Demande de confirmation",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
    {
        e.Cancel = true;
    }
}
```

![](../images/exit-confirm.png)

la méthode `Show` renvoie son résultatsous la forme d'une valeur de type `DialogResult`. Si l'utilisateur répond `Non` (valeur `DialogResult.No`) à la demande de confirmation , la propriété `Cancel` de l'objet `FormClosingEventArgs` est définie à `true` pour annuler la fermeture. Sinon, l'application s'arrête.

> L'appel à `Application.Exit()` depuis un gestionnaire d'évènement déclenche l'évènement **FormClosing** et donc la demande de confirmation. 

## Afficher un formulaire

Une application WinForms se compose le plus souvent de plusieurs formulaires ayant des rôles différents.

L'affichage d'un formulaire peut se faire de façon modale ou non modale. Un formulaire **modal** doit être fermé ou masqué avant de pouvoir utiliser de nouveau le reste de l'application. C'est le cas des formulaire de type boîte de dialogue qui permettent d'interroger l'utilisateur avant de poursuivre le déroulement de l'application.

### Formulaire non modal

On affiche un formulaire non modal en instanciant un objet de la classe correspondante, puis en appelant la méthode `Show` sur cet objet.

```csharp
// Affiche le formulaire SubForm (non modal)
SubForm subForm = new SubForm();
subForm.Show();
```

### Formulaire modal

On affiche un formulaire modal en l'instanciant, puis en appelant sa méthode `ShowDialog`. Comme la méthode `MessageBox.Show`, elle renvoie un résultat de type `DialogResult` qui permet de connaître le choix de l'utilisateur.

```csharp
// Affiche le formulaire SubForm (modal)
SubForm subForm = new SubForm();
if (subForm.ShowDialog() == DialogResult.OK)
{
    // ...
}
```

Pour que cela fonctionne, il faut ajouter au formulaire modal au moins un bouton, puis avoir défini la propriété `DialogResult` de ce bouton. La valeur de cette propriété est renvoyée par la méthode `ShowDialog` lorsque l'utilisateur clique sur le bouton associé du formulaire modal. 

![](../images/form-modal.png)

Si le formulaire modal contient plusieurs boutons avec une propriété `DialogResult` définie et différente pour chacun d'eux, la valeur renvoyée par `ShowDialog` permet d'identifier celui sur lequel l'utilisateur a cliqué.

## Echanger des données entre formulaires

### Fournir des données à un formulaire

La manière la plus simple de fournir des données à un formulaire est de modifier son constructeur pour qu'il accepte des paramètres. Dans l'exemple ci-dessous, le constructeur du formulaire utilise la chaîne reçue en paramètre pour définir le texte affiché par un label.

```csharp
public partial class SubForm : Form
{
    public SubForm(string message)
    {
        InitializeComponent();
        inputLbl.Text = message;
    }
    // ...
```

Les formulaires sont des classes C# et peuvent donc comporter des attributs en plus des contrôles. La valeur de ces attributs peut être définie dans le constructeur ou par le biais d'accesseurs en écriture (mutateurs).

### Récupérer une donnée depuis un formulaire

Les contrôles contenus dans un formulaire sont gérés sous la forme d'attributs privés. On ne peut donc pas y accéder en dehors de la classe.

Pour pouvoir récupérer une propriété d'un contrôle depuis l'extérieur, on peut ajouter à la classe un accesseur qui renvoie cette valeur. Dans l'exemple ci-dessous, la propriété `Input` renvoie le texte saisi dans la **TextBox** nommée `inputBox`.

```csharp
public partial class SubForm : Form
{
    // ...
    public string Input 
    {
        get { return inputBox.Text; }
    }
}
```

Ainsi, on peut récupérer et utiliser la valeur saisie dans le formulaire d'origine. L'exemple ci-dessous modifie le titre de la fenêtre du formulaire appelant. 

```csharp
SubForm subForm = new SubForm("Entrez votre login");
if (subForm.ShowDialog() == DialogResult.OK)
{
    string login = subForm.Input;
    this.Text = "Bienvenue, " + login;
}
```

## Supprimer manuellement un gestionnaire d'évènement

Le fichier `.Designer.cs` associé à un formulaire est normalement géré automatiquement par Visual Studio. Il est cependant parfois nécessaire d'y intervenir manuellement.

Lorsqu'on a généré des gestionnaires d'évènements pour des contrôles avant de les renommer, on aboutit parfois à des gestionnaires d'évènements obsolètes et inutiles dans le fichier `.cs` d'un formulaire.

La suppression d'un tel gestionnaire d'évènement se fait en deux étapes :

* Supprimer la ligne qui ajoute le gestionnaire d'évènement au contrôle dans le fichier `.Designer.cs`. Cette ligne est du type `this.nomCtrl.nomEvenement += new System.EventHandler(nomGestionnaire)`. 
* Supprimer la méthode correspondant au gestionnaire dans le fichier `.cs`.

## Vérifier les noms des contrôles d'un formulaire

Nous avons vu précédemment qu'il était important de renommer systématiquement les contrôles ajoutés à un formulaire.

Pour vérifier tous les noms des contrôles, il suffit d'utiliser la liste déroulante de la zone des propriétés dans le concepteur de formulaire. On détecte immédiatement les contrôles qui n'ont pas été renommés.

![](../images/ctrl-names.png)
# WinForms et multithreading

L'objectif de ce chapitre est de comprendre comment faire réaliser plusieurs tâches en parallèle à une application WinForms.

> Il s'agit d'un sujet complexe, uniquement abordé ici dans ses grandes lignes.

## La notion de thread

On appelle **thread** (*fil*) un contexte dans lequel s'exécute du code. Chaque application en cours d'exécution utilise au minimum un thread. Une application gérant plusieurs threads est dite *multithread*.

De manire générale, on utilise des threads pour permettre à une application de réaliser plusieurs tâches en parallèle. L'exemple typique est celui d'un navigateur affichant plusieurs onglets tout en téléchargeant un fichier.

## WinForms sans multithreading

Une application WinForms est basée sur le paradigme de la programmation évènementielle : elle réagit à des évènements provenant du système ou de l'utilisateur. Plus techniquement, elle reçoit et traite en permanence des **messages** provenant du système d'exploitation. Voici quelques exemples de messages :

* Appui sur une touche du clavier.
* Déplacement de la souris.
* Ordre de rafraîchir l'affichage d'une fenêtre.
* ...

Une application WinForms s'exécute dans un thread, appelé thread principal ou thread de l'interface (*UI thread*). Le traitement des messages de l'OS ainsi que l'exécution du code des gestionnaire d'évènement ont lieu dans ce même thread.

Si un gestionnaire d'évènement lance une opération longue (chargement ou sauvegarde réseau, calcul complexe, etc), le traitement des messages de l'OS va ralentir, voire s'arrêter. L'application ne réagira plus aux actions de l'utilisateur et semblera bloquée.

On peut simuler une opération longue en arrêtant le thread courant dans un gestionnaire d'évènement, comme dans l'exemple ci-dessous.

```csharp
private void startMonoBtn_Click(object sender, EventArgs e)
{
    // Opération longue dans le thread principal => blocage de l'application
    infoLbl.Text = "Opération en cours...";
    Thread.Sleep(5000); // Arrête le thread courant pendant 5 secondes
    infoLbl.Text = "Opération terminée";
}
```

Cet exemple ainsi que les suivants nécessitent l'ajout de la directive ci-dessous.

```csharp
using System.Threading;
```

La règle d'or est la suivante : dans une application WinForms, toute opération potentiellement longue doit s'exécuter dans un thread séparé.

## Multithreading dans une application WinForms

Le framework .NET permet de manipuler des threads au travers de la classe **Thread**. L'utilisation de cette classe au sein d'une application WinForms pose cependant problème : le code exécuté dans ces threads n'a pas le droit d'accéder aux contrôles des formulaires (c'est un privilège réservé au thread principal). Des solutions de contournement existent mais sont relativement complexes.

Une meilleure alternative consiste à utiliser la classe **BackgroundWorker**. Elle permet de réaliser un traitement dans un thread séparé tout en offrant des mécanismes d'interaction avec le formulaire :

* L'évènement **DoWork** permet de définir le traitement à exécuter dans le thread.
* L'évènement **ProgressChanged** permet de notifier le formulaire de l'avancement du traitement.
* L'évènement **RunWorkerCompleted** signale au formulaire la fin du traitement.

Sa méthode `RunWorkerAsync` démarre un nouveau thread et débute l'exécution du traitement défini dans le gestionnaire de **DoWork**.

L'exemple de code ci-dessous utilise un **BackgroundWorker** dans lequel on simule une opération longue.

```csharp
private void startMultiBtn_Click(object sender, EventArgs e)
{
    infoLbl.Text = "Opération en cours..."; 
    worker.RunWorkerAsync(); // Démarre un thread
}

private void worker_DoWork(object sender, DoWorkEventArgs e)
{
    Thread.Sleep(5000); // Arrête le thread courant pendant 5 secondes
}

private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
    infoLbl.Text = "Opération terminée";
}
```

Avec cette technique, le thread WinForms principal n'est pas affecté par l'opération en cours et l'application reste réactive.

## Pour aller plus loin

Le multithreading est l'un des domaines les plus complexes et les plus intéressants du développement logiciel. Les ressources suivantes pourront vous aider à enrichir vos connaissances en la matière.

* [La classe WinForms BackgroundWorker (MSDN)](https://msdn.microsoft.com/fr-fr/library/system.componentmodel.backgroundworker.aspx)
* [Multithreading in WinForms](https://visualstudiomagazine.com/Articles/2010/11/18/Multithreading-in-WinForms.aspx)
* [Multithreading in .NET](http://www.yoda.arachsys.com/csharp/threads/)

## Annexe : exécution de code à intervalles réguliers

Le contrôle WinForms **Timer** permet d'armer une minuterie qui exécute du code à intervalles réguliers.

```csharp
private void countdownBtn_Click(object sender, EventArgs e)
{
    Timer timer = new Timer();
    timer.Tick += new EventHandler(timer_Tick); // timer_Tick est appelé à chaque déclenchement
    timer.Interval = 1000;                      // Le déclenchement a lieu toutes les secondes
    timer.Enabled = true;                       // Démarre la minuterie
}

// Code exécuté à chaque déclenchement du timer
void timer_Tick(object sender, EventArgs e)
{
    // ...
}
```

Attention toutefois : l'exécution du code associé au timer se fait dans le thread WinForms principal. Si le traitement associé est trop long, il peut bloquer l'application comme nous l'avons vu plus haut.
# Manuel d'utilisation


## Utilisation du projet (sans docker)

Ouvrir la solution `MathsLibrary.sln` et lancer la sous-application `Client`.


## Utilisation de Docker

Note : il est nécessaire de démarrer et utiliser ce projet sous Windows si vous souhaitez utiliser Docker.
En effet, il n'existe pas de version de WCF sous Linux.

Lancer le WS avec Docker : 

Démarrer `Docker For Windows`

Ouvrir un terminal et aller dans le répertoire `publish/` contenu dans la solution

Entrer : `docker build -t wcfhost:latest -t wcfhost:1 .`

	L'installation peut durer un certain temps puisque Docker doit récupérer l'image windowsservercore qui pèse plus de 6GO.

Une fois le build fini, entrer : `docker run -itd --name host wcfhost`

Si le run échoue (pas d'image host), re-lancer le build en vérifiant que les étapes précédentes ont été respectées

Utilisation du WS "dockerisé" : lancer l'application `Client` comme une utilisation de la solution sans Docker.


## Auteur

(mailto:maxime.flament@etu.unice.fr)[Maxime Flament]
=======
# tigli-soap-rest
Repository to host the code for the lab http://www.tigli.fr/doku.php?id=cours:ws-rest_and_ws-soap:lab 

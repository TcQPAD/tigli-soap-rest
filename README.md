# NOTE IMPORTANTE 

**Je n'ai pas pu finir le Lab 2 d� � un bug assez ennuyeux de Visual Studio.**

**Lorsque je veux ajouter une r�f�rence � l'application console du client (URL du endpoint), mon IDE crash et d�truit l'ensemble de mon projet**.

**J'ai essay� de r�-importer le projet, recommenc� de z�ro et le bug persiste.**

** Le code livr� sur cette branche n'est donc pas test�e, je ne sais pas s'il fonctionne puisque je ne peux pas ajouter de r�f�rence et donc lancer le client.**

Je vous ai contact� via Slack afin de vous faire part du probl�me et vous fournir un screenshot d�taillant le probl�me.


# Manuel d'utilisation


## Utilisation du projet (sans docker)

Ouvrir la solution `MathsLibrary.sln` et lancer la sous-application `Client`.


## Utilisation de Docker

Note : il est n�cessaire de d�marrer et utiliser ce projet sous Windows si vous souhaitez utiliser Docker.
En effet, il n'existe pas de version de WCF sous Linux.

Lancer le WS avec Docker : 

D�marrer `Docker For Windows`

Ouvrir un terminal et aller dans le r�pertoire `publish/` contenu dans la solution

Entrer : `docker build -t wcfhost:latest -t wcfhost:1 .`

	L'installation peut durer un certain temps puisque Docker doit r�cup�rer l'image windowsservercore qui p�se plus de 6GO.

Une fois le build fini, entrer : `docker run -itd --name host wcfhost`

Si le run �choue (pas d'image host), re-lancer le build en v�rifiant que les �tapes pr�c�dentes ont �t� respect�es

Utilisation du WS "dockeris�" : lancer l'application `Client` comme une utilisation de la solution sans Docker.


## Auteur

(mailto:maxime.flament@etu.unice.fr)[Maxime Flament]
=======
# tigli-soap-rest
Repository to host the code for the lab http://www.tigli.fr/doku.php?id=cours:ws-rest_and_ws-soap:lab 

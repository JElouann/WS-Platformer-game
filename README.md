Pour tester le jeu, aller dans la scene "Level"

Contrôles :

Clavier / Souris :
Q / D : Aller à gauche / droite
Z : Sauter
S : Activer l'hypervitesse (quand suffisamment de vitesse a été accumulée au préalable)

Manette : /!\ le support manette n'est pas présent dû à des raisons inconnus, mais l'action map est mappée (toutes mes excuses)
Joystick gauche : Aller à gauche / droite
Bouton A (sud) : Sauter
Gâchette droite : Activer l'hypervitesse


Feedbacks / effets ajoutés :

- le personnage se stretch en fonction de sa vélocité (plus il va vite dans une direction, plus il va s'étirer vers celle-ci)
- le personnage génère de la fumée en courant lorsqu'il va assez vite pour passer en hypervitesse (particle system)
- le personnage génère en permanence une trainée (trail renderer) qui s'agrandit en fonction de sa vitesse
- lorsque le personnage s'arrête subitement, un tremblement parcourt la caméra et un son de collision se joue
- son de saut lorsque le personnage saute
- lorsque le personnage ramasse une gemme, un son se joue parmi trois aléatoirement et un effet visuel se joue (VFX Graph)
- lorsque le personnage fonce sur un ennemi, ce dernier est propulsé
- lorsque la fin du niveau est atteinte, le personnage s'arrête et un feu d'artifice est lancé (VFX Graph)

  autres :
  - petite musique sympa qui boucle
  - post-rendering pour donner un léger effet d'écran de borne d'arcade

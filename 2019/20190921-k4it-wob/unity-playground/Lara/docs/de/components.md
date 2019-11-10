# Alle Skripte

> Klicke auf die Bilder, um eine ausführliche Erklärung zu erhalten.

## Bewegung

| Bild | Skriptname | Beschreibung |
| --- |:-:|:--|
| [![Move](../_images/unity/MoveWithArrows.png ':size=128')](/de/components#move) | `Move` | Bewege ein Objekt mit `WASD` oder den `Pfeiltasten` |
| [![Rotate](../_images/unity/RotateWithButtons.png ':size=128')](/de/components#rotate) | `Rotate` | Drehe ein Objekt mit `AD` oder den `Pfeiltasten` |
| [![Jump](../_images/unity/Jump.png ':size=128')](/de/components#jump) | `Jump` | Lass ein Objekt springen |
| [![AutoMove](../_images/unity/AutoMove.png ':size=128')](/de/components#automove) | `AutoMove` | Bewege ein Objekt automatisch |
| [![AutoRotate](../_images/unity/AutoRotation.png ':size=128')](/de/components#autorotate) | `AutoRotate` | Drehe ein Objekt automatisch |
| [![Push](../_images/unity/PushWithButton.png ':size=128')](/de/components#push) | `Push` | Schiebe ein Objekt |
| [![FollowTarget](../_images/unity/FollowTarget.png ':size=128')](/de/components#followtarget) | `FollowTarget` | Das Objekt verfolgt ein Ziel |
| [![Patrol](../_images/unity/Patrol.png ':size=128')](/de/components#patrol) | `Patrol` | Das Objekt bewegt sich zwischen Wegpunkten |
| [![CameraFollow](../_images/unity/CameraFollow.png ':size=128')](/de/components#camerafollow) | `CameraFollow` | Die Kamera verfolgt ein ausgewähltes Ziel |
| [![Wander](../_images/unity/Wander.png ':size=128')](/de/components#wander) | `Wander` | Das Objekt bewegt sich ohne Ziel |

## Attribute

| Bild | Skriptname | Beschreibung |
| --- |:-:|:--|
| [![Bullet](../_images/unity/BulletAttribute.png ':size=128')](/de/components#bullet) | `Bullet` | Merkt sich wer dieses Objekt geschossen hat. |
| [![DestroyForPoints](../_images/unity/DestroyForPoints.png ':size=128')](/de/components#destroyforpoints) | `DestroyForPoints` | Belohnt mit Punkten wenn dieses Objekt zerstört wird. |
| [![Resource](../_images/unity/ResourceAttribute.png ':size=128')](/de/components#resource) | `Resource` | Kann aufgehoben und verwendet werden. |
| [![Collectable](../_images/unity/CollectableAttribute.png ':size=128')](/de/components#collectable) | `Collectable` | Belohnt mit Punkten wenn dieses Objekt aufgehoben wird. |
| [![HealthSystem](../_images/unity/HealthSystemAttribute.png ':size=128')](/de/components#healthsystem) | `HealthSystem` | Erlaubt es Objekten Lebenspunkte zu haben. |
| [![ModifyHealth](../_images/unity/ModifyHealthAttribute.png ':size=128')](/de/components#modifyhealth) | `ModifyHealth` | Entfernt oder fügt Leben hinzu. |

## Gameplay

| Bild | Skriptname | Beschreibung |
| --- |:-:|:--|
| [![ObjectCreatorArea](../_images/unity/ObjectCreatorArea.png ':size=128')](/de/components#objectcreatorarea) | `ObjectCreatorArea` | Erzeugt Kopien von Objekte in einem Gebiet. |
| [![ObjectShooter](../_images/unity/ObjectShooter.png ':size=128')](/de/components#objectshooter) | `ObjectShooter` | Schießt Kopien eines Objekts in eine Richtung. |
| [![TimedSelfDestruct](../_images/unity/TimedSelfDestruct.png ':size=128')](/de/components#timedselfdestruct) | `TimedSelfDestruct` | Das Objekt verschwindet nach einiger Zeit. |
| [![PickUpAndHold](../_images/unity/PickUp.png ':size=128')](/de/components#pickupandhold) | `PickUpAndHold` | Heb ein Objekt auf und trag es herum. |

## Bedingungen

> mit [Aktionen](#aktionen) verwenden

| Bild | Skriptname | Beschreibung |
| --- |:-:|:--|
| [![ConditionArea](../_images/unity/ConditionArea.png ':size=128')](/de/components#conditionarea) | `ConditionArea` | Löst eine Aktion aus wenn ein Objekt das Feld betritt oder verlässt. |
| [![ConditionCollision](../_images/unity/ConditionCollision.png ':size=128')](/de/components#conditioncollision) | `ConditionCollision` | Löst eine Aktion aus wenn Objekte zusammenstoßen. |
| [![ConditionKeyPress](../_images/unity/ConditionKeyPress.png ':size=128')](/de/components#conditionkeypress) | `ConditionKeyPress` | Löst eine Aktion aus wenn eine Taste gedrückt, gehalten oder losgelassen wird. |
| [![ConditionRepeat](../_images/unity/ConditionRepeat.png ':size=128')](/de/components#conditionrepeat) | `ConditionRepeat` | Löst wiederholt Aktionen aus. |

## Aktionen

> mit [Bedingungen](#bedingungen) verwenden

| Bild | Skriptname | Beschreibung |
| --- |:-:|:--|
| [![OnOff](../_images/unity/ActionOnOff.png ':size=128')](/de/components#onoffaction) | `OnOffAction` | Aktiviert oder deaktiviert ein Objekt. |
| [![Create](../_images/unity/ActionCreate.png ':size=128')](/de/components#createaction) | `CreateAction` | Erzeugt ein neues Objekt. |
| [![Destroy](../_images/unity/ActionDestroy.png ':size=128')](/de/components#destroyaction) | `DestroyAction` | Zerstört ein Objekt. |
| [![Teleport](../_images/unity/ActionTeleport.png ':size=128')](/de/components#teleportaction) | `TeleportAction` | Teleportiert ein Objekt an einen neuen Ort. |
| [![ConsumeResource](../_images/unity/ActionConsumeResource.png ':size=128')](/de/components#consumeresourceaction) | `ConsumeResourceAction` | Verbraucht eine [Ressource](/de/components#resource). |
| [![DialogueBalloon](../_images/unity/ActionDialogueBalloon.png ':size=128')](/de/components#dialogueballoonaction) | `DialogueBalloonAction` | Zeigt eine Zeile Text an. |
| [![LoadLevel](../_images/unity/ActionLoadLevel.png ':size=128')](/de/components#loadlevelaction) | `LoadLevelAction` | Lädt ein neues Level. |

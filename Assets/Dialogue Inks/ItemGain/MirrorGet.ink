INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
Why would the count want a mirror next to his bed? So he wouldn't have to see his reflection every morning?
Take the mirror, or look at yourself?
    +[Look]
    -> look
    +[Take]
    -> take
    +[Leave]
    -> leave
    
=== look ===
You see your own reflection in the mirror. A flood of questions runs through your mind.
You wonder what will become of you when the sun rises.
You don't remember your life before you served this vampire.
What will become of you afterwards?
Probably the new count (or earl if its too cheesy haha)l of Down, it doesn't sound too bad.
Take the mirror?
    +[Take]
    -> take
    +[Leave]
    -> leave

=== take ===
It's a large mirror that weighs a lot. You feel like it'll take you forever to move with it.
~ itemName = "Mirror"
~ itemCost = "20"
~ gainItem("Mirror", 20)
You take the mirror.
    -> END
=== leave ===
You leave the mirror where it is.
    -> END
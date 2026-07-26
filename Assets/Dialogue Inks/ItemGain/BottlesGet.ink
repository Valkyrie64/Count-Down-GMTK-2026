INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
The count tried to drown his sorrows more than once
He's been sleeping here for a few weeks, between the bottles
All the bottles have been opened, but none are finished.
A little pick-me-up never hurts.
Take a half full bottle?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Half full bottle"
~ itemCost = "5"
~ gainItem("HFBottle", 5)
You take a bottle.
-> END

=== leave ===
You leave bottles.
-> END
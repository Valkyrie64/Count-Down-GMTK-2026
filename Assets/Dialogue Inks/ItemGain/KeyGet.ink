INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
As you walk on the carpet you feel like there's something hidden underneath.
You look underneath and indeed there is something, a key. A purple key.
It looks like something you know, or rather someone.*
Take the Purple Key ?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Purple Key"
~ itemCost = "5"
~ gainItem("Key", 5)
You take the purple key.
-> END

=== leave ===
You leave the key on the floor.
-> END
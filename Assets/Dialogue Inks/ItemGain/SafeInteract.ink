INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
In the middle of the wall there is a large recessed rectangle that resembles a safe.
There's a keypad and a handle; there's surely something very valuable inside.
    {
    - itemName == "Piece of paper":
    +[1897]
    -> open
    }
    +[1234]
    -> lock
    +[Leave]
    -> leave
        
=== open ===
You try the code 1-8-9-7 as the slip of paper says
And it works!
The safe opens and inside you find a bottle of wine.
It says "Chateau Petrus" on it; it must be several centuries old.
You must be extra vigilant with it.
Take the Fancy wine bottle ?
    +[Take]
    -> take
    +[Leave]
    -> leave2
    
=== lock ===
Nice try
But the Count wasn't born yesterday.
-> END
        
=== take ===
~ itemName = "Fancy wine bottle"
~ itemCost = "20"
~ gainItem("Wine", 20)
You take the bottle of wine.
-> END

=== leave ===
You leave the safe alone.
-> END

=== leave2 ===
You leave the wine in the safe.
->END
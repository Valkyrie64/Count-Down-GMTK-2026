INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
The count’s bed. He has been so depressed lately that he hasn't slept in that for weeks.

Instead he sleeps in the living room. At least it’s more comfortable. I guess.
    +[Open]
        -> open
    +[Leave]
        -> leave

=== open ===
You open the count's coffin, not without difficulty. Inside is a pink cushion with floral patterns, covered in blood.

Take the cushion ?

    +[Take]
        -> take
    +[Leave]
        -> leave2

=== leave ===
You leave the coffin alone.
-> END

=== leave2 ===
You leave the cushion in the coffin.
-> END

=== take ===
~ itemName = "Cushion"
~ itemCost = "10"
~ gainItem("Cushion", 10)
You take the cushion.
-> END
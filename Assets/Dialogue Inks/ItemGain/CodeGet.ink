INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
Under the rug you find a piece of paper
The slip of paper has red numbers written on it.
It looks like blood
It says "1897" on it
Take a "piece of paper"?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Piece of paper"
~ itemCost = "5"
~ gainItem("Code", 5)
You take the piece of paper.
-> END

=== leave ===
You leave paper under the carpet.
-> END
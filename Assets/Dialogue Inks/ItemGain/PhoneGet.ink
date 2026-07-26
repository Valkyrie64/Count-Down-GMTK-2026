INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
The count's first telephone call, he always preferred to speak face to face.
This was the first and last time he bought this kind of "modern" product.
Perhaps if he talks with loved ones it will bring back his joy of living.
Take the Telephone ?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Telephone"
~ itemCost = "15"
~ gainItem("Phone", 15)
You take the telephone.
-> END

=== leave ===
You leave telephone.
-> END
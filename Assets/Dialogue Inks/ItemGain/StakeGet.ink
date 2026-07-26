INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
The count's bedside table, he has owned it since the 20th century. A gift from another count in Romania.

    +[Open]
        -> open
    +[Leave]
        -> leave

=== open ===
There are wooden stakes in the cupboard, the perfect tool for killing a vampire.

Perhaps the Count would like me to bring them back to him.

Take a wooden stake ?

    +[Take]
        -> take
    +[Leave]
        -> leave2

=== leave ===
You leave the nightstand.
-> END

=== leave2 ===
You leave the stakes alone.
-> END

=== take ===
~ itemName = "Stake"
~ itemCost = "10"
~ gainItem("Stake", 10)
You take a stake.
-> END
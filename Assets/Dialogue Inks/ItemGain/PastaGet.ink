INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
Your plate of spaghetti is still on the table. You were eating it before the count announced his decision.
Perhaps you used too much tomato sauce. Maybe the Count will appreciate it.
Take the spaghetti?

    +[Take]
        -> take
    +[Leave]
        -> leave

=== leave ===
You leave the spaghetti.
-> END

=== take ===
~ itemName = "Spaghetti"
~ itemCost = "5"
~ gainItem("Pasta", 5)
You take the spaghetti.
-> END
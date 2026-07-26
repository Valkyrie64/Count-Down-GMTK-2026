INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
In the refrigerator you find a huge piece of meat. You have no idea what animal it is.
You're not even sure it's an animal
Take the meat?
    +[Take]
        -> take
    +[Leave]
        -> leave

=== leave ===
You leave the meat.
-> END

=== take ===
~ itemName = "Meat"
~ itemCost = "10"
~ gainItem("Meat", 10)
You take the meat.
-> END
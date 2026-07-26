INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
You tried to open the cabinet but despite all your efforts they remained closed.
Usually it's the count who opens it. It's the only place in the kitchen he visits every day.
He should know how to do it
    {
    - itemName == "Purple Key":
    +[Open]
        -> open
    }
    +[Leave]
        -> leave

=== leave ===
You leave door alone.
-> END

=== leave2 ===
You leave the lettuce inside.
-> END

=== open ===
You use the key and the door opens; inside there is a huge amount of purple salad.
Take some of it ?
+[Take]
-> take
+[Leave]
-> leave2

=== take ===
~ itemName = "Lettuce"
~ itemCost = "5"
~ gainItem("Lettuce", 5)
You take the lettuce.
-> END
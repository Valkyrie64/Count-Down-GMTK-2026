INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
This oven hasn't been used by the count for years.I mainly use it to cook my pasta.
    {
    - itemName == "Meat":
    +[Cook]
        -> cook
    }
    {
    - itemName == "Turtle":
    +[Cook?]
    -> cook2
    }
    +[Leave]
        -> leave

=== leave ===
You leave oven alone.
-> END

=== leave2 ===
You decide not to cook the food.
-> END

=== cook ===
What about a rare meat for the count ?
Cook the food ?
+[Yes]
-> take
+[No]
-> leave2

=== cook2 ===
No.
No you don’t.
-> END

=== take ===
~ itemName = "Cooked Meat"
~ itemCost = "5"
~ gainItem("CMeat", 5)
You cook the meat.
-> END
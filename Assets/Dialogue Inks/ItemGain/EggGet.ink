INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
In the freezer you find a huge egg that barely fits in this small space.
It is adorned with red color and some orange feathers are scattered beside it; the mother of this egg did not let it happen.
You are certain you can do something with this egg.
Take the Phoenix Egg ?
    {
    - itemName == "Turtle":
    +[Turtle]
        -> turtle
    }
    +[Take]
    -> take
    +[Leave]
    -> leave
    

=== leave ===
You leave the egg in the freezer.
-> END

=== turtle ===
As you prepare to put it in the freezer, its weight becomes abnormally heavier the closer you get to the freezer.
You move the turtle between yourself and the freezer several times to verify your theory.
You abandon your machiavellian plan and keep the purple turtle close to you.

-> END

=== take ===
~ itemName = "Phoenix Egg"
~ itemCost = "15"
~ gainItem("Egg", 15)
You take the phoenix egg.
-> END
INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
The only pet that can match the count's lifespan. He’s really attached to it

Maybe I can bring something to make him leave his little shelter.
    {
    - itemName == "Lettuce":
    +[Give Item]
        -> give
    }
    +[Leave]
        -> leave

=== give ===
You put the lettuce in front of the shelter, After some time a little purple turtle comes out of it and starts eating the lettuce.

Take the purple turtle?

    +[Take]
        -> take
    +[Leave]
        -> leave2

=== leave ===
You leave the shelter alone.
-> END

=== leave2 ===
You leave the turtle to his food.
-> END

=== take ===
~ itemName = "Turtle"
~ itemCost = "20"
~ gainItem("Turtle", 20)
You take the purple turtle.
-> END
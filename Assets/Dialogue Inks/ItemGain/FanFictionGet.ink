INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
The Count tried his hand at writing by writing Frankenstein in his own way.
He did that in his youth, when he must have been 200 years old.
He never let me read it, I've always wondered why.
Take Suspicious fan-fiction ?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Fan Fiction"
~ itemCost = "10"
~ gainItem("FanFiction", 10)
You take the fan fiction.
-> END

=== leave ===
You leave fan fiction on the shelf.
-> END
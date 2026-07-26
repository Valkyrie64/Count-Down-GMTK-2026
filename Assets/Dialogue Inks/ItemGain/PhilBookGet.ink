INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
A book about life and its meaning. The Count has always loved subjects that make the brain work.
Perhaps a little down-to-earth, the count is not in a good mood.
Take the Philosophical book ?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Philosophical Book"
~ itemCost = "10"
~ gainItem("PhilBook", 10)
You take the philosophical book.
-> END

=== leave ===
You leave book on the shelf.
-> END
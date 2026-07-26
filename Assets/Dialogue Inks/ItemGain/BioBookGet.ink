INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
A book about nature, more precisely about the human body
In order to better understand its victims and how they operate
Take the Biology book ?

    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Biology Book"
~ itemCost = "10"
~ gainItem("BioBook", 10)
You take a biology book.
-> END

=== leave ===
You leave the book on the shelf.
-> END
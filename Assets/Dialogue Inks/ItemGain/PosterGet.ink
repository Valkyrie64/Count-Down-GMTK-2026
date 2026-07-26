INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
A poster depicting the Count's victory in a monster race 40 years ago.
He came in first, ahead of the Werewolf Lord and the Banshee Queen.
He still taunts them as of today.
It's very heavy, but I'm sure it will make him happy.
Take the poster ?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Poster"
~ itemCost = "30"
~ gainItem("Poster", 30)
You take the poster.
-> END

=== leave ===
You leave the poster hanging.
-> END
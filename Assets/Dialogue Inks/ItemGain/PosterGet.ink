INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

-> main

=== main ===
A poster depicting the Count's victory in a monster race 40 years ago.
He came in first, ahead of the Werewolf Lord and the Banshee Queen.
He still taunts them as of today.
It's very heavy, but I'm sure it will make him happy.
Take the trophy ?
    +[Take]
        -> take
    +[Leave]
        -> leave
        
=== take ===
~ itemName = "Poster"
~ itemCost = "20"
~ gainItem("Poster", 20)
You take the trophy.
-> END

=== leave ===
You leave the trophy hanging.
-> END
INCLUDE ../Globals.ink
EXTERNAL gainItem(itemName, itemCost)

LIST letters = (Hween), (Love), (Ad), (Fan), (British), (Threat)

The count has been very disorganized these last few days; he hasn't even tidied his office as usual.

There's too much paper, it's hard to concentrate. I'll just pick one at random and see what it says.

Take one paper at random ?

    +[Take]
    -> random
    +[Leave]
    -> leave
    
    === random ===
You take a letter at random.
{
- LIST_RANDOM(letters) == letters.Hween:
-> hween
- LIST_RANDOM(letters) == letters.Love:
-> love
- LIST_RANDOM(letters) == letters.Ad:
-> ad
- LIST_RANDOM(letters) == letters.Fan:
-> fan
- LIST_RANDOM(letters) == letters.British:
-> british
- else:
-> threat
}

=== leave ===
You leave the letters where they are.
-> END

=== hween ===
~ itemName = "Halloween Letter"
~ itemCost = "5"
~ gainItem("Letter", 5)
You found an invitation to this year's village Halloween ball.
You notice that next to this paper there were the invitations from the last 80 editions.
You have a good feeling about this.
-> END

=== love ===
~ itemName = "Love Letter"
~ itemCost = "5"
~ gainItem("Letter", 5)
You found a letter written in a language you cannot understand.
At the end of the letter there is a lipstick mark in the shape of a kiss.
You may not understand the language, but you have an idea of the message.
You have a very good feeling about this.
-> END

=== ad ===
~ itemName = "Ad Letter"
~ itemCost = "5"
~ gainItem("Letter", 5)
An advertisement for installing fiber optics in the castle.
Nothing beats going online to stop wanting to die.
You don’t know how the count is going to react.
-> END

=== fan ===
~ itemName = "Fan Letter"
~ itemCost = "5"
~ gainItem("Letter", 5)
You find a letter from an admirer who wishes to meet the count.
He usually accepts these kinds of requests; the young girls always end up missing after their visit to the castle.
You don't know if the count is in the right mood.
-> END

=== british ===
~ itemName = "British Letter"
~ itemCost = "5"
~ gainItem("Letter", 5)
You found a letter from a British aristocrat who wants to adopt the count into their family, that's suspicious…
You have a feeling of déjà vu and a knot in your stomach.
-> END

=== threat ===
~ itemName = "Threatining Letter"
~ itemCost = "5"
~ gainItem("Letter", 5)
You find a very aggressive letter addressed to him; you know he has enemies, but to this extent.
The letter is signed by someone named Simon.
You have a very bad feeling about that one.
-> END
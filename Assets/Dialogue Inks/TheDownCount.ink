INCLUDE Globals.ink

-> main

=== main ===
"What do you want?"
    +[Show Item]
    -> itemCheck
    
    +[Leave]
    "If you have nothing to say then go."
    -> END

=== itemCheck ===
    {
    - itemName == "Cushion":
    <> You show him the cushion.
    -> cushion
    - itemName == "Stake":
    <> You show him the stake.
    -> stake
    - itemName == "Halloween Letter":
    <> You show him the invitation
    -> hletter
    - itemName == "Love Letter":
    <> You show him letter
    -> lletter
    - itemName == "Ad Letter":
    <> You show him the advert
    -> aletter
    - itemName == "Fan Letter":
    <> You show him the letter
    -> fletter
    - itemName == "British Letter":
    <> You show him the letter
    -> bletter
    - itemName == "Threatining Letter":
    <> You show him the letter
    -> tletter
    - else:
    <> You have nothing with you.
    ->END
    }

=== cushion ===
"Where did you find this?"

"I forgot whos blood that is."

-> END

=== stake ===
//stake stuff
-> END

=== hletter ===
A halloween invitation?
-> END

=== lletter ===
A love letter?
-> END

=== aletter ===
An advert?
-> END

=== fletter ===
A fan letter?
-> END

=== bletter ===
A british letter?
-> END

=== tletter ===
A threat?
-> END
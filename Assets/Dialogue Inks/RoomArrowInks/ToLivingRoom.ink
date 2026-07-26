INCLUDE ../Globals.ink
EXTERNAL roomChange()

-> main

=== main ===
Moving with the {itemName} will take {itemCost} minutes. Continue?
    +[Move]
    ~ roomChange()
    Now in the Living Room.
        ->END
    +[Stay]
    You stayed where you are.
        -> END

    
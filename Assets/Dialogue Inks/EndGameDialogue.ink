INCLUDE Globals.ink
EXTERNAL moodCheck(win)

//You have a mood of {moodValue}

The Count calls you back up
{
- moodValue >= 50:
-> win
- else:
-> lose
}

=== win ===
~ moodCheck(true)
The Count is happy and decides to come inside.
-> END

=== lose ===
~ moodCheck(false)
The Count has lost all hope and sits till sunrise.
-> END
INCLUDE Globals.ink
EXTERNAL countValueChange(dialogueCountValue)

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
    - itemName == "Piece of paper":
    <> You show him the paper.
    -> code
    - itemName == "Turtle":
    <> You show him the turtle.
    -> turtle
    - itemName == "Mirror":
    <> You show him the mirror.
    -> mirror
    - itemName == "Meat":
    <> You show him the meat.
    -> meat
    - itemName == "Cooked Meat":
    <> You show him the meat.
    -> cmeat
    - itemName == "Phoenix Egg":
    <> You show him the phoenix egg.
    -> egg
    - itemName == "Spaghetti":
    <> You show him the spaghetti.
    -> pasta
    - itemName == "Poster":
    <> You show him the trophy.
    -> trophy
    - itemName == "Fancy wine bottle":
    <> You show him the wine bottle.
    -> wine
    - itemName == "Telephone":
    <> You show him the telephone.
    -> phone
    - itemName == "Half full bottle":
    <> You show him the half full bottle.
    -> hfbottle
    - itemName == "Philosophical book":
    <> You show him the book.
    -> philbook
    - itemName == "Fan Fiction":
    <> You show him the fan fiction.
    -> fanfiction
    - itemName == "Biology Book":
    <> You show him the book.
    -> biobook
    - else:
    <> You have nothing with you, or what you have doesn't interest the Count.
    ->END
    }

=== cushion ===
The count doesn't say a word. He puts on a baby face and grabs the cushion before hugging it.
~ countValueChange(15)
~ moodValue = moodValue + 15
~ itemName = ""
~ itemCost = ""
He stays like that for a while. It must remind him of something dear to his heart
-> END

=== stake ===
"Hey, you've been going through my things !"
"Not that it means anything now."
~ countValueChange(-5)
~ moodValue = moodValue - 5
~ itemName = ""
~ itemCost = ""
"If you want to do me a favor, instead of searching my mansion, plant this thing in my heart. Thanks in advance."
-> END

=== hletter ===
"Ah yes, that's right, there's that party"
"The people of this village continue to invite me, generation after generation."
"They must really have no friends to be begging for my presence HA!"
~ countValueChange(15)
~ moodValue = moodValue + 15
~ itemName = ""
~ itemCost = ""
"In any case, they're thinking of me and that means something, I suppose…"
-> END

=== lletter ===
The count's pale, white skin turned tomato red in a second
"WHERE DID YOU FIND THIS LETTER !!?"
"I'VE BEEN LOOKING FOR IT FOR YEARS AND I FORBID YOU TO ASK ME WHY"
"In the pile of letters in my room? You're really going through my things, huh?"
The count looks at the letter in his hands for a few seconds. He begins to smile slightly.
~ countValueChange(30)
~ moodValue = moodValue + 30
~ itemName = ""
~ itemCost = ""
"She was... everything"
-> END

=== aletter ===
"They're still sending us letters? I told you to tell them that my carrier pigeons do a much better job than theirs…"
~ countValueChange(-5)
~ moodValue = moodValue - 5
~ itemName = ""
~ itemCost = ""
"Internet filter. Or whatever"
-> END

=== fletter ===
"You really picked the best night to annoy me"
"This girl is completely crazy, even for me. She's been harassing me for months."
~ countValueChange(-30)
~ moodValue = moodValue - 30
~ itemName = ""
~ itemCost = ""
"Why are you reminding me of her existence now...?"
-> END

=== bletter ===
"Do you think I have nothing better to do? At my age, joining some random family like that?"
~ countValueChange(-15)
~ moodValue = moodValue - 15
~ itemName = ""
~ itemCost = ""
"The one setting traps isn't the nobles! It's Down!"
-> END

=== tletter ===
"Simon again? I'm fed up with his behavior."
"I almost want to stay alive just to teach him a good lesson."
~ countValueChange(5)
~ moodValue = moodValue + 5
~ itemName = ""
~ itemCost = ""
"And then let myself die right after, obviously."
-> END

=== code ===
"I thought I had hidden the code to my most precious possession well."
"Do what you want with it, I'll never have the chance to enjoy it to its full potential"
-> END

=== turtle ===
"Oooowh Franklin, my love !"
The count takes Franklin the purple turtle in his arms
"How could I leave and abandon you here in your immortality?"
~ countValueChange(30)
~ moodValue = moodValue + 30
~ itemName = ""
~ itemCost = ""
Franklin doesn't move an inch, as if he's stuck in the same position, yet you can still see the turtle smiling.
-> END

=== mirror ===
You place the large mirror in front of the count and look at him
"What ? What do you want me to say ? Are you just reminding me that I don't even exist ?"
The count strikes the mirror, shattering it into a thousand pieces.
~ countValueChange(-30)
~ moodValue = moodValue - 30
~ itemName = ""
~ itemCost = ""
You decide to end the conversation here to avoid suffering the same fate as the mirror.
-> END

=== meat ===
The count's gaze is fixed on the gigantic piece of meat you brought him.
Without a word, he forcefully grabs the piece and swallows it whole in one bite.
The size of his jaw grew like a monster's to be able to fit the piece
"I'd forgotten I'd put that piece away covered in blood."
~ countValueChange(30)
~ moodValue = moodValue + 30
~ itemName = ""
~ itemCost = ""
"Thanks for reminding me that life can have its flavors."
-> END

=== cmeat ===
The count doesn't even look at you; his gaze is fixed on the piece of meat you're bringing.
His face shows a disappointment you've never seen before; this may be the saddest moment of the Count's life.
"You...you cooked my meat? Since when do I cook my meat? There's no blood left, nothing…"
After several seconds of silence while staring at the meat, the count looks at you.
~ countValueChange(-30)
~ moodValue = moodValue - 30
~ itemName = ""
~ itemCost = ""
You think leaving as early as possible is a good idea, so you don't end up like his new afternoon snack
-> END

=== egg ===
"The noble phoenix, the animal that never dies, always rises from its ashes."
"It is also a form of immortality, while still dying from time to time."
"Is it a blessing that I have not tasted the punishment of death like the phoenix ?"
"I don't really know, but hunting for that egg made me feel more alive than ever."
~ countValueChange(15)
~ moodValue = moodValue + 15
~ itemName = ""
~ itemCost = ""
"Hah, how paradoxical."
-> END

=== pasta ===
"Where did you find this ? I haven't cooked in a while."
~ countValueChange(5)
~ moodValue = moodValue + 5
~ itemName = ""
~ itemCost = ""
"It better not have any garlic in it. Or maybe it should."
-> END

=== trophy ===
You walk towards the count, who begins to smile more and more as you approach.
"This thing really makes me feel old."
He said this before grabbing the trophy and looking it up and down.
"When I think that those other clowns thought they had a chance against me"
~ countValueChange(30)
~ moodValue = moodValue + 30
~ itemName = ""
~ itemCost = ""
He then starts laughing like an idiot for several minutes, you decide to leave him after the 8th.
-> END

=== wine ===
As you approach the count, he looks at you with wide eyes.
Well, not really you. More like the bottle you're holding.
"You actually brought it? Okay, I thought you were joking...do you know how much that thing costs?"
Before you even have time to guess, he grabs the bottle and finishes it in one gulp.
~ countValueChange(30)
~ moodValue = moodValue + 30
~ itemName = ""
~ itemCost = ""
The count might have a problem with liquor.
-> END

=== phone ===
You hand the telephone to the count and suggest he call someone
If you insist, it's not like I have anything to lose.
He dials a number he seems to know by heart and waits for someone to answer.
Someone finally replies
"Yes, hel-"
The count didn't even have time to finish his sentence before you heard the sounds of an old woman screaming coming from the telephone.
The massacre lasts an eternity; the count is just there, enduring the screams with a face like a funeral, while the screams never stop.
The person on the other end of the line eventually hung up without giving the count time to reply.
The count hands you back the telephone without saying a word, without moving his head, still dejected.
~ countValueChange(-30)
~ moodValue = moodValue - 30
~ itemName = ""
~ itemCost = ""
Mother Down is still being her usual self…
-> END

=== hfbottle ===
"Are they still in the living room? Geez, I'm really letting myself go…"
You offer the bottle to the count, who gladly accepts it.
He takes a sip, then looks at you. He spits out the contents automatically, wetting you in the process.
~ countValueChange(-15)
~ moodValue = moodValue - 15
~ itemName = ""
~ itemCost = ""
"Okay, now I remember why I never finished those bottles…"
-> END

=== philbook ===
"I think, therefore I am. But if I do not die and do not fear death, what is the point of thinking?"
"Thinking helps to keep the brain and soul active and healthy."
"But it's useless to me. Whether I think or not, I'll remain alive, devoid of all sensation."
"What is the goal?"
You stopped listening at that point. You hear him continuing to talk but pay no attention.
You end up hearing fewer and fewer words and more and more tears.
~ countValueChange(-15)
~ moodValue = moodValue - 15
~ itemName = ""
~ itemCost = ""
Until all that could be heard were tears.
-> END

=== fanfiction ===
You go to the count's house with a smile on your face. He looks at you with an intrigued and tired expression.
You have the book hidden behind your back. Once in front of him, you show him the contents of your hand.
His face turns red, a mixture of embarrassment and anger. He lets out a cry more like a little girl's than a vampire lord's.
He grabs the book and chases after you. You manage to escape just in time.
~ countValueChange(-30)
~ moodValue = moodValue - 30
~ itemName = ""
~ itemCost = ""
That went pretty well, didn't it?
-> END

=== biobook ===
"The human body is fascinating. It contains so many miracles and incredible ingenuity to make this giant machine work."
"Everything is done to prioritize survival above all else."
"Did you know that humans can lift gargantuan weights or run at breathtaking speeds if their lives are at stake ?"
"They must really be attached to their lives to…"
In the middle of his sentence, the count gradually stopped speaking and stared into space.
~ countValueChange(-15)
~ moodValue = moodValue - 15
~ itemName = ""
~ itemCost = ""
Who would have thought that a vampire could be jealous of humans' survival instinct and adrenaline?
-> END

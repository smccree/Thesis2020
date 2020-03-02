using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    /*class is a box that stores references to all the dialogue in the game
    treats like a string table
    naming convention: room and response #
    for now each room gets 5
        1 = line Voice says, 4 = responses to the player's input

    Also: 5 generic failure lines; aka you have disappointed me, you're not taking this seriously.

        IMPORTANT NOTE:
        this probably will have to be rebuilt as a DICTIONARY with key/value pairs
        
        -Key: conversation #/identification code
        -array of strings:
            string[0] = first line/intro of the conversation
            string[1-4] = response A - D
        -list of keywords:
            iterate through player input string to find a match to keyword[0-2]

        what I THINK I should do:
        Dictionary<string, string[]> dict_lines = new Dictionary<string, string[]>();
        where string = key
        string[] = values:
            string[0] = intro of the conversation
            string[1] = ANOTHER list of keywords
            string[2 - 5] = responses A - D

        WHAT I ACTUALLY AM DOING
        2 dictionaries: one for key: keywords, one for key: dialogue lines.
    */

    //initializing the dictionary:
    public static Dictionary<string, string[]> dict_lines = new Dictionary<string, string[]>();
    public static Dictionary<string, string[]> dict_keywords = new Dictionary<string, string[]>();
    
    //-------------------------------------------------------- The Strings ------------------------------------------------------------------

    public static string Name = "Mysterious Voice";
    public static string Name_Revealed = "Rebecca Stearn";

    public static string Entrance_OP = "I hear something ... can it be, a visitor? It's been so long! So then, who are you? What are you doing here?";
    public static string Entrance_0 = "So someone didn't ask you to come here? I find it rather unlikely that you just wandered into this house on your own.";
    public static string Entrance_1 = "Nothing makes sense here, does it? Well no matter. Now that you're here we can work together. Take a look around, let me know if you find anything.";
    public static string Entrance_2 = "I might be the one you came here looking for. If we can find out what happened to me, that solves both our problems. Well, take a look around then. Something in this house must have the information we're looking for.";
    public static string Entrance_3 = "You're a private investigator? That's perfect - you can help me! If you're looking for someone, well then I'm probably her. It would help if I could remember anything else, though. Well, take a look around then. Something in this house must have the information we're looking for.";
    public static string[] Entrance_Keywords = { "private", "investigator", "HA", "H", "A", "searching", "missing", "sister", "woman", "person" };

    public static string Dining_OP = "It's so dark in here, even with all these windows. There must be a storm brewing outside. Have you found anything in here?";
    public static string Dining_0 = "That's a little disappointing. Maybe you should look again.";
    public static string Dining_1 = "'Hannah'... could that be the 'H.A.' who sent you here?";
    public static string Dining_2 = "I've been thinking about that bible. 'An eye for an eye, and a tooth for a tooth, huh.' It seems fair on the outset, but it's quite cruel, when you think about it. I'd rather live and let live. Ironic, given the circumstances.";
    public static string Dining_3 = "Hold on a moment. Those names sound familiar. Hannah and Rebecca ... sisters. Hannah Ainsworth and Rebecca Stearn! Yes! I must have known them.";
    public static string[] Dining_Keywords = { "bible", "note", "Hannah", "Rebecca", "Paris", "paris", };

    public static string Library_OP = "Nothing so comforting as rows of books and a shawl to wrap around one's shoulders, I think. Did you get a chance to read that note there on the table?";
    public static string Library_0 = "Oh come now, be serious! I need to know what it says. I might remember something.";
    public static string Library_1 = "So Rebecca was staying here for the summer. The house is quite empty now, save the two of us. Where has everyone gone?";
    public static string Library_2 = "I suppose Rebecca Stearn is a writer, then. Kind of Frederick to invite her to stay for the summer.";
    public static string Library_3 = "Frederick Beale ... I think I remember him. Always wore green. He used to sit in this chair, reading, for hours.";
    public static string[] Library_Keywords = { "Rebecca", "Frederick", "write", "book", "visit", "summer", "Fred", "fred", "frederick" };

    public static string Study_OP = "This must be Frederick's office. I was never allowed in here. I always wondered what I might find.";
    public static string Study_0 = "Look harder. I have a bad feeling.";
    public static string Study_1 = "Things don't seem to be going well for Beale and Crofton. From that letter it doesn't seem like Stanley is taking it well.";
    public static string Study_2 = "So Stanley was pressuring Eliza into marrying him? And Frederick just went along with it? The gall of some men - I swear!";
    public static string Study_3 = "I remember Stanley! Always a snotfaced little shnouzer. Always yapping around crying for attention and getting angry when he wouldn't get his way.";
    public static string[] Study_Keywords = { "ledger", "Stanley", "Crofton", "publishing", "profits", "losses", "Eliza", "rejection" };

    public static string Rebecca_OP = "Hold on a minute. I think ... this was MY bedroom. I think I'm Rebecca! I feel a bit sick, now. Tell me, what did I write in my diary?";
    public static string Rebecca_0 = "That doesn't sound like something I'd write. Are you trying to pull one over on me?";
    public static string Rebecca_1 = "I think I remember a feeling. Butterflies in my stomach, walking into this house. Meeting everyone. I was so hopeful.";
    public static string Rebecca_2 = "You think I fancy Frederick? I-I have no idea what you're talking about. How is this relevant? Anyway let's move on. Best not to dwell on this nonsense.";
    public static string Rebecca_3 = "I-I used to have tea every night before bed. Without fail. But that tea cup...I don't know how it would have fallen. I'm always so careful. Even remembering who I am, it's all still so hazy.";
    public static string[] Rebecca_Keywords = { "tea", "cup", "broken", "excited", "frederick", "Frederick", "Fred", "fred", "Eliza", "eliza", "like" };

    public static string Drawing_OP = "Have you ever been to a party in a room like this? I never understood the appeal, to be honest. Balls and dancing require too much attention.";
    public static string Drawing_0 = "Ha ha. You've got quite the sense of humor. C'mon, now, there must be more here.";
    public static string Drawing_1 = "Stanley seems a tad ... overbearing, to say the least.";
    public static string Drawing_2 = "I hope Eliza had fun at the ball, even if Stanley was breathing down her neck.";
    public static string Drawing_3 = "I think I remember something. Music, on a piano forte. And small glasses of champagne. I'd never been anywhere like that, before.";
    public static string[] Drawing_Keywords = { "ball", "invited", "Eliza", "eliza", "Stanley", "dance", "stanley", "alice", "Alice", "distract" };

    public static string Eliza_OP = "This must be Eliza's room. I have an image of her sitting in this chair, writing letters.";
    public static string Eliza_0 = "You don't seem very good at this. Perhaps read it over again.";
    public static string Eliza_1 = "He actually wrote that? 'A delicate flower?' Please excuse me while I vomit.";
    public static string Eliza_2 = "It seems that neither Stanley nor Fred know what's in Eliza's best interests. She's every right to be angry.";
    public static string Eliza_3 = "Eliza actually laughed, come to think of it, when she got this letter. She was beyond words. And she really let Fred have it at suppertime.";
    public static string[] Eliza_Keywords = { "Stanley", "Fred", "stanley", "fred", "scheming", "marry", "marriage", "proposal", "rejected", "plan", "mad" };

    public static string Fred_OP = "Things are piecing together for me. My memories are still a touch vague, though. What was that you found on the nightstand?";
    public static string Fred_0 = "Come now, be serious.";
    public static string Fred_1 = "Opera tickets? That would make for a lovely evening.";
    public static string Fred_2 = "An invitation from Fred to the Opera? I think I remember. It was a lovely time.";
    public static string Fred_3 = "You know, I always thought Fred didn't like me, but then we went to the opera and had a grand old time. But he made me angry. We fought about something. I-I can't remember anything else.";
    public static string[] Fred_Keywords = { "opera", "tickets", "ticket", "invited", "fred", "Fred" };

    public static string Dressing_OP = "A letter and a page that looks like it was torn from Fred's journal ... this doesn't bode well.";
    public static string Dressing_0 = "There must be more to this than what you've said. Read it again, would you?";
    public static string Dressing_1 = "At the very least, I'm glad Eliza finally made it to Paris. But what a mess this all has become.";
    public static string Dressing_2 = "I would never say something like that. Eliza's got it all wrong. I mean, clearly, something stopped me from going to Paris.";
    public static string Dressing_3 = "I don't like any of this. Fred must have told Eliza I said all that. And I suppose that journal entry gives us the reason why.";
    public static string[] Dressing_Keywords = { "paris", "Paris", "stanley", "Stanley", "follow", "following", "disrespected", "spinster", "persuade", "marry" };

    public static string Kitchen_OP = "Anything cooking in this kitchen? No? Not funny? Well you're no comic either.";
    public static string Kitchen_0 = "Like I said, not funny.";
    public static string Kitchen_1 = "I don't like the idea of going down for a cuppa and winding up with a mouthful of laudanum.";
    public static string Kitchen_2 = "Laudanum is nasty stuff. I'm surprised you found a bottle. Even a touch of it is highly addictive. Too much of it, well....";
    public static string Kitchen_3 = "I remember something else. My nightly cup of tea. Fred brought it up for me. I thought that was unusual and asked him where Alberta was. He said she had gone to visit family.";
    public static string[] Kitchen_Keywords = { "laudanum", "poison", "tea", "pot", "teapot", "teacup", "cup", "sleep" };

    public static string Cellar_OP = "I changed my mind. Let's get out of here. I don't care about what happened in this place anymore. I don't want to know what you found.";
    public static string Cellar_0 = "It's probably for the best, that I don't know. I don't want to remember.";
    public static string Cellar_1 = "Why did you tell me? I told you I don't want to hear it. I didn't want to remember everything. But I do.";
    public static string Cellar_2 = "Why did you tell me? I told you I don't want to hear it. I didn't want to remember everything. But I do.";
    public static string Cellar_3 = "Why did you tell me? I told you I don't want to hear it. I didn't want to remember everything. But I do.";
    public static string[] Cellar_Keywords = { "crate", "body", "empty", "dragged", "street", "deliver", "work", "dissect"  };

    public static string Housekeeper_OP = "Alberta's room. She was a lovely woman. I shudder to think that she was involved with all this.";
    public static string Housekeeper_0 = "You didn't find anything? Are you sure?";
    public static string Housekeeper_1 = "That's an odd favor to ask of someone.";
    public static string Housekeeper_2 = "Alberta went along with this? I suppose it makes sense. She's been employed with the Beales for years.";
    public static string Housekeeper_3 = "I don't want to hear any more.";
    public static string[] Housekeeper_Keywords = { "note", "Fred", "crate", "sons", "deliver", "ask", "bring", "back", "security" };

    public static string Popup_Lore_1 = "Line about book";
    public static string Popup_Lore_2 = "Line about opera tickets";
    public static string Popup_Lore_3 = "Line about R. diary";
    public static string Popup_Lore_4 = "Line about teacup";
    public static string Popup_Lore_5 = "Line about opiate/poison found in scullery";
    public static string Popup_Lore_6 = "Line about Fred's letter";
    public static string Popup_Lore_7 = "Line about finished manuscript";
    public static string Popup_Lore_8 = "Line about letter from Eliza";
    public static string Popup_Lore_9 = "Line about Stanley";
    public static string Popup_Lore_10 = "Line about Fred";

    public static string Locked_Study = "Locked, huh? I'm sure the key is around here somewhere.";
    public static string Locked_Basement = "This is quite an odd looking door. It seems as though you'll need three keys to open it.";
    public static string Locked_Cellar = "Another locked door? This house has more security than a bank vault.";

    public static string Voice_Failure_1 = "You are an excellent debugger";
    public static string Voice_Failure_2 = "You go girl! Get that game did!";
    public static string Voice_Failure_3 = "Who's the best coder? You are!";
    public static string Voice_Failure_4 = "Allie approves of this message.";
    public static string Voice_Failure_5 = "All's fair in love and debugging - Allie";
    /*
    public static string Voice_Failure_1 = "You can't be serious! Are you even trying to help me?";
    public static string Voice_Failure_2 = "You don't have to be here, you know. You can walk out the front door and forget all about this place, if you want. Some of us don't have that luxury.";
    public static string Voice_Failure_3 = "If you're going to joke around like that, you might as well go home and bother some other poor soul.";
    public static string Voice_Failure_4 = "You ARE a Private Investigator, right?";
    public static string Voice_Failure_5 = "Very funny. Now, let's try that again.";
    */
    public static string Voice_Cancel_1 = "I'll be here when you're ready.";
    public static string Voice_Cancel_2 = "Let me know when you're ready to talk again.";
    public static string Voice_Cancel_3 = "Need another look around?";

    public static string Voice_EndDrama_1 = "I-I knew when we started this that it wouldn't work out for me. I'm a bloody ghost, after all.";
    public static string Voice_EndDrama_2 = "But I just keep going back to what I wrote in my diary, the first week I was here.";
    public static string Voice_EndDrama_3 = "I was so excited that someone saw something in me, that they understood what I was trying to do with the writing.";
    public static string Voice_EndDrama_4 = "And even after Fred and I fought, after I rejected him, I was ready to forgive him if only to have the one thing I always wanted. My book.";
    public static string Voice_EndDrama_5 = "He'll probably publish it, anyway, the sick bastard. I mean I feel like quite a fool. I gave him a list of pseudonyms to choose from!";
    public static string Voice_EndDrama_6 = "Blast it all! To hell with Fred. To hell with Stanley Crofton. To hell with Alberta.";
    public static string Voice_EndDrama_7 = "You always hear about this happening to people, here and there, low-born girls disappearing off the streets. But I trusted them.";
    public static string Voice_EndDrama_8 = "I know I said I'd rather not know, but thank you for telling me anyway. I mean it. Maybe now I won't be bound to this place. Maybe I can leave.";
    public static string Voice_EndDrama_9 = "Now then, what will you do? Will you tell my sister what happened here? Will you try to bring Fred to justice?";
    public static string Voice_EndDrama_10 = "It's up to you, now more than ever. I only have one thing left to say - Goodbye.";
    public static string[] EndDrama_Keywords = { "goodbye" };

    public static string End_OP = "I know I said I'd rather not know, but thank you for telling me anyway. I mean it. Maybe now I won't be bound to this place. Maybe I can leave.";
    public static string End_0 = "It's up to you, now more than ever, to bring Fred to justice. I only have one thing left to say - Goodbye.";
    public static string End_1 = "It's up to you, now more than ever, to bring Fred to justice. I only have one thing left to say - Goodbye.";
    public static string End_2 = "It's up to you, now more than ever, to bring Fred to justice. I only have one thing left to say - Goodbye.";
    public static string End_3 = "It's up to you, now more than ever, to bring Fred to justice. I only have one thing left to say - Goodbye.";
    public static string[] End_Keywords = { "goodbye" };

    //Initialize arrays where the dialogue lines will be stored
    static string[] EntVal = { Entrance_OP, Entrance_0, Entrance_1, Entrance_2, Entrance_3 };
    static string[] DineVal = { Dining_OP, Dining_0, Dining_1, Dining_2, Dining_3 };
    static string[] LibVal = { Library_OP, Library_0, Library_1, Library_2, Library_3 };
    static string[] StudyVal = { Study_OP, Study_0, Study_1, Study_2, Study_3 };
    static string[] RebVal = { Rebecca_OP, Rebecca_0, Rebecca_1, Rebecca_2, Rebecca_3 };
    static string[] DrawVal = { Drawing_OP, Drawing_0, Drawing_1, Drawing_2, Drawing_3 };
    static string[] ElizaVal = { Eliza_OP, Eliza_0, Eliza_1, Eliza_2, Eliza_3 };
    static string[] FredVal = { Fred_OP, Fred_0, Fred_1, Fred_2, Fred_3 };
    static string[] DressVal = { Dressing_OP, Dressing_0, Dressing_1, Dressing_2, Dressing_3 };
    static string[] KitchVal = { Kitchen_OP, Kitchen_0, Kitchen_1, Kitchen_2, Kitchen_3 };
    static string[] CellVal = { Cellar_OP, Cellar_0, Cellar_1, Cellar_2, Cellar_3 };
    static string[] HouseVal = { Housekeeper_OP, Housekeeper_0, Housekeeper_1, Housekeeper_2, Housekeeper_3 };
    static string[] EndVal = {End_OP, End_0, End_1, End_2, End_3};

    //------------------------------------------ Adding Dialogue Lines to Dictionary at Start --------------------------------------------------

    public static void Initialize()
    {
        //Room Key --> Dialogue Lines
        dict_lines.Add("entrance", EntVal);
        dict_lines.Add("dining", DineVal);
        dict_lines.Add("library", LibVal);
        dict_lines.Add("study", StudyVal);
        dict_lines.Add("rebecca", RebVal);
        dict_lines.Add("drawing", DrawVal);
        dict_lines.Add("eliza", ElizaVal);
        dict_lines.Add("fred", FredVal);
        dict_lines.Add("dressing", DressVal);
        dict_lines.Add("kitchen", KitchVal);
        dict_lines.Add("cellar", CellVal);
        dict_lines.Add("housekeeper", HouseVal);
        dict_lines.Add("ending", EndVal);

        //Room Key --> Desired Keywords
        dict_keywords.Add("entrance", Entrance_Keywords);
        dict_keywords.Add("dining", Dining_Keywords);
        dict_keywords.Add("library", Library_Keywords);
        dict_keywords.Add("study", Study_Keywords);
        dict_keywords.Add("rebecca", Rebecca_Keywords);
        dict_keywords.Add("drawing", Drawing_Keywords);
        dict_keywords.Add("eliza", Eliza_Keywords);
        dict_keywords.Add("fred", Fred_Keywords);
        dict_keywords.Add("dressing", Dressing_Keywords);
        dict_keywords.Add("kitchen", Kitchen_Keywords);
        dict_keywords.Add("cellar", Cellar_Keywords);
        dict_keywords.Add("housekeeper", Housekeeper_Keywords);
        dict_keywords.Add("ending", End_Keywords);
    }
}

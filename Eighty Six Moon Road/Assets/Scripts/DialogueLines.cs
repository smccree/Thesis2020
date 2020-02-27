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
    public static string Entrance_0 = "You're being rather vague...well, no matter. If you could take a look around for me, I'd appreciate it greatly. There must be a reason I'm trapped here. I just can't remember what happened without your help.";
    public static string Entrance_1 = "Nothing makes sense here, does it? Well no matter. Now that you're here we can work together. Take a look around, let me know if you find anything.";
    public static string Entrance_2 = "I might be the one you came here looking for. If we can find out what happened to me, that solves both our problems. Well, take a look around then. Something in this house must have the information we're looking for.";
    public static string Entrance_3 = "You're a private investigator? That's perfect - you can help me! If you're looking for someone, well then I'm probably her. It would help if I could remember anything else, though. Well, take a look around then. Something in this house must have the information we're looking for.";
    public static string[] Entrance_Keywords = { "private", "investigator", "H.A", "H", "A", "searching", "missing", "sister", "woman", "person" };

    public static string Dining_OP = "It's so dark in here, even with all these windows. There must be a storm brewing outside. Have you found anything in here?";
    public static string Dining_0 = "That's a little disappointing.";
    public static string Dining_1 = "You found a note? I don't recognize any of the names. But 'Hannah'... could that be the 'H.A.' who sent you here?";
    public static string Dining_2 = "'An eye for an eye, and a tooth for a tooth, huh.' It seems fair on the outset, but it's quite cruel, when you think about it. I'd rather live and let live. Ironic, given the circumstances.";
    public static string Dining_3 = "Hold on a moment. Those names sound familiar. Hannah and Rebecca ... sisters. Hannah Ainsworth and Rebecca Stearn! Yes! I must have known them.";
    public static string[] Dining_Keywords = { "bible", "note", "Hannah", "Rebecca" };

    public static string Library_OP = "Nothing so comforting as rows of books and a shawl to wrap around one's shoulders, I think. Did you get a chance to read that note there on the table?";
    public static string Library_0 = "Oh come now, be serious! I need to know what it says. I might remember something.";
    public static string Library_1 = "So Rebecca was staying here for the summer. The house is quite empty now, save the two of us. Where has everyone gone?";
    public static string Library_2 = "I suppose Rebecca Stearn is a writer, then. Kind of Frederick to invite her to stay for the summer.";
    public static string Library_3 = "Frederick Beale ... I think I remember him. Always wore green. He used to sit in this chair, reading, for hours.";
    public static string[] Library_Keywords = { "Rebecca", "Frederick", "write", "book", "visit", "summer" };

    public static string Study_OP = "This must be Frederick's office. I was never allowed in here. I always wondered what I might find.";
    public static string Study_0 = "Look harder. I have a bad feeling.";
    public static string Study_1 = "Publishing is a tough business to be in, these days. People are too busy to read, I find. It only makes sense that they'd be doing poorly.";
    public static string Study_2 = "So Stanley was pressuring Eliza into marrying him? And Frederick just went along with it? The gall of some men - I swear!";
    public static string Study_3 = "Stanley was always a snotfaced little shnouzer. Always yapping around crying for attention and getting angry when he wouldn't get his way. I'm glad not to see any more of him, I'll tell you that.";
    public static string[] Study_Keywords = { "ledger", "Stanley", "Crofton", "publishing", "profits", "losses", "Eliza", "rejection" };

    public static string Rebecca_OP = "Hold on a minute. I think ... this was MY bedroom. I think I'm Rebecca! I feel a bit sick, now. Tell me, what did I write in my diary?";
    public static string Rebecca_0 = "dialogue";
    public static string Rebecca_1 = "dialogue";
    public static string Rebecca_2 = "dialogue";
    public static string Rebecca_3 = "dialogue";
    public static string[] Rebecca_Keywords = { "key1", "key2", "key3" };

    public static string Drawing_OP = "Have you ever been to a party in a room like this? I never understood the appeal, to be honest. Well, what did that invitation say?";
    public static string Drawing_0 = "dialogue";
    public static string Drawing_1 = "dialogue";
    public static string Drawing_2 = "dialogue";
    public static string Drawing_3 = "dialogue";
    public static string[] Drawing_Keywords = { "key1", "key2", "key3" };

    public static string Eliza_OP = "This must be Eliza's room. What did that letter say?";
    public static string Eliza_0 = "dialogue";
    public static string Eliza_1 = "dialogue";
    public static string Eliza_2 = "dialogue";
    public static string Eliza_3 = "dialogue";
    public static string[] Eliza_Keywords = { "key1", "key2", "key3" };

    public static string Fred_OP = "dialogue";
    public static string Fred_0 = "dialogue";
    public static string Fred_1 = "dialogue";
    public static string Fred_2 = "dialogue";
    public static string Fred_3 = "dialogue";
    public static string[] Fred_Keywords = { "key1", "key2", "key3" };

    public static string Dressing_OP = "dialogue";
    public static string Dressing_0 = "dialogue";
    public static string Dressing_1 = "dialogue";
    public static string Dressing_2 = "dialogue";
    public static string Dressing_3 = "dialogue";
    public static string[] Dressing_Keywords = { "key1", "key2", "key3" };

    public static string Kitchen_OP = "dialogue";
    public static string Kitchen_0 = "dialogue";
    public static string Kitchen_1 = "dialogue";
    public static string Kitchen_2 = "dialogue";
    public static string Kitchen_3 = "dialogue";
    public static string[] Kitchen_Keywords = { "key1", "key2", "key3" };

    public static string Cellar_OP = "dialogue";
    public static string Cellar_0 = "dialogue";
    public static string Cellar_1 = "dialogue";
    public static string Cellar_2 = "dialogue";
    public static string Cellar_3 = "dialogue";
    public static string[] Cellar_Keywords = { "key1", "key2", "key3" };

    public static string Housekeeper_OP = "dialogue";
    public static string Housekeeper_0 = "dialogue";
    public static string Housekeeper_1 = "dialogue";
    public static string Housekeeper_2 = "dialogue";
    public static string Housekeeper_3 = "dialogue";
    public static string[] Housekeeper_Keywords = { "key1", "key2", "key3" };

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

    public static string Voice_Failure_1 = "You can't be serious! Are you even trying to help me?";
    public static string Voice_Failure_2 = "You don't have to be here, you know. You can walk out the front door and forget all about this place, if you want. Some of us don't have that luxury.";
    public static string Voice_Failure_3 = "If you're going to joke around like that, you might as well go home and bother some other poor soul.";
    public static string Voice_Failure_4 = "You ARE a Private Investigator, right?";
    public static string Voice_Failure_5 = "Very funny. Now, let's try that again.";

    public static string Voice_Cancel_1 = "I'll be here when you're ready.";
    public static string Voice_Cancel_2 = "Let me know when you're ready to talk again.";
    public static string Voice_Cancel_3 = "Need another look around?";

    public static string Voice_EndDrama_1 = "You have reached the end of the game.";
    public static string Voice_EndDrama_2 = "I am summarizing events that transpired and things we found.";
    public static string Voice_EndDrama_3 = "You do not have to find everything to reach the end.";
    public static string Voice_EndDrama_4 = "The gist is Fred murdered me for getting my ideas into Eliza's head.";
    public static string Voice_EndDrama_5 = "Additionally I rejected HIS proposal.";
    public static string Voice_EndDrama_6 = "He proposed to me so that Eliza would accept Stanley's proposal.";
    public static string Voice_EndDrama_7 = "Eliza invited me to Paris, and we were all set to leave.";
    public static string Voice_EndDrama_8 = "But of course, Fred couldn't handle these slights.";
    public static string Voice_EndDrama_9 = "He killed me by drugging my nightly cup of tea and hitting me over the head with a book.";
    public static string Voice_EndDrama_10 = "He donated my body to science via the black market.";

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

    //------------------------------------------ Adding Dialogue Lines to Dictionary at Start --------------------------------------------------

    public static void Initialize()
    {
        //Room Key --> Dialogue Lines
        dict_lines.Add("entrance", EntVal);
        dict_lines.Add("dining", DineVal);
        dict_lines.Add("library", LibVal);
        dict_lines.Add("study", StudyVal);
        dict_lines.Add("rebecca", RebVal);
        dict_lines.Add("eliza", ElizaVal);
        dict_lines.Add("fred", FredVal);
        dict_lines.Add("dressing", DressVal);
        dict_lines.Add("kitchen", KitchVal);
        dict_lines.Add("cellar", CellVal);
        dict_lines.Add("housekeeper", HouseVal);

        //Room Key --> Desired Keywords
        dict_keywords.Add("entrance", Entrance_Keywords);
        dict_keywords.Add("dining", Dining_Keywords);
        dict_keywords.Add("library", Library_Keywords);
        dict_keywords.Add("study", Study_Keywords);
        dict_keywords.Add("rebecca", Rebecca_Keywords);
        dict_keywords.Add("eliza", Eliza_Keywords);
        dict_keywords.Add("fred", Fred_Keywords);
        dict_keywords.Add("dressing", Dressing_Keywords);
        dict_keywords.Add("kitchen", Kitchen_Keywords);
        dict_keywords.Add("cellar", Cellar_Keywords);
        dict_keywords.Add("housekeeper", Housekeeper_Keywords);
    }
}

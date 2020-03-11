using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    /*class is a box that stores references to all the dialogue in the game
        DICTIONARY with key/value pairs
        
        -Key: conversation #/identification code
        -array of strings:
            string[0] = first line/intro of the conversation
            string[1-4] = response A - D
        -list of keywords:
            iterate through player input string to find a match to keyword[0-2]

        Dictionary<string, string[]> dict_lines = new Dictionary<string, string[]>();
        where string = key
        string[] = values:
            string[0] = intro of the conversation
            string[1 - 4] = responses A - D

        2 dictionaries: one for key: keywords, one for key: dialogue lines.
    */

    //initializing the dictionary:
    public static Dictionary<string, string[]> dict_lines = new Dictionary<string, string[]>();
    public static Dictionary<string, string[]> dict_keywords = new Dictionary<string, string[]>();
    public static Dictionary<string, bool> dict_bools = new Dictionary<string, bool>();

    //-------------------------------------------------------- The Strings ------------------------------------------------------------------

    public static string Name = "Echoing Voice";
    public static string Name_Revealed = "Rebecca Stearn";

    public static string Reminder_1 = "Are you ready? This house is quite big. We have the entrance, dining room, library, study, drawing room, Rebecca's room, Frederick's room, Eliza's room, dressing room, kitchen, pantry, and housekeeper's room, after all. Which room do you want to tell me about?";
    public static string Reminder_2 = "Yes, I agree, the house is quite big. We have the entrance, dining room, library, study, drawing room, Rebecca's room, Frederick's room, Eliza's room, dressing room, kitchen, pantry, and housekeeper's room, after all.";
    public static string[] Reminders = { Reminder_1, Reminder_2 };
    public static string[] Reminder_Keywords = { "entrance", "dining", "library", "study", "drawing", "Rebecca", "rebecca", "Frederick", "Fred", "frederick", "fred", "Eliza", "eliza", "dressing", "kitchen", "pantry", "housekeeper" };
    

    public static string Entrance_OP = "Wait, was that the door? Finally! Who are you? What are you doing here?";
    public static string Entrance_0 = "Hold on... yes, it is you! Eliza! I have no idea why I got this way, but perhaps now that you're here you could look around for me. Maybe I'll remember something.";
    public static string Entrance_1 = "Hold on... the memories are fuzzy, but I think - yes, it IS you! Eliza! Thank goodness, I can hardly believe it. Clearly something has happened to me while you were away. I need your help trying to figure it all out. Take a look around and tell me what you find.";
    public static string Entrance_2 = "Eliza! Thank goodness, how long has it been? Oh - no matter. Clearly, something happened to me while you were away. I can't remember anything. It's all such a blur. Now that you're back, can you have a look around for me? Tell me if you find anything.";
    public static string Entrance_3 = "Eliza, it can't be! I was sure I'd never see you again. Last thing I can remember was settling in for the night, and writing in my diary. Next I knew, I was just ... a voice. Without a shape. And all my memories are scrambled somehow. You have to help me, show me if you find anything and it might shake something loose.";
    public static string[] Entrance_Keywords = { "Eliza", "came", "back", "home", "Freddie", "Rebecca", "freddie", "rebecca", "eliza", "trip", "Paris", "paris" };

    public static string Dining_OP = "Do you remember our first dinner in here? Let me think ... Alberta brought us pie and roast potatoes. Quite a feast, I remembered thinking. Was that a letter on the table?";
    public static string Dining_0 = "...Are you certain that's what it says?";
    public static string Dining_1 = "That letter ... I do worry about Hannah. I hope she's all right.";
    public static string Dining_2 = "Hannah! I hope she's all right. I wrote her back, I think. Now, what did I say? Hmm... I can't seem to place it. I shudder to think how Hannah would feel if she saw me now.";
    public static string Dining_3 = "Hannah! I hope she's all right. I wrote her back, I think. Now, what did I say? Hmm... I said we leave at the end of August, with your friend Alice and her chaperone. I shudder to think how she would feel if she saw me now.";
    public static string[] Dining_Keywords = { "note", "Hannah", "Rebecca", "Paris", "paris", "letter", "sister", "hannah", "rebecca", "visit", "happy" };

    public static string Library_OP = "I miss sitting in here, reading. With a shawl around my shoulders. It seems like only yesterday I was doing just that. What did you find in here?";
    public static string Library_0 = "Oh come now, be serious! I need to know what you found. I might remember something.";
    public static string Library_1 = "I could hardly believe it when Frederick invited me to stay with you both. I was quite anxious to finish my novel. The arrangement had perfect timing.";
    public static string Library_2 = "I could hardly believe that Beale and Crofton wanted to publish my book. I mean, I'm just some nobody. After all, they published Snicket. Charlie Snicket!";
    public static string Library_3 = "I remember something. A conversation between Fredrick and I. He said they needed another big success like Somber Home. They were counting on me. He and ... Stanley, wasn't it?";
    public static string[] Library_Keywords = { "Rebecca", "Frederick", "write", "book", "visit", "summer", "Fred", "fred", "frederick", "charlie", "Charlie", "snicket", "Snicket", "somber", "Somber", "home", "Home" };

    public static string Study_OP = "Frederick's office. I was never allowed in here. He used go on about separating work from his personal life. Could you tell me what that letter says?";
    public static string Study_0 = "Eliza, would you mind looking harder next time? We're getting closer to the truth. I can feel it.";
    public static string Study_1 = "Stanley doesn't seem to be taking your rejection well. That sounds like he was trying to blackmail Frederick into forcing you both to wed. I suppose it didn't work, though.";
    public static string Study_2 = "I still can't believe Frederick would go along with such a nasty scheme. The gall of some men, I swear! It should be up to you to make your own choice in who to marry. In a perfect world, that is. Perhaps not our world, though.";
    public static string Study_3 = "Hold on, Eliza. Is that ... a letter from my sister on the floor? What is that doing in here? I certainly don't remember seeing it. Did I just forget? I'm so confused. This is all such a mess. Why would Frederick hide that from me?";
    public static string[] Study_Keywords = { "ledger", "Stanley", "Crofton", "publishing", "profits", "losses", "Eliza", "rejection", "proposal", "reject", "rejected", "stanley", "tame", "taming", "marry", "bribe", "blackmail" };

    public static string Rebecca_OP = "My room. I still can't place what I was doing the last night before I ... let's say 'I lost my shape'. Finishing my manuscript, maybe? Oh, do be careful not to trip. What's that on the floor?";
    public static string Rebecca_0 = "Hmm ... that doesn't sound quite right.";
    public static string Rebecca_1 = "A tea cup? On the floor? Now, how did that get there? Did I have tea that night?";
    public static string Rebecca_2 = "I-I used to have tea every night before bed. Without fail. But that tea cup... I don't know how it would have fallen. I'm always so careful.";
    public static string Rebecca_3 = "I'm trying to remember. I used to have a cup of tea every night before bed. Think... I-I felt lightheaded. I dropped the cup. I'm sorry, nothing else is coming to me.";
    public static string[] Rebecca_Keywords = { "tea", "cup", "teacup", "broken", "floor", "fell", "dirty", "spill", "spilled", "dropped" };

    public static string Drawing_OP = "I think I remember playing the grand piano in here. I tried to be quiet since I'm so awful at it! Your friend Alice, now she was the real talent. Say, wasn't that letter addressed to her? What did you write?";
    public static string Drawing_0 = "I'm trying to remember that night but nothing comes to mind. Are you sure that's what the letter said?";
    public static string Drawing_1 = "I'm trying to remember that night, but I'm only getting flashes. I think I remember Stanley, though. He kept making eyes at you from across the room.";
    public static string Drawing_2 = "I remember that night. Yes, Alice played the piano. And there were small glasses of champagne. And Stanley, always lurking, in the background.";
    public static string Drawing_3 = "I remember that night! Yes, Alice played the piano. I always liked her. She tried her best to keep Stanley away from you, but he was quite persistent. I think we left the ball early. I was ... relieved. Balls and dancing were never my specialties, after all. Still, it was a good night.";
    public static string[] Drawing_Keywords = { "ball", "invited", "Stanley", "dance", "stanley", "alice", "Alice", "distract", "asked", "please" };

    public static string Eliza_OP = "How nostalgic! Your room is just the way you left it. You used to sit in that chair writing letters. I should say welcome home. A bit overdue, I suppose. Is there anything in here?";
    public static string Eliza_0 = "Perhaps read it over again.";
    public static string Eliza_1 = "He actually wrote that? Please excuse me while I vomit. And Fred's behavior toward you! You had every right to be angry.";
    public static string Eliza_2 = "'A delicate flower?' Please excuse me while I vomit. You have every right to be angry at Fred for trying to set you up with Stanley. Didn't you fight about it, later?";
    public static string Eliza_3 = "I remember, didn't you laugh when you first read this letter? You were beyond words. And you really let Fred have it at supper. It was quite a row. I would be angry too if my brother expected me to marry a man who called me a 'delicate flower' and thought it a compliment.";
    public static string[] Eliza_Keywords = { "Stanley", "Fred", "stanley", "fred", "scheming", "marry", "marriage", "proposal", "rejected", "plan", "mad", "angry", "delicate", "flower" };

    public static string Fred_OP = "Fred would be quite cross if he knew we were nosing about in his room. I wonder where he's off to tonight, come to think of it. Maybe he doesn't know you're home. What was that on the nightstand?";
    public static string Fred_0 = "Would you please look a little closer next time?";
    public static string Fred_1 = " I'd never been to the opera before. What did we see... 'Carmen,' I think. It was gruesome watching her die right on stage. The music was beautiful, but I've never been a fan of the macabre.";
    public static string Fred_2 = "I remember, Fred invited me to see 'Carmen.' We sat alone, in a private box. I couldn't help but sit completely upright the whole time. And the opera itself, it was so macabre. Seeing the heroine die like that made me a bit nauseous.";
    public static string Fred_3 = "It was all such an ostentatious affair, the opera. We saw 'Carmen,' and we were alone in a private box. I have no idea how much those tickets cost, and then the show itself was so gruesome. The heroine dies right on stage, in front of everybody. We got into a bit of a row when we got back. Quite an uncomfortable night.";
    public static string[] Fred_Keywords = { "opera", "tickets", "ticket", "invited", "fred", "Fred", "note", "bought" };

    public static string Dressing_OP = "I can't expect there's anything of note in here. It's just a bathing room after all. Wait - have you found something?";
    public static string Dressing_0 = "There must be more to this than what you've said....";
    public static string Dressing_1 = "I am happy for you, you know. You've always wanted to see Paris. But I feel quite distraught that you believed I would call us mere business acquaintances. I think of you as a sister, afer all.";
    public static string Dressing_2 = "I don't like any of this. Fred must have told you I said all that. And I suppose that other note gives us a reason why. But you must know that what this letter says is a lie. I think of you as a sister. And Fred... well I suppose I had quite complicated feelings about him.";
    public static string Dressing_3 = "I remember something else. I went out to town with Fred. I don't remember where, but we got into a row afterward. He... he proposed to me! And I was angry because I'd told him earlier that I wouldn't marry until my writing took off. I thought he'd respect that, at least. But I was wrong.";
    public static string[] Dressing_Keywords = { "paris", "Paris", "stanley", "Stanley", "follow", "following", "disrespected", "spinster", "persuade", "marry" };

    public static string Kitchen_OP = "I used to chat with Alberta when she cleaned up after supper. I was always a bit of a night owl, staying awake reading or working on my book. I would make tea, and then go back upstairs. What did you find in here?";
    public static string Kitchen_0 = "They can't be empty. Are you sure there was nothing important in there?";
    public static string Kitchen_1 = "Laudanum is nasty stuff. What were you doing with a bottle? Even a touch of it is highly addictive. I'm no professional and even I know the risks of taking some.";
    public static string Kitchen_2 = "I remember something about that last night. Before I lost my shape. I didn't make any tea. I was so focused on finishing my book that I stayed holed up in my room. Then ... how did that tea cup end up in my room? Who made the tea?";
    public static string Kitchen_3 = "I remember something else. My nightly cup of tea. I didn't make a cup that last night, I was so focused on finishing my novel, you see. But Fred brought me a cup of tea. He asked me to forgive him, about our fight. You don't think that he- No, he couldn't have spiked it. He wouldn't! .... Would he?";
    public static string[] Kitchen_Keywords = { "laudanum", "poison", "tea", "pot", "teapot", "teacup", "cup", "sleep", "medicine", "chemicals" };

    public static string Cellar_OP = "I'm sure it must have hurt you, Eliza, finding out all this. But I need you to tell me what you found in here. It's the only way I can move on.";
    public static string Cellar_0 = "I know this is hard, Eliza. I'd be suprised if it were easy, after all.";
    public static string Cellar_1 = "I remember now. All of it. Falling asleep that last night, and not waking up again.";
    public static string Cellar_2 = "I remember now. All of it. Falling asleep that last night, and not waking up again. Fred ... he drugged my tea. And brought me down here.";
    public static string Cellar_3 = "I remember now. All of it. Falling asleep that last night, and not waking up again. Fred ... he drugged my tea. And brought me down here. He must have... delivered my body to someone. I don't want to think about what they must have done with it.";
    public static string[] Cellar_Keywords = { "crate", "body", "empty", "dragged", "street", "deliver", "work", "dissect", "science", "experiment", "Whitechapel", "whitechapel" };

    public static string Housekeeper_OP = "Alberta's room. She was a lovely woman ... You don't think she was involved in this, do you? What does that note say?";
    public static string Housekeeper_0 = "You didn't find anything? Are you sure?";
    public static string Housekeeper_1 = "Alberta went along with this? I can hardly believe it. She was always so kind. We used to talk quite a bit, after supper. She washed the dishes, and I would dry them.";
    public static string Housekeeper_2 = "Alberta went along with this? I can hardly believe it. But then again, she's been employed with your family for years. I'd only known her for a few months.";
    public static string Housekeeper_3 = "Alberta went along with this? I can hardly believe it. But then again, she's been employed with your family for years. What would you do if the one person who could make your life difficult asked you for an impossible favor?";
    public static string[] Housekeeper_Keywords = { "note", "Fred", "crate", "sons", "deliver", "ask", "bring", "back", "security", "Whitechapel", "whitechapel" };

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

    public static string Locked_Study = "Locked, huh? I'm sure the key is somewhere in this house.";
    public static string Locked_Basement = "This is quite an odd looking door. It seems as though you'll need three keys to open it.";
    public static string Locked_Cellar = "Isn't this where you store food? Why lock this door, of all places?";
    public static string Locked_Other = "Let's take this one room at a time. We must be thorough. Let me know when you're ready to talk about what you found.";
    
    public static string Voice_Failure_1 = "You can't be serious! Are you even trying to help me?";
    public static string Voice_Failure_2 = "You don't have to be here, you know. You can walk out the front door and forget all about this place, if you want. Some of us don't have that luxury.";
    public static string Voice_Failure_3 = "If you're going to joke around like that, you might as well go home and bother some other poor soul.";
    public static string Voice_Failure_4 = "You ARE Eliza, right?";
    public static string Voice_Failure_5 = "Very funny. Now, let's try that again.";

    public static string Voice_Quiet_1 = "Eliza, you're being rather quiet. Are you all right? I know this is a lot to take in. Just take your time looking around.";
    public static string Voice_Quiet_2 = "Forgive me if I'm speaking too quickly, I didn't mean to overwhelm you. I'm sure there will be more clues in the next room.";
    public static string Voice_Quiet_3 = "I don't remember you being this quiet. Is everything all right? I'm sure you didn't expect to return home to ... this.";
    public static string Voice_Quiet_4 = "After all this, how could you be so quiet? I-I don't understand. And I suppose I never will. I can't hold onto this place any longer. I need to let go and move on. Goodbye, Eliza.";
    public static string Voice_Quiet_5 = "You're being rather quiet, but still ... yes, it is you! Eliza! I have no idea why I got this way, but perhaps now that you're here you could look around for me. Maybe I'll remember something.";

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

    public static string End_OP = "We've searched this house up and down, and I think I finally see the full picture. Thank you, Eliza. You've been a true friend throughout all this. I'm sorry it's your family we're dealing with, but I hope it won't stop you from doing what's right. Will you promise me - you'll hold Frederick accountable, somehow?";
    public static string End_0 = "Oh. All right. I-I guess I was wrong. Maybe trusting you wasn't such a good idea after all. I suppose he IS your brother ... in any case, it won't do me any good to dwell on this any longer. Goodbye, Eliza.";
    public static string End_1 = "It's up to you, now more than ever, to bring Fred to justice. I only have one thing left to say - Goodbye.";
    public static string End_2 = "It's up to you, now more than ever, to bring Fred to justice. I only have one thing left to say - Goodbye.";
    public static string End_3 = "It's up to you, now more than ever, to bring Fred to justice. I only have one thing left to say - Goodbye.";
    public static string[] End_Keywords = { "yes", "promise", "help", "justice", "promise.", "yes.", "justice.", "help." };

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
        dict_lines.Add("reminder", Reminders);

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
        dict_keywords.Add("reminder", Reminder_Keywords);
    }
}

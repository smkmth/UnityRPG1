//using System.Collections;
//using UnityEngine;
//
//public class ConversationManager : Singleton<ConversationManager> {
//
//	//guarentee this will always be a singleton
//	protected ConversationManager() {}
//
//	public void StartConversation (Conversation conversation) {
//		if (!talking)
//		{
//			Debug.Log ("Started coroutine");
//			StartCoroutine(DisplayConversation(conversation));
//		}
//	}
//
//	bool wait = false;
//
//	//is a conversation going on
//	bool talking = false;
//
//	//current line of text being displayed 
//	ConversationEntry currentConversationLine;
//
//	//estimated width of characters on font
//	int fontSpacing = 7;
//
//	int conversationTextWidth;
//
//	int dialogHeight = 150;
//
//	//offset space needed for character image
//	public int displayTextureOffSet = 50;
//
//	//scaled image rectangle for diplayeing character image
//	Rect scaledTextureRect;
//
//	IEnumerator WaitForKeyDown(KeyCode keyCode)
//	{
//		while (!Input.GetKeyDown (keyCode)) 
//			yield return null;
//		yield return new WaitForFixedUpdate ();
//
//
//	}
//
//	IEnumerator DisplayConversation (Conversation conversation)
//	{
//		
//		talking = true;
//		foreach (var conversationLine in conversation.ConversationLines) {
//			currentConversationLine = conversationLine;
//			conversationTextWidth = currentConversationLine.ConversationText.Length* fontSpacing;
//
//			scaledTextureRect = new Rect (
//				currentConversationLine.DisplayPic.textureRect.x / currentConversationLine.DisplayPic.texture.width,
//
//				currentConversationLine.DisplayPic.textureRect.y / currentConversationLine.DisplayPic.texture.height,
//
//				currentConversationLine.DisplayPic.textureRect.width / currentConversationLine.DisplayPic.texture.width,
//
//				currentConversationLine.DisplayPic.textureRect.height /	currentConversationLine.DisplayPic.textureRect.height);
//				
//
//			
//
//			yield return StartCoroutine(WaitForKeyDown(KeyCode.X));
//			//yield return new WaitForSeconds (3);
//		}
//		talking = false;
//		yield return null;
//	}
////talking to truem then for each line in the conversation it
//// *sets a pointer to the current conversation line with the curretconversationline property
////* figures how long the text is to figure out how large the display area should be
////*wait three seconds before moving to next item
////*when finished it sets the talking flag to false.
//	void OnGUI(){
//		if (talking)
//		{
//			//layout start
//			GUI.BeginGroup (new Rect (Screen.width / 2 - conversationTextWidth / 2,
//				50, conversationTextWidth + 10, dialogHeight));
//			//background box
//			GUI.Box(new Rect(0,0, conversationTextWidth + 10, dialogHeight), "");
//
//			//character name
//			GUI.Label(new Rect (10, 10, conversationTextWidth + 30, 20),
//				currentConversationLine.SpeakingCharacterName);
//			//conversation text
//			GUI.Label(new Rect (10, 30, conversationTextWidth + 30, 20),
//				currentConversationLine.ConversationText);
//			//dispkay picture
//			GUI.DrawTextureWithTexCoords (new Rect (0, 50, 50, 50),
//				currentConversationLine.DisplayPic.texture,scaledTextureRect);
//
//			//layout end
//			GUI.EndGroup();
//		}
//	}
//	//method to start corroutine 
//
//
//
//}
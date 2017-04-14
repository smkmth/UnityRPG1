//using UnityEngine;
//
////messaginf client reciver takes the message from the manager its 
////subscribed to and performs an action with it
//
//public class MessagingClientReceiver : MonoBehaviour
//{
//	void Start()
//	{
//		MessagingManager.Instance.Subscribe (ThePlayerIsTryingToLeave);
//	}
//		
//	void ThePlayerIsTryingToLeave ()
//		{
//			var dialog = GetComponent<ConversationComponent>();
//			if (dialog != null)
//			{
//				if (dialog.Conversations != null && dialog.Conversations.Length > 0)
//				{
//					var conversation = dialog.Conversations[0];
//					if (conversation != null)
//					{
//					ConversationManager.Instance.StartConversation(conversation);
//					}
//				}
//			}
//		}
//}
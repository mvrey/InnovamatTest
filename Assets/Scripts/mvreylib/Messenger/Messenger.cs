using System;
using System.Collections;
using System.Collections.Generic;

namespace mvreylib.features.messenger
{
    public static class Messenger
    {
        public static Dictionary<Enum, List<Delegate>> objectSubscriptions;
        public static Dictionary<Enum, List<Func<ArrayList>>> objectSubscriptionsFunc;

        public static void Init()
        {
            objectSubscriptions = new Dictionary<Enum, List<Delegate>>();
        }


        public static void AddListener(Enum key, Delegate subscriber)
        {
            List<Delegate> subscribersList;

            if (!objectSubscriptions.ContainsKey(key))
            {
                subscribersList = new List<Delegate>();
                objectSubscriptions.Add(key, subscribersList);
            }

            objectSubscriptions.TryGetValue(key, out subscribersList);
            if (!subscribersList.Contains(subscriber))
            {
                subscribersList.Add(subscriber);
                objectSubscriptions[key] = subscribersList;
            }
        }


        public static void RemoveListener(Enum key, Delegate subscriber)
        {

        }


        public static void SendMessage(Enum key, ArrayList data = null)
        {
            List<Delegate> subscribersList;
            objectSubscriptions.TryGetValue(key, out subscribersList);

            if (subscribersList != null)
            {
                foreach (Delegate subscriber in subscribersList)
                {
                    if (data == null)
                        subscriber.DynamicInvoke();
                    else
                        subscriber.DynamicInvoke(data);
                }
            }
        }
    }
}
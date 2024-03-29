﻿using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Diagnostics.CodeAnalysis;

namespace Degano
{
    [ExcludeFromCodeCoverage]
    public class Ex
    {
        public DateTime date { get; set; }
        public string exMessage { get; set; }

        public Ex(DateTime date, string exMessage)
        {
            this.date = date;
            this.exMessage = exMessage;
        }
    }
    
    [ExcludeFromCodeCoverage]
    public static class ExceptionLogger
    {
        public static async void Log(string error)
        {
            System.Diagnostics.Debug.WriteLine("Exception thrown: " + error + $"\ntimestamp: {DateTime.Now}\n");

            Ex ex = new Ex(DateTime.Now, error);

            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://degano-70426-default-rtdb.europe-west1.firebasedatabase.app/"
            };
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = await client.SetAsync("Exceptions/" + DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss"), ex.exMessage
                #if ANDROID || IOS 
                + " on " + DeviceInfo.Name + ", " + DeviceInfo.Model
                #endif
                );
        }
    }
}

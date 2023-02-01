using OmegaCore.Collections;
using OmegaCore.Interfaces;
using System;

namespace OmegaCoreTests.Shared
{
    public class SampleObject
    {
             
        const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public string Name { get; set; }

        public SampleObject(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is SampleObject other)
            {
                return Name == other.Name;
            }

            return false;
        }

        public static IOmegaList<SampleObject> CreateSampleList()
        {
            IOmegaList<SampleObject> list = new OmegaList<SampleObject>();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                string newValue = ALPHABET[random.Next(ALPHABET.Length - 1)].ToString();
                list.Add(new SampleObject(newValue));
            }

            return list;
        }

        public static IOmegaQueue<SampleObject> CreateSampleQueue()
        {
            IOmegaQueue<SampleObject> queue = new OmegaQueue<SampleObject>();
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                string newValue = ALPHABET[random.Next(ALPHABET.Length - 1)].ToString();
                queue.Queue(new SampleObject(newValue));
            }

            return queue;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

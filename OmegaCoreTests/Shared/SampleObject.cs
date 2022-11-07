using OmegaCore.Collections;
using OmegaCore.Interfaces;
using System;

namespace OmegaCoreTests.Shared
{
    public class SampleObject
    {
        public string Name { get; set; }

        public SampleObject(string name)
        {
            Name = name;
        }

        public static IOmegaList<SampleObject> CreateSampleList()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            IOmegaList<SampleObject> list = new OmegaList<SampleObject>();
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                string newValue = alphabet[random.Next(alphabet.Length - 1)].ToString();
                list.Add(new SampleObject(newValue));
            }

            return list;
        }
    }
}

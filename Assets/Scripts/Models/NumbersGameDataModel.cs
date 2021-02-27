using innovamattest.configs;
using UnityEngine;

namespace innovamattest.models
{
    public class NumbersGameDataModel
    {
        private static NumbersGameDataModel instance;

        public InnovamatTestConfig innovamatTestConfig;


        private NumbersGameDataModel() { }

        public static NumbersGameDataModel Get()
        {
            if (instance == null)
            {
                instance = new NumbersGameDataModel();
                instance.innovamatTestConfig = Resources.Load("Configs/InnovamatTestConfig") as InnovamatTestConfig;
            }
            return instance;
        }
    }
}
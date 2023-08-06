using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace AlexzanderCowell
{
    [CreateAssetMenu(fileName = "NewDataManager", menuName = "Custom/Data Manager")]
    public class DataManager : ScriptableObject
    {
        public List<UserData> userDataList;

        private static string _savePath;

        [System.Serializable]
        private class UserDataWrapper
        {
            public List<UserData> data;
        }

        public void SaveUserData()
        {
            _savePath = Path.Combine(Application.persistentDataPath, "userdata.json");
            UserDataWrapper wrapper = new UserDataWrapper { data = userDataList };
            string jsonData = JsonUtility.ToJson(wrapper);
            File.WriteAllText(_savePath, jsonData);
        }

        public void LoadUserData()
        {
            _savePath = Path.Combine(Application.persistentDataPath, "userdata.json");
            if (File.Exists(_savePath))
            {
                string jsonData = File.ReadAllText(_savePath);
                UserDataWrapper wrapper = JsonUtility.FromJson<UserDataWrapper>(jsonData);
                userDataList = wrapper.data;
            }
            else
            {
                userDataList = new List<UserData>(); // Create an empty list if the file doesn't exist
            }
        }

        public void AddUserData(UserData userData)
        {
            userDataList ??= new List<UserData>();

            userDataList.Add(userData);
        }
        
        }
    [System.Serializable]
    public class UserDataListWrapper
    {
        public List<UserData> userDataList;

        public UserDataListWrapper(List<UserData> list)
        {
            userDataList = list;
        }
    }
}



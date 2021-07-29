using System;

namespace ToDebugString
{
    public class UserData
    {
        public UserInformation UserInformation = new UserInformation();

        public PlayerStatus PlayerStatus = new PlayerStatus();
    }

    public class UserInformation
    {
        public long UserId;

        public string UserName = "Default User";

        public DateTime BirthDay = DateTime.Now;

        public int Age;
    }

    public class PlayerStatus
    {
        public int Level;

        public bool IsJoinedGuild;

        public Guild Guild = new Guild();
    }

    public class Guild
    {
        public long Id;

        public int Level;

        public string Name = "Default Guild";

        public int NumOfMembers;
    }
}
